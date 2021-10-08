using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNigth : MonoBehaviour
{
    /*
    /* Alexander Iniguez October, 2021
     * 
     */

    public float timer;
    public float speed;
    public float durationDay; //in seconds 
    public bool isNight;
    private Light light;
    public Color colorNight;
    public Color colorDay;
    public Light[] lights;

    void Start()
    {
        light = GetComponent<Light>();
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].gameObject.SetActive(false);
        }
        speed = 360f / durationDay;
        isNight = false;
    }

    void Update()
    {
        timer += Time.deltaTime;
        transform.Rotate(Vector3.right * speed * Time.deltaTime);


        //if()

            //when the sun is in twilight
        if(timer >= durationDay/2f+2f)
        {
            timer = 0f;
                //change because now is nitgh or day
            isNight = !isNight;
            transform.rotation = Quaternion.Euler(-5f, 0, 0); //new rotation
            if(isNight)
            {
                light.color = colorNight;
                for(int i =0; i<lights.Length; i++)
                {
                    lights[i].gameObject.SetActive(true);
                }
            }
            else
            {
                light.color = colorDay;

                for (int i = 0; i < lights.Length; i++)
                {
                    lights[i].gameObject.SetActive(false);
                }
            }
        }
    }
}
