using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

//Por favor
public class ManagerIsland : MonoBehaviour
{
    [SerializeField] private float islandDistance = 0f;
    [InfoBox("Islands will be spawned looking to the Forward axis of the positions GameObjects", EInfoBoxType.Normal)]
    [SerializeField] private Transform[] islandPositions = null;
    [ShowAssetPreview(128, 128)]
    [SerializeField] private GameObject[] pfbIslands = null;
    private GameObject currentIsland;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            Spawn();
        }
    }

    private GameObject SpawnIsland()
    {
        int randIndex = Random.Range(0, islandPositions.Length); //Choose a random position where the island will land
        Vector3 randPosition = islandPositions[randIndex].position + (Vector3.up* islandDistance);

        int randIslandPfb = Random.Range(0, pfbIslands.Length); //Choose a random island prefab (small, medium or big)

        //Instantiate island and set its target position and rotation
        Island island = Instantiate(pfbIslands[randIslandPfb], randPosition , pfbIslands[randIslandPfb].transform.rotation).GetComponent<Island>();
        Collider islandCollider = island.GetComponent<Collider>();
        //Rotate island to the correct direction. (islandPositions has the rotation already set up)
        island.transform.rotation = islandPositions[randIndex].transform.rotation; 
        //Set the island Target Position with the necessary offset
        island.TargetPos = islandPositions[randIndex].position + (islandCollider.bounds.extents.z * -island.transform.forward); //

        return island.gameObject;
    }

    [Button("Spawn Island")]
    private void Spawn()
    {
        if (currentIsland)
            Destroy(currentIsland);
        currentIsland = SpawnIsland();
    }

}
