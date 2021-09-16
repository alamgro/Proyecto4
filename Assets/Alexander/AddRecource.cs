using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRecource : MonoBehaviour
{               //Item Resource
    /*Alexander Iniguez Septiembre, 2021
     * Añanade un elemto a los recursos 
     */

    public Item typeItem; //Que tipo de recurso es 

    Resources resources;
    void Start()
    {
         resources = Resources.Instance; //Una referencias para las 

    }

    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            switch (typeItem)
            {
                case Item.wood:
                    resources.wood++;
                    break;

                case Item.food:
                    resources.food++;
                    break;

                case Item.junk:
                    resources.junk++;
                    break;

                case Item.plastic:
                    resources.plastic++;
                    break;
            }

            resources.UpdateHealthBar();
            Destroy(gameObject);
        }
    }
}//EndItem
