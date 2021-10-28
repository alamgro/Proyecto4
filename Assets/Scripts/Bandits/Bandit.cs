using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class Bandit : MonoBehaviour, ICharacters
{
    [Header("Basic attributes")]
    [ProgressBar("Health", "maxHealth", EColor.Red)]
    [SerializeField] protected int health; //current HP
    [SerializeField] protected int maxHealth; //Max HP
    [SerializeField] protected float speed; //speed
    [Header("Damage attributes")]
    [SerializeField] protected int damage; //current HP
    [SerializeField] protected float cooldownAttack; //the attack's cooldown time in seconds 
    [SerializeField] protected float attackRadio; //current HP
    [SerializeField] protected Transform attackPoint;
    [Header("Other attributes")]
    [MinMaxSlider(0, 10)]
    [SerializeField] protected Vector2Int lootRange; //minimun and maximum range of the loot when it dies
    [SerializeField] protected AudioClip audioPop;
    [SerializeField] protected GameObject[] pfbResources;

    //private HealthBar _healthBar;
    private float attackTimer = 0f;
    protected Vector3 dirMovement; //Movement direction
    protected Rigidbody rb;

    protected void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    protected void Update()
    {
        attackTimer -= Time.deltaTime;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadio);
    }

    public int Health
    {
        get { return health; }
        set
        {
            health = value;

            //Values verification
            if (health < 0)
            {
                health = 0;
                Die();
            }
            else if (health > maxHealth)
                health = maxHealth;

            //Update health bar
            //healthBar.UpdateHealth();
            //healthBar.UpdateBar();
        }
    }

    public int MaxHealth { get { return maxHealth; } }

    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    public void TakeDamage(int _damage)
    {
        Health -= _damage;
        Debug.Log("Get damage", gameObject);
    }

    [Button("Attack")]
    public void Attack()
    {
        //If the attack timer is on cooldown, it can't attack
        if (attackTimer >= 0f)
            return;

        attackTimer = cooldownAttack; //Attack enters on cooldown

        Collider[] hitColliders = Physics.OverlapSphere(attackPoint.position, attackRadio);

        foreach (Collider hit in hitColliders)
        {
            //Verify if one of the colliders is the player
            if (hit.gameObject.CompareTag(K.Tag.player))
            {
                Debug.Log("Player damaged!", gameObject);
                hit.GetComponent<Player>().TakeDamage(damage);
            }
        }
    }

    [Button("Die")]
    public void Die()
    {
        int randLootAmount = Random.Range(lootRange.x, lootRange.y + 1); //Get random amount of resources to be droped
        Rigidbody tempRb;
        for (int i = 0; i < randLootAmount; i++)
        {
            int randIndex = Random.Range(0, pfbResources.Length); //Random resourse
            //print(randIndex);
            tempRb = Instantiate(pfbResources[randIndex], transform.position, Random.rotation).GetComponent<Rigidbody>();
            tempRb.AddExplosionForce(50f, transform.position + Random.insideUnitSphere, 1f);
            AudioSource.PlayClipAtPoint(audioPop, transform.position);
            Destroy(gameObject);
        }
    }

    //public HealthBar healthBar { get { return _healthBar; } set { _healthBar = value; } }
}
