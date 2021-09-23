using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    /*Alexander Iniguez Septiembre 2021
     * Controla la barra de vida con referencias de Resources
     */

    public int maxHealth;
    public int currentHealth;

    public Image bar;

    Resources resources;

    void Start()
    {
        resources = Resources.Instance; //Una referencias para las 
        resources.healthBar = this; //Decirle que esta es la barra
    }

    void Update()
    {
        //Debo cambiarlo
        //Ya que la vida es un int se debe hacer un casteo para asi poder tener numero flotantes para el fillAmount
        bar.fillAmount = currentHealth / (float)maxHealth; //actualizacion de la barra de vida dividimos lo que hay y el maximo y nos da un porcentaje
    }


}
