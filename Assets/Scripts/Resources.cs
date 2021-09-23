using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Item //Tipos de recursos que hay 
{
    wood,
    food,
    junk,
    plastic
}

public class Resources : MonoBehaviour
{
    /* Alexander Iniguez Septiembre, 2021
     * Manejara como un singleton los recursos del juego, se podra aumentar y desminuir ademas de leer sus datos
     * No debe de ser asignado a nada, se crea por si solo
     */

    static Resources instance;
    public HealthBar healthBar;
    public ManagerUI managerUI;
    public int wood;
    public int food;
    public int junk;
    public int plastic;

    //Seguridad para que no puedan modificar solo leer
    public static Resources Instance
    {
        get
        {
            return instance;
        }
    }

    [RuntimeInitializeOnLoadMethod] //Se llama cuando inicia el juego, solo afecta la primera funcion de abajo de ella
    static void AutoCreate()
    {
        instance = new GameObject("Resources").AddComponent<Resources>();
        DontDestroyOnLoad(instance.gameObject);
    }

    public void UpdateUI() 
    {
        managerUI.UpdateUI(); //Funcion lanzada desde el MangerUI
    }

    /*public void AddResource()
    {

    }*/
}
