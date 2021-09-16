using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed; //Player speed
    private int health; //Player HP
    [SerializeField] private int maxHealth; //Player Max HP
    private Vector3 dirMovement; //Movement direction of the player
    private Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        health = maxHealth;
    }

    void Update()
    {
        dirMovement = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized * speed;

        dirMovement.y = rb.velocity.y;
        rb.velocity = dirMovement;

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
            health -= value;

            if (health < 0)
                health = 0;
            else if (health > maxHealth)
                health = maxHealth;
        }
    }

}
