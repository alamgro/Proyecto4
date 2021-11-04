using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class DayNigth : MonoBehaviour
{
    /*
    /* Alexander Iniguez October, 2021
     * Change state of day 
     * In light
     */

    private float timer;
    private float speed;
    public float durationDay; //in seconds 
    public bool isNight;
    private Light sunlight;
    public Color colorNight;
    public Color colorDay;
    
    public GameObject lights;

    void Start()
    {
        sunlight = GetComponent<Light>();
        speed = 360f / durationDay;
        isNight = false;

        lights.gameObject.SetActive(false);
    }

    void Update()
    {
        timer += Time.deltaTime;
        transform.Rotate(Vector3.right * speed * Time.deltaTime);

            //when the sun is in twilight
        if(timer >= durationDay/2f)
        {
            timer = 0f;
                //change because now is nitgh or day
            isNight = !isNight;
            transform.rotation = Quaternion.Euler(-5f, 0, 0); //new rotation

            lights.gameObject.SetActive(isNight);
            sunlight.color = isNight ? colorNight : colorDay;
        }
    }
}
