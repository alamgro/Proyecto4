using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [System.Serializable]
    public class Fase
    {
        public int faseNumber = 1;
        public int woodRequired;
        public int junkRequired;
        public int plasticRequired;
    }

    [SerializeField] private float delayToInteract; //The time that takes to complete an interaction
    [SerializeField] private Collider colliderInteraction;
    [SerializeField] private Fase[] availableFaces = new Fase[3];
    private float timerInteraction = 0f;
    private bool canInteract;
    private int currentFaceIndex = 0;
    private int storedWood = 0, storedJunk = 0, storedPlastic = 0; //Current amount of resources used in the ship
    private Color originalColor;
    private MeshRenderer meshRenderer;
    private Resources resources;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();

        originalColor = meshRenderer.material.color;
        resources = Resources.Instance;
        resources.ship = this;
    }

    void Update()
    {
        if (!canInteract)
            return;

        if (Input.GetButton(K.Input.interact))
        {
            meshRenderer.material.color = Color.cyan;

            timerInteraction += Time.deltaTime;
            if (timerInteraction >= delayToInteract)
            {
                timerInteraction = 0f;
                meshRenderer.material.color = Color.green;
                Debug.Log("Nave reparada", gameObject);
                //Lógica de agregar recursos a la nave
            }
        }
        if (Input.GetButtonUp(K.Input.interact))
        {
            timerInteraction = 0f;
            meshRenderer.material.color = originalColor;
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, colliderInteraction.bounds.extents.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(K.Tag.player))
            canInteract = true;  //is inside
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(K.Tag.player))
            canInteract = false;  //is out
    }

    private void UpdateStoredResources()
    {
        Resources resources = Resources.Instance;
        /*
        storedWood += resources.wood;
        storedJunk += resources.junk;
        storedPlastic += resources.plastic;
        */
        resources.managerUI.UpdateUI();
    }

    private bool CheckFaseChange()
    {
        //CHECAR SI CAMBIA LA FASE
        //if(wood >=)

        currentFaceIndex++;
        return true;
    }

    public int StoredWood { get; set; }

    public int StoredJunk { get; set; }

    public int StoredPlastic { get; set; }

    public int CurrentFaceIndex { get; set; }
}
