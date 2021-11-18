using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnOnTree : MonoBehaviour
{
    /* Alexander Iniguez November, 2021
     * when touch the object will call respawnloot 
     * tree Collider 
     */
    //who will call
    private RespawnLoot respawnLoot;
    private float timer;
    [SerializeField] private float timeToCollision;
    private bool canRespawn;


    //Restart Variables
    void Start()
    {
        if (!respawnLoot)
            respawnLoot = GetComponent<RespawnLoot>();

        this.enabled = true;
        timer = 0;
        canRespawn = false;
    }

    void Update()
    {
        if(timer < timeToCollision)
        {
            timer += Time.deltaTime;

        }
        else
        {
            canRespawn = true;
            this.enabled = false;
        }
    }

    //call funtion of RespawnLoot
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag(K.Tag.player) && canRespawn)
        {

            Start();
            respawnLoot.InstanceLoot();

        }
    }
}
