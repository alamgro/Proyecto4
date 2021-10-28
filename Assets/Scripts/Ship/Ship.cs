using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{

    [SerializeField] private float delayToInteract;
    private float timerInteraction = 0f;
    private bool canInteract;
    private Color originalColor;
    private MeshRenderer meshRenderer;
    [SerializeField] private Collider colliderInteraction;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        originalColor = meshRenderer.material.color;
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

}
