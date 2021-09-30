using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerUI : MonoBehaviour
{          
    /*Alexander Iniguez Septiembre, 2021
     * Manejar el UI del juego
     * Puede asignarse a un objeto vacio
     */

    //Referencias a cada cantidad
    public TMPro.TextMeshProUGUI food;
    public TMPro.TextMeshProUGUI wood;
    public TMPro.TextMeshProUGUI plastic;
    public TMPro.TextMeshProUGUI junk;

    Resources resources;

    void Start()
    {
        resources = Resources.Instance;
        resources.managerUI = this;
        resources.UpdateUI();
        //junk.text = resources.wood.ToString();
    }

    public void UpdateUI() //Mandamos todo para hacerlo mas facil y no es pesado
    {
        junk.text = resources.junk.ToString();
        food.text = resources.food.ToString();
        wood.text = resources.wood.ToString();
        plastic.text = resources.plastic.ToString();
    }
}
