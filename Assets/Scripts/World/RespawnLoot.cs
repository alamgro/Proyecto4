using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class RespawnLoot : MonoBehaviour
{

    /* Alexander Iniguez November, 2021
     * Put loot with ratio of one collider, respawn type of you put
     * Collider trigger
     */
    [SerializeField] private Collider colliderSpawn;
    [ValidateInput("ValidateLootTypes", "The array can't be empty")]
    [SerializeField] private GameObject[] lootsTypes;
    private float timer;
    [SerializeField] private float timeToRespawn;
   // [SerializeField] private bool isPermanent;

    // Start is called before the first frame update
    void Start()
    {
            timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > timeToRespawn)
        {
            timer = 0;
            InstanceLoot();
        }
    }

    private Vector3 InCollider()
    {
        Vector3 pos;

        pos.x = Random.Range(colliderSpawn.bounds.min.x, colliderSpawn.bounds.max.x);
        pos.y = colliderSpawn.transform.position.y + colliderSpawn.bounds.center.y;
        pos.z = Random.Range(colliderSpawn.bounds.min.z, colliderSpawn.bounds.max.z);

        print(pos);
        return pos;
    }

    public void InstanceLoot()
    {
        int indexLoot;
        indexLoot = Random.Range(0, lootsTypes.Length);
        Instantiate(lootsTypes[indexLoot], InCollider(), Quaternion.identity);
    }

    //Shows an alert in the inspector if the LootsTypes array is empty
    private bool ValidateLootTypes(GameObject[] _array)
    {
        return _array.Length > 0;
    }
}
