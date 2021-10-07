using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    /* Alexander Iniguez Septiembre, 2021
    *  Give a diferent loot, by each type of material but need craft with a input
    *  A big loot in ground
    */

    public float timer;

    //min and max amount of recurso to give
    public int minSize, maxSize;

    private bool isInside;

    //enum?


    //Reference at singleton
    Resources resources;

    void Start()
    {
        isInside = false;
        resources = Resources.Instance; //initialization
    }

    // Update is called once per frame
    void Update()
    {
        if(isInside)
        {
            if(Input.GetKey(KeyCode.Space))
            {

            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //is inside
        isInside = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        //is out
        isInside = false;

    }

    //Selection random of resource amount by each
    private void RandomResources()
    {

        //Add at each resource
        resources.wood += RandomAmount();
        resources.junk += RandomAmount();
        resources.plastic += RandomAmount();
        resources.food += RandomAmount();
        

    }

    int  RandomAmount()
    {
        return Random.Range(minSize, maxSize);
    }
}
