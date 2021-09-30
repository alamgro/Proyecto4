using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ArrowShooter : MonoBehaviour
{
    [SerializeField] private GameObject pfbArrow; //Arrow prefab
    [SerializeField] private float spawnTime;
    WaitForSecondsRealtime wait;

    void Start()
    {
        wait = new WaitForSecondsRealtime(spawnTime); //Store WaitForSeconds to avoid generating garbage
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        //Infinite arrow spawner
        while (true)
        {
            yield return wait;
            GameObject go = Instantiate(pfbArrow, transform.position, transform.rotation); //Spawn object in the right direction
            go.GetComponent<Arrow>().Direction = transform.forward; //Set shot direction (same as the arrow shooter)
        }
    }
}
