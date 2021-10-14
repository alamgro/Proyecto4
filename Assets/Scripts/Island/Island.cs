using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Island : MonoBehaviour
{
    [SerializeField] private float speed = 0f;
    private Vector3 targetPos;
    private bool islandArrived = false;


    void Update()
    {
        if(transform.position != TargetPos && !islandArrived)
        {
            transform.position = Vector3.MoveTowards(transform.position, TargetPos, speed * Time.deltaTime);
        }
        else
        {
            //Change to true, so the island stop moving
            //islandArrived = true;
            this.enabled = false;
        }
    }

    public Vector3 TargetPos { get { return targetPos; } set { targetPos = value; } }
}
