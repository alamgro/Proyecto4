using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New robot", menuName = "Robot")  ]
public class RobotParameters : ScriptableObject
{
    /* Alexander Iniguez November, 2021
     * 
     */

    public int healt;
    public float speed;
    public float demangeMin;
    public float demangeMax;
    public float stunTime;



    //rigid
    /*
    public float drag;
    public float mass;
    */

}
