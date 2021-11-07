using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

[SelectionBase]
public class Island : MonoBehaviour
{
    [SerializeField] private float speed = 0f;
    [Header("Robot spawn parameters")]
    [Range(0, 100)]
    [SerializeField] private int spawnRobotProbability;
    [SerializeField] private Transform robotPosition;
    [SerializeField] private GameObject pfbRobot;
    private Vector3 targetPos;
    private bool islandArrived = false;

    private void Awake()
    {
        targetPos = transform.position;
    }

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
            TryGenerateRobot();
            this.enabled = false;
        }
    }


    //Generates a robot based on a probability
    [Button("Try Generate Robot")]
    private void TryGenerateRobot()
    {
        if (Random.Range(0, 101) <= spawnRobotProbability)
        {
            GameObject _robot = Instantiate(pfbRobot, robotPosition.position, robotPosition.rotation);
        }
    }

    public Vector3 TargetPos { get { return targetPos; } set { targetPos = value; } }
}
