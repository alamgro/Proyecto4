using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallLimit : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    //Check collision for any object
    private void OnTriggerEnter(Collider other)
    {
        //If a character
        ICharacters character = other.gameObject.GetComponent<ICharacters>();
        if(character != null)
        {
            character.Die();
        }
        else
        {
            Destroy(other.gameObject);
        }
    }

}
