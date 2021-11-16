using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnLoot : MonoBehaviour
{

    /* Alexander Iniguez November, 2021
     * Put loot with ratio of one collider, respawn type of you put
     * Collider trigger
     */
    [SerializeField] private Collider Collider;
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
        Vector3 position;
        float z , x;

        z = Random.Range(Collider.bounds.min.z, Collider.bounds.max.z);
        x = Random.Range(Collider.bounds.min.x, Collider.bounds.max.x);

        position = new Vector3(x, Collider.transform.position.y, z);

        return position;
    }

    public void InstanceLoot()
    {
        int indexLoot;
        if (lootsTypes.Length == 0)
        {
            indexLoot = 0;
        }
        else
        {
            indexLoot = Random.Range(0, lootsTypes.Length);
        }

        Instantiate(lootsTypes[indexLoot], InCollider(), Quaternion.identity);
    }
}
