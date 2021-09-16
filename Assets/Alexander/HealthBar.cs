using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{           //ManagerUI
    /*Alexander Iniguez Septiembre, 2021
     * Manejar el UI del juego, 
     * 
     */


    public int maxHealth;
    public int currentHealth;

    public Image bar;

    //Referencias a cada cantidad
    public TMPro.TextMeshProUGUI food;
    public TMPro.TextMeshProUGUI wood;
    public TMPro.TextMeshProUGUI plastic;
    public TMPro.TextMeshProUGUI junk;

    Resources resources;

    void Start()
    {
        resources = Resources.Instance; //Una referencias para las 

        junk.text = resources.wood.ToString();
        resources.healthBar = this; //

    }

    void Update()
    {
        
    }


    //funcion void
    public void UpdateHealthBar()
    {
        junk.text = resources.wood.ToString();
        food.text = resources.wood.ToString();
        wood.text = resources.wood.ToString();
        plastic.text = resources.wood.ToString();
    }
}
