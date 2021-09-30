using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private float initialSpeed;
    [SerializeField] private float despawnTime;
    private Rigidbody rb;
    private Vector3 direction;

    IEnumerator Start()
    {
        rb = GetComponent<Rigidbody>();
        print(direction);
        rb.AddForce(direction * initialSpeed);

        yield return new WaitForSecondsRealtime(despawnTime);
        Destroy(gameObject);
    }

    public Vector3 Direction {
        get { return direction; } 
        set { direction = value; }
    }

}
