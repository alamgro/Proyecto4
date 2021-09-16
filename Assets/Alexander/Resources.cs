using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Item
{
    wood,
    food,
    junk,
    plastic
}

public class Resources : MonoBehaviour
{
    /*Alexander Iniguez Septiembre, 2021
     * Manejara como un singleton los recursos del juego, se podra aumentar y desminuir ademas de leer sus datos
     * 
     */

    static Resources instance;
    public HealthBar healthBar;

    //Seguridad para que no puedan modificar solo leer
    public static Resources Instance
    {
        get
        {
            return instance;
        }
    }


    public int wood;
    public int food;
    public int junk;
    public int plastic;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    [RuntimeInitializeOnLoadMethod]

    static void AutoCreate()
    {
        instance = new GameObject("Resources").AddComponent<Resources>();
        DontDestroyOnLoad(instance.gameObject);
    }

    public void UpdateHealthBar()
    {
        healthBar.UpdateHealthBar();
    }

    public void AddResource()
    {

    }
}
