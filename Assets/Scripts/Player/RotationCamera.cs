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

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        //camOrvitsl.m_Heading.m_Definiti = 0;
        //equalize position pivot and player
        transform.position = player.transform.position;

        #region CHANGE PIVOT ANGLE
        if (Input.GetButtonDown(K.Input.rotateRight))
        {
            transform.Rotate(Vector3.up * (360f + rotationToAdd));
        }

        if (Input.GetButtonDown(K.Input.rotateLeft))
        {
            transform.Rotate(Vector3.up * (360f - rotationToAdd));
        }
        #endregion
    }
}
