using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NaughtyAttributes;

public class UpdateHealth : MonoBehaviour
{

    /* Alexander Iniguez November, 2021
     * calcuate update healt bar of one on=bject
     * Robot or bandit
     */

    [SerializeField] private ICharacters character;
    [SerializeField] private Image bar;
    //if is robot use enemy || if is bandit 
    //[Tag][SerializeField] private string tag;
    /*public int health;
    [SerializeField] private int maxHealth;*/
    
    //Alam podemos usar el Scriptable Object para daber su vida

    void Start()
    {
        character = GetComponent<ICharacters>();
        BarUpdateHealth();
            
    }



    ///este collision enter no debe de estar aquí, la colision ya es detectada desde el player, bandido, etc. 
    ///Hay que meter la llamada de la función en esos scripts, no aquí
    private void OnCollisionEnter(Collision collision)
    {
        //if con codigo de k
        if (collision.gameObject.CompareTag(K.Tag.player) || collision.gameObject.CompareTag(K.Tag.neutral))
        {
            print("barra actualizada");
            BarUpdateHealth();
        }
    }



    private void BarUpdateHealth()
    {
        bar.fillAmount = character.Health / (float)character.MaxHealth;
    }
}
