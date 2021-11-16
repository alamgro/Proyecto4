using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallLootShip : MonoBehaviour
{
    /* Alexander Iniguez November, 2021
     * When fall this ship, it will crash in the main island like a loot
     * Some ship
     */

    private Rigidbody rb;
    private MeshFilter filter;
    [SerializeField] private MeshFilter[] meshes;
    private int index;
    //[SerializeField] private Transform ground;
    [SerializeField] private Vector2Int lootRange; //minimun and maximum range of the loot when it dies
    [SerializeField] private AudioClip audioPop;
    [SerializeField] private GameObject[] pfbResources;
    private bool boom;
    private float timer;
    private float timeToBoom;

    void Start()
    {
        filter = GetComponent<MeshFilter>();
        rb = GetComponent<Rigidbody>();
        index = Random.Range(0, meshes.Length);
        filter.sharedMesh = meshes[index].sharedMesh;
        transform.LookAt(Vector3.down);
        print(filter.mesh);
        timeToBoom = Random.Range(2, 6);
    }

    private void OnCollisionEnter(Collision collision)
    {
        boom = true;
        rb.isKinematic = true;
    }

    private void Update()
    {
        if(boom)
        {
            timer += Time.deltaTime;
            if (timer > timeToBoom)
                Die();
        }
    }

    void Die()
    {
        int randLootAmount = Random.Range(lootRange.x, lootRange.y + 1); //Get random amount of resources to be droped
        Rigidbody tempRb;
        for (int i = 0; i < randLootAmount; i++)
        {
            int randIndex = Random.Range(0, pfbResources.Length); //Random resourse
            //print(randIndex);
            tempRb = Instantiate(pfbResources[randIndex], transform.position, Random.rotation).GetComponent<Rigidbody>();
            tempRb.AddExplosionForce(50f, transform.position + Random.insideUnitSphere, 1f);
            AudioSource.PlayClipAtPoint(audioPop, transform.position);
        }
        Destroy(gameObject);
    }
}
