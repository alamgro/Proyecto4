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
    [Tag][SerializeField] private string tag;
    /*public int health;
    [SerializeField] private int maxHealth;*/
    
    //Alam podemos usar el Scriptable Object para daber su vida

    void Start()
    {
        character = GetComponent<ICharacters>();
        BarUpdateHealth();
            
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if con codigo de k
        if (collision.gameObject.CompareTag(tag))
        {
            
            BarUpdateHealth();
        }
    }

    private void BarUpdateHealth()
    {
        bar.fillAmount = character.Health / (float)character.MaxHealth;
    }
}
