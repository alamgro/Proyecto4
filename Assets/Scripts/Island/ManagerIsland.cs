using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

//Por favor
public class ManagerIsland : MonoBehaviour
{
    [SerializeField] private float islandDistance = 0f;
    [SerializeField] private Transform[] islandPositions = null;
    [ShowAssetPreview(128, 128)]
    [SerializeField] private GameObject pfbIsland = null;
    private GameObject currentIsland;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            if (currentIsland)
                Destroy(currentIsland);
            currentIsland = SpawnIsland(pfbIsland);
        }
    }

    private GameObject SpawnIsland(GameObject _pfbIsland)
    {
        int randIndex = Random.Range(0, islandPositions.Length);
        Vector3 randPosition = islandPositions[randIndex].position + (Vector3.up* islandDistance);

        //Instantiate island and set its target position and rotation
        Island island = Instantiate(_pfbIsland, randPosition , pfbIsland.transform.rotation).GetComponent<Island>();
        Collider islandCollider = island.GetComponent<Collider>();
        //Rotate island to the correct direction. (islandPositions has the rotation already set up)
        island.transform.rotation = islandPositions[randIndex].transform.rotation; 
        //Set the island Target Position with the necessary offset
        island.TargetPos = islandPositions[randIndex].position + (islandCollider.bounds.extents.z * -island.transform.forward); //

        return island.gameObject;
    }

}
