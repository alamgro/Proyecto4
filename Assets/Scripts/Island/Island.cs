using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

[SelectionBase]
public class Island : MonoBehaviour
{
    [HideInInspector]
    public ManagerIsland managerIsland;

    [SerializeField] private float speed = 0f;
    [Tooltip("Time in minutes")]
    [MinMaxSlider(0.1f, 10f)]
    [SerializeField] private Vector2 rangeTimeToBeLanded; //Time that will be landed (in minutes) 
    [Header("Robot spawn parameters")]
    [Range(0, 100)]
    [SerializeField] private int spawnRobotProbability;
    [SerializeField] private Transform robotPosition;
    [SerializeField] private GameObject pfbRobot;
    private float timeToBeLanded;
    private int ocupiedPosition;
    private float currentTimeLanded = 0f;
    private Vector3 targetPos;
    private bool islandArrived = false;
    private const float distanceToDispear = 50f;

    private void Awake()
    {
        targetPos = transform.position;
    }

    private void Start()
    {
        managerIsland.CurrentActiveIslands++;
        timeToBeLanded = 60f * Random.Range(rangeTimeToBeLanded.x, rangeTimeToBeLanded.y); //Multiplied by 60 because it is time in minutes
    }

    void Update()
    {
        if(transform.position != TargetPos && !islandArrived)
        {
            transform.position = Vector3.MoveTowards(transform.position, TargetPos, speed * Time.deltaTime);

            if(Vector3.Distance(transform.position, targetPos) < 0.01f)
            {
                TryGenerateRobot();
                //Change to true, so the island stop moving
                islandArrived = true;
                print("Island arrived");
            }
        }
        else
        {
            if (currentTimeLanded >= timeToBeLanded)
            {
                print("La isla se debe de ir...");
                StartCoroutine(TakeOffIsland());
                this.enabled = false;
            }
            else
            {
                currentTimeLanded += Time.deltaTime;
                //print(currentTimeLanded);
            }
        }

        
    }


    //Generates a robot based on a probability
    [Button("Try Generate Robot")]
    private void TryGenerateRobot()
    {
        if (Random.Range(0, 101) <= spawnRobotProbability)
        {
            if(pfbRobot)
                Instantiate(pfbRobot, robotPosition.position, robotPosition.rotation);
        }
    }

    //Move island down and then destroy it
    private IEnumerator TakeOffIsland()
    {
        while(transform.position.y >= -distanceToDispear)
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
    }

    public Vector3 TargetPos { get { return targetPos; } set { targetPos = value; } }

    public int OcupiedPosition { get { return ocupiedPosition; } set { ocupiedPosition = value; } }


    private void OnDestroy()
    {
        managerIsland.ocupiedIslandPositions[OcupiedPosition] = false;
        managerIsland.CurrentActiveIslands--;
    }
}
