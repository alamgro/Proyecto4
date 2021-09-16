using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float speed; //Player speed
    private Vector3 movementDir; //Movement direction of the player
    private Rigidbody rb;

    public float Speed 
    {
        get; set;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        movementDir = rb.velocity;
        movementDir = new Vector3(Input.GetAxisRaw("Horizontal"), movementDir.y, Input.GetAxisRaw("Vertical")).normalized;

        rb.velocity = movementDir * speed;
    }


}
