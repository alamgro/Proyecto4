using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class Trap : MonoBehaviour
{
    [Header("Spawn configuration")]
    [SerializeField] private int amountTraps = 1; //The total amount of traps in the island

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

    void Start()
    {
        //Spawn traps
        for (int i = 0; i < amountTraps; i++)
        {
            //spawn
        }
    }

    void Update()
    {
        
    }

    private void SpawnSpikes()
    {
        Spikes _spikes = Instantiate(spikesData.pfbTrap).GetComponent<Spikes>();
        _spikes.transform.localRotation = Quaternion.identity;
    }
    
    private void SpawnTurret()
    {

    }

}
