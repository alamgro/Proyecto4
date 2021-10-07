using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


/* Alexander Iniguez Septiembre, 2021
*  Change pov of Main Camera  and follow player, child of PfbCameraPlayer
*  Pivot who will follow.
*/

public class RotationCamera : MonoBehaviour
{
    public GameObject player;
    public int rotationToAdd;
    //public CinemachineVirtualCamera camVirtual;
    //public CinemachineOrbitalTransposer camOrvitsl;



    void Update()
    {
        //camOrvitsl.m_Heading.m_Definiti = 0;
        //equalize position pivot and player
        transform.position = player.transform.position;

        //condition for chenge angle pivot
        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.Rotate(Vector3.up * rotationToAdd);

            //Que haga lo que tenga que hacer
            //camVirtual.GetCinemachineComponent<CinemachineComposer>().m_BiasY = 0;
        }

        //condition for chenge angle pivot
        if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.Rotate(Vector3.up * (360f -rotationToAdd));
        }
    }
}
