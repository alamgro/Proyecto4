using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShooter : MonoBehaviour
{
    [SerializeField] private GameObject pfbArrow; //Arrow prefab
    [SerializeField] private float spawnTime;

    void Start()
    {
        StartCoroutine(Spawn(spawnTime));
    }

    void Update()
    {
        
    }

    private IEnumerator Spawn(float _spawnTime)
    {
        yield return new WaitForSecondsRealtime(_spawnTime);
        //NECESITO COMPROBAR LA DIRECCIÓN DE LA FLECHA ***
        Instantiate(pfbArrow, transform.position, Quaternion.identity);
        StartCoroutine(Spawn(_spawnTime));

    }
}
