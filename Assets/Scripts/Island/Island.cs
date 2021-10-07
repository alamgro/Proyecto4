using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Island : MonoBehaviour
{
    [SerializeField] private float speed;
    private Transform targetPos;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, TargetPos.position, 1.0f);
    }

    public Transform TargetPos { get; set; }
}
