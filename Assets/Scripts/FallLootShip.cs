using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallLootShip : MonoBehaviour
{
    /* Alexander Iniguez November, 2021
     * When fall this ship, it will crash in the main island like a loot
     * Some ship
     */



    /* Rand forma
     * 
     * Loot
     * caer
     * detener hacer daño
     * soltar loot
     */

    private Rigidbody rb;
    private MeshFilter filter;
    private GameObject[] meshes;
    private int index;
    
    void Start()
    {
        filter = GetComponent<MeshFilter>();
        rb = GetComponent<Rigidbody>();
        index = Random.Range(0, meshes.Length);
    }

    void Update()
    {
        
    }
}
