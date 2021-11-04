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
    public Fase[] availableFaces = new Fase[3];

    [SerializeField]
    private int storedWood = 0, storedJunk = 0, storedPlastic = 0; //Current amount of resources used in the ship
    [SerializeField] private float delayToInteract; //The time that takes to complete an interaction
    [SerializeField] private Collider colliderInteraction;
    private float timerInteraction = 0f;
    
    private bool canInteract;
    [SerializeField] private int currentFaceIndex = 0; //CUIDAR QUE NO SE PASE DEL INDEX MÁXIMO
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
                resources.CheckAndSubstractResource();
                //Check if the fase changed with the resources added
                CheckFaseChange();
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

    private void CheckFaseChange()
    {
        //Validate if it already has the necessary resources to change to the next face
       if(storedWood >= availableFaces[currentFaceIndex].woodRequired
            && storedJunk >= availableFaces[currentFaceIndex].junkRequired
            && storedPlastic >= availableFaces[currentFaceIndex].plasticRequired)
        {
            storedWood = storedJunk = storedPlastic = 0; //Reset stored resources

            //Check wheather it is a fase change, if it hits the maximum fase, the game is finished
            if(currentFaceIndex < availableFaces.Length - 1)
            {
                Debug.LogWarning("Cambio de fase.");
                currentFaceIndex++;
            }
            else
                GameManager.Instance.GameFinished();

        }
    }

    public int StoredWood { get { return storedWood; } set { storedWood = value; } }

    public int StoredJunk { get { return storedJunk; } set { storedJunk = value; } }

    public int StoredPlastic { get { return storedPlastic; } set { storedPlastic = value; } }

    public int CurrentFaceIndex { get { return currentFaceIndex; } set { currentFaceIndex = value; } }

}
