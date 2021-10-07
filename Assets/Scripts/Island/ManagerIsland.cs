using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Por favor
public class ManagerIsland : MonoBehaviour
{
    [SerializeField] private float islandDistance = 0f;
    [SerializeField] private Transform[] islandPositions = null;
    [SerializeField] private GameObject pfbIsland = null;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            SpawnIsland(pfbIsland);
        }
    }

    private void SpawnIsland(GameObject _pfbIsland)
    {
        int randIndex = Random.Range(0, islandPositions.Length);
        Vector3 randPosition = islandPositions[randIndex].position + (Vector3.up* islandDistance);

        Instantiate(_pfbIsland, randPosition , pfbIsland.transform.rotation);
    }

}
