using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowUIRobot : MonoBehaviour
{
    /* Alexander Iniguez October 2021
     * UI robot your life. look the camera 
     * each robot*
     */

    public int maxHealth;
    public int currentHealth;
    public Image bar;

    Camera cam;
    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        transform.LookAt(cam.transform.position);
    }

    /*public void UpdateHealtBarRobot()
    {
        // bar.fillAmount = robot.Health / (float)robot.MaxHealth;

    }*/

}
