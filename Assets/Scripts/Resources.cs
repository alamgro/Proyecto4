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
    public Ship ship;
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

    public void RemoveHalfResources()
    {
        wood = Mathf.RoundToInt(wood / 2f);
        food = Mathf.RoundToInt(food / 2f);
        junk = Mathf.RoundToInt(junk / 2f);
        plastic = Mathf.RoundToInt(plastic / 2f);
        UpdateUI();
        print("> Half of resources were removed.");
    }

    //funtion subtract becouse is the cost for upgrate ship
    public void SubtractResources(int _wood, int _food, int _junk, int _plastic)
    {
        wood -= _wood;
        food -= _food;
        junk -= _junk;
        plastic -= _plastic;
         
        //update UI 
        managerUI.UpdateUI(); //Funcion lanzada desde el MangerUI
        //recursor del player
        //lo que hay guardado
        //
    }

    //almacena el total materiales
    //Los dados

    public void ComprovacionDeREcursos( )
    {
        //lo que se ha dado lo conoce ship
        //maximo requerido = int
        /*
         * maxToRemove = int
         * 
         * 
         */
        int maxRemove; //el tota a quitar

        #region Wood
        maxRemove = ship.availableFaces[ship.CurrentFaceIndex].woodRequired - ship.StoredWood;

        //madera > necesitamosMAdera

        if( maxRemove > Wood)
        {
            maxRemove = Wood;
        }

        ship.StoredWood += maxRemove;
        Wood -= maxRemove;
        #endregion


        #region Junk
        maxRemove = ship.availableFaces[ship.CurrentFaceIndex].junkRequired - ship.StoredJunk;

        if (maxRemove > Junk)
        {
            maxRemove = Junk;
        }

        ship.StoredJunk += maxRemove;
        Junk -= maxRemove;
        #endregion

        #region Plastic
        maxRemove = ship.availableFaces[ship.CurrentFaceIndex].plasticRequired - ship.StoredPlastic;

        if (maxRemove > Plastic)
        {
            maxRemove = Plastic;
        }

        ship.StoredPlastic += maxRemove;
        Plastic -= maxRemove;
        #endregion



        managerUI.UpdateUI(); //Funcion lanzada desde el MangerUI

    }

    #region SET&GET
    public int Food
    {
        get { return food; }
        //Food => food 

        set
        {
            food = value;

            if (food < 0 )
            {
                food = 0;
            }
        }
    }

    public int Wood
    {
        get { return wood; }
        //Food => food 

        set
        {
            wood = value;

            if (wood < 0)
            {
                wood = 0;
            }
        }
    }
    public int Junk
    {
        get { return junk; }
        //Food => food 

        set
        {
            junk = value;

            if (junk < 0)
            {
                junk = 0;
            }
        }
    }

    public int Plastic
    {
        get { return plastic; }
        //Food => food 

        set
        {
            plastic = value;
            if (plastic < 0)
            {
                plastic = 0;
            }
        }
    }
    #endregion


}//end class
