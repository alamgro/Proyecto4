using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    /*Alexander Iniguez Septiembre 2021
     * Controla la barra de vida con referencias de Resources
     */

    /*
     *necesito saber cual es el player
     *funcion del player de actualizar la barra
     */


    public int maxHealth;
    public int currentHealth;
    public Player player;

    public Image bar;

    Resources resources;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        ///
        player.healthBar = this;

        resources = Resources.Instance; //Una referencias para las 
        resources.healthBar = this; //Decirle que esta es la barra
    }

    void Update()
    {
        //Debo cambiarlo
        //Ya que la vida es un int se debe hacer un casteo para asi poder tener numero flotantes para el fillAmount
        //bar.fillAmount = currentHealth / (float)maxHealth; //actualizacion de la barra de vida dividimos lo que hay y el maximo y nos da un porcentaje
    }

    public void UpdateHealth()
    {
        bar.fillAmount = player.Health / (float)player.MaxHealth;
        //print(bar.fillAmount + "  bar.fillAmount");
        //print(player.Health + " Health");
        print(player.Health + " /  " + ((float)player.MaxHealth) + " = " + bar.fillAmount);


    }
}
