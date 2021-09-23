using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed; //Player speed
    [SerializeField] private int maxHealth; //Player Max HP
    [SerializeField] private int health; //Player HP
    [SerializeField] private Image healthBarUI;
    private Vector3 dirMovement; //Movement direction of the player
    private Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        health = maxHealth; //Set initial health
        healthBarUI.fillAmount = (float) health / maxHealth; //Set initial value of HealtBar in UI
    }

    void Update()
    {
        //Get direction vector of movement
        dirMovement = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized * speed;

        //Assign movement direction to the rigidbody velocity
        dirMovement.y = rb.velocity.y; 
        rb.velocity = dirMovement;

        #region DEBUG INPUTS
        if (Input.GetKeyDown(KeyCode.Alpha1))
            Health++;
        if (Input.GetKeyDown(KeyCode.Alpha2))
            Health--;
        #endregion
    }

    public float Speed
    {
        get; set;
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
            healthBarUI.fillAmount = (float)health / maxHealth;
        }
    }

}
