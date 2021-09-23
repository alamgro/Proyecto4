using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddResource : MonoBehaviour
{               
    //Item Resource
    /*Alexander Iniguez Septiembre, 2021
     * Añanade un elemento a los recursos del enum, llama la funcion de actualizar el UI
     */

    public Item typeItem; //Que tipo de recurso quieres que sea

    Resources resources;

    void Start()
    {
         resources = Resources.Instance; //Una referencias 
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
            resources.UpdateUI(); //Llamada desde Resources
            Destroy(gameObject);
        }
    }
}//EndItem
