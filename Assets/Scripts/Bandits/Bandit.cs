using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class Bandit : MonoBehaviour
{
    [SerializeField] protected float speed; //speed
    [SerializeField] protected int maxHealth; //Max HP
    [SerializeField] protected int health; //current HP
    [SerializeField] protected int damage; //current HP
    [SerializeField] protected float cooldownAttack; //the attack's cooldown time in seconds 
    [SerializeField] protected float attackRadio; //current HP
    [MinMaxSlider(2, 5)]
    [SerializeField] protected Vector2Int lootRange; //minimun and maximum range of the loot when it dies
    [SerializeField] protected Transform attackPoint;
    [SerializeField] protected GameObject[] pfbResources;

    //private HealthBar _healthBar;
    protected Vector3 dirMovement; //Movement direction
    protected Rigidbody rb;

    protected void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    protected void Update()
    {
        //Update
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadio);
    }

    public void TakeDamage(int _damage)
    {
        Health -= _damage;
        Debug.Log("Get damage", gameObject);
    }

    public int Health
    {
        get { return health; }
        set
        {
            health = value;

            //Values verification
            if (health < 0)
                health = 0;
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

    [Button("Attack")]
    protected void Attack()
    {
        Collider[] hitColliders = Physics.OverlapSphere(attackPoint.position, attackRadio);

        foreach (Collider hit in hitColliders)
        {
            if (hit.gameObject.CompareTag("Player"))
            {
                Debug.Log("Player damaged!", gameObject);
                hit.GetComponent<Player>().TakeDamage(damage);
            }
            //Lógica para checar si es el player
        }
    }

    [Button("Die")]
    protected void Die()
    {
        int randLootAmount = Random.Range(lootRange.x, lootRange.y + 1); //Get random amount of resources to be droped
        Rigidbody tempRb;
        for (int i = 0; i < randLootAmount; i++)
        {
            int randIndex = Random.Range(0, pfbResources.Length); //Random resourse
            print(randIndex);
            tempRb = Instantiate(pfbResources[randIndex], transform.position, Random.rotation).GetComponent<Rigidbody>();
            tempRb.AddExplosionForce(50f, transform.position + Random.insideUnitSphere, 2f);
        }
    }

    //public HealthBar healthBar { get { return _healthBar; } set { _healthBar = value; } }
}
