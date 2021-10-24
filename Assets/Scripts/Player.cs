using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using NaughtyAttributes;

/*
 * Author: Alam Rodriguez.
 * This script contains player's basic logic such as general movement (inputs), attibutes (health, speed, etc.)
 * and other necessary functions
 * Posibilidad de que tenga invulnerabilidad por un tiempo **
 */

public class Player : MonoBehaviour, ICharacters
{
    [ProgressBar("Health", "maxHealth", EColor.Red)]
    [SerializeField] private int health; //Player current HP
    [SerializeField] private int maxHealth; //Player Max HP
    [SerializeField] private float speed; //Player speed
    [SerializeField] private float jumpHeight; //Player jump force
    [SerializeField] private LayerMask layerJump;
    [SerializeField] private AudioClip audioDeath;
    private float jumpForce; //Final force that will be applied
    private HealthBar _healthBar;
    private Vector3 dirMovement; //Movement direction of the player
    private Rigidbody rb;
    private Camera cam;
    private Collider colliderPlayer;
    
    void Start()
    {
        #region GET COMPONENTS
        rb = GetComponent<Rigidbody>();
        colliderPlayer = GetComponent<Collider>();
        cam = Camera.main;
        #endregion

        health = maxHealth; //Set initial health
        jumpForce = Mathf.Sqrt(-2f * jumpHeight * Physics.gravity.y);
    }

    void Update()
    {
        #region MOVEMENT
        //Get direction vector of movement
        dirMovement = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;
        
        dirMovement = cam.transform.TransformDirection(dirMovement) * speed;  //Get new direction compared with the camera world direction
        dirMovement.y = rb.velocity.y;
        rb.velocity = dirMovement; //Assign movement direction to the rigidbody velocity
        #endregion

        #region JUMP
        if (Input.GetButtonDown("Jump"))
        {
            //print(colliderPlayer.bounds.min);
            if (Physics.Raycast(transform.position, Vector3.down, colliderPlayer.bounds.extents.y + 0.05f, layerJump))
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        #endregion

        #region ROTATION
        dirMovement.y = 0f; //set 0f so it does not affect the rotation vector
        //Rotate player to the same direction it is moving to
        if (dirMovement != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(dirMovement); //Rotate
        }
        #endregion

        #region DEBUG INPUTS
        if (Input.GetKeyDown(KeyCode.Alpha1))
            Health++;
        if (Input.GetKeyDown(KeyCode.Alpha2))
            Health--;
        #endregion
    }

    public float Speed
    {
        get { return speed; } 
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
            healthBar.UpdateHealth();
            //healthBar.UpdateBar();
        }
    }
        
    public int MaxHealth { get { return maxHealth; } }

    public HealthBar healthBar { get { return _healthBar; } set { _healthBar = value; } }

    public void TakeDamage(int _damage)
    {
        Health -= _damage;
        //print("Get damage");
    }

    [Button("Die")]
    public void Die()
    {
        Resources.Instance.RemoveHalfResources(); //Death penalization
        transform.position = Vector3.zero; //reset position
        rb.velocity = rb.angularVelocity = Vector3.zero; //Stop from moving
        AudioSource.PlayClipAtPoint(audioDeath, transform.position); //Play death audio
    }

    public void Attack()
    {
        throw new System.NotImplementedException();
    }

}
