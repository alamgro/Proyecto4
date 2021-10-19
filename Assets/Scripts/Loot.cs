using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    /* Alexander Iniguez Septiembre, 2021
    *  Give a diferent loot, by each type of material but need craft with a input
    *  A big loot in ground
    */

    private float timer;
    [Header("Value ")]

    public float timeLot; //time for input 
    //min and max amount of recurso to give
    public int minSize, maxSize;
    private bool isInside;
    private MeshRenderer renderThis;
    //Reference at singleton
    Resources resources;

    /*
     * entrar  bool
     * input   space
     * timer en el imput  dar loot
     * 
     */


    void Start()
    {
        isInside = false;
        resources = Resources.Instance; //initialization
        renderThis = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isInside)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                    timer = 0f;

            if (Input.GetKey(KeyCode.Space))
            {
                renderThis.material.color = Color.cyan;

                timer += Time.deltaTime;
                if(timer >= timeLot)
                {
                    timer = 0f;
                    RandomResources();
                    gameObject.SetActive(false);
                }
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                timer = 0f;
                renderThis.material.color = Color.gray;
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        //collision.contacts[0].thisCollider;
        if (other.gameObject.CompareTag("Player"))
            isInside = true;  //is inside
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            isInside = false;  //is out
    }
    
    //Selection random of resource amount by each
    private void RandomResources()
    {
        //Add at each resource
        resources.wood += RandomAmount();
        resources.junk += RandomAmount();
        resources.plastic += RandomAmount();
        resources.food += RandomAmount();

        resources.UpdateUI();
    }

    int  RandomAmount()
    {
        return Random.Range(minSize, maxSize + 1);
    }
}
