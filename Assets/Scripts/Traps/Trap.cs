using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class Trap : MonoBehaviour
{
    [Header("Traps to spawn")]
    [SerializeField] private bool spikes = false;
    [SerializeField] private bool turret = false;

    [Space]
    [ShowIf("spikes")]
    [SerializeField] private SpikesData spikesData;
    [Space]
    [ShowIf("turret")]
    [SerializeField] private TurretData turretData;

    [System.Serializable]
    public struct SpikesData
    {
        public GameObject pfbTrap;
        public float offsetY;
        public float rotationY;
        //Opción para poner sus atributos al instanciarlo (velocidad, delay, etc.)
    }

    [System.Serializable]
    public struct TurretData
    {
        public GameObject pfbTrap;
        public float offsetY;
        public float rotationY;
        public float speed;
        //Opción para poner sus atributos al instanciarlo (cadencia, delay, etc.)
    }

    private enum TrapType { SPIKES, TURRET};

    void Start()
    {
        List<TrapType> spawnList = new List<TrapType>();
        if (spikes)
            spawnList.Add(TrapType.SPIKES);
        if (turret)
            spawnList.Add(TrapType.TURRET);

        if (spawnList.Count < 1)
            return;

        int randIndex = Random.Range(0, spawnList.Count);
        TrapType trapToSpawn = spawnList[randIndex];

        switch (trapToSpawn)
        {
            case TrapType.SPIKES:
                SpawnSpikes();
                break;
            case TrapType.TURRET:
                SpawnTurret();
                break;
            default:
                break;
        }
    }

    private void SpawnSpikes()
    {
        Spikes _spikes = Instantiate(spikesData.pfbTrap, transform.position, Quaternion.identity).GetComponent<Spikes>(); //Instantiate
        _spikes.transform.SetParent(transform); //set parent
        _spikes.transform.position += Vector3.up * spikesData.offsetY; //Set position
        _spikes.transform.rotation = Quaternion.Euler(Vector3.up * spikesData.rotationY); //Set rotation
    }
    
    private void SpawnTurret()
    {
        ArrowShooter _turret = Instantiate(turretData.pfbTrap, transform.position, Quaternion.identity).GetComponent<ArrowShooter>(); //Instantiate
        _turret.transform.SetParent(transform); //set parent
        _turret.transform.position += Vector3.up * turretData.offsetY; //Set position
        _turret.transform.rotation = Quaternion.Euler(Vector3.up * turretData.rotationY); //Set rotation
    }

}
