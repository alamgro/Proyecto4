using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using System.Threading.Tasks;

//Por favor
public class ManagerIsland : MonoBehaviour
{
    [HideInInspector]
    public bool[] ocupiedIslandPositions;

    [SerializeField] private float islandDistance = 0f;
    [SerializeField] private int maxActiveIslands; //The max number of islands that can exists
    [Tooltip("Time in minutes")]
    [SerializeField] private float spawnCooldown;
    [InfoBox("Debug: if this is true, the island will automatically spawn.", EInfoBoxType.Normal)]
    [SerializeField] private bool manualSpawn;
    [InfoBox("Islands will be spawned looking to the Forward axis of the positions GameObjects", EInfoBoxType.Normal)]
    [SerializeField] private Transform[] islandPositions = null;
    [ShowAssetPreview(128, 128)]
    [SerializeField] private GameObject[] pfbIslands = null;
    private int currentActiveIslands = 0;

    private void Start()
    {
        ocupiedIslandPositions = new bool[islandPositions.Length];
        spawnCooldown *= 60f; //Convert to minutes

        if (!manualSpawn)
            SpawnIslands();
    }

    public async void SpawnIslands()
    {
        float end = Time.time + spawnCooldown;
        while(Time.time < end)
        {
            await Task.Yield();
        }

        int randAmount = Random.Range(1, maxActiveIslands + 1);
        //print(randAmount);
        int islandLeft = islandPositions.Length - currentActiveIslands;
        //Avoid generating more island than the positions left in the array
        randAmount = randAmount > islandLeft ? islandLeft : randAmount;
        print(randAmount);

        for (int i = 0; i < randAmount; i++)
        {
            print("Generating island: #" + i);
            GenerateIsland();
        }
        SpawnIslands();
    }

    [Button("Spawn Island")]
    private void GenerateIsland()
    {
        if (currentActiveIslands >= islandPositions.Length)
            return;

        int randIndex;
        do
        {
            randIndex = Random.Range(0, islandPositions.Length); //Choose a random position where the island will land
        } while (ocupiedIslandPositions[randIndex] == true);

        ocupiedIslandPositions[randIndex] = true;

        Vector3 randPosition = islandPositions[randIndex].position + (Vector3.up * islandDistance);

        int randIslandPfb = Random.Range(0, pfbIslands.Length); //Choose a random island prefab (small, medium or big)

        //Instantiate island and set its target position and rotation
        Island island = Instantiate(pfbIslands[randIslandPfb], randPosition, pfbIslands[randIslandPfb].transform.rotation).GetComponent<Island>();

        island.OcupiedPosition = randIndex;

        //set the reference of ManagerIsland from Island script
        island.managerIsland = this;

        //Rotate island to the correct direction. (islandPositions has the rotation already set up)
        island.transform.rotation = islandPositions[randIndex].transform.rotation; 

        //Set the island Target Position with the necessary offset
        Collider islandCollider = island.GetComponent<Collider>();
        island.TargetPos = islandPositions[randIndex].position + (islandCollider.bounds.extents.z * -island.transform.forward); //
    }

    public int CurrentActiveIslands { get => currentActiveIslands; set => currentActiveIslands = value; }

}
