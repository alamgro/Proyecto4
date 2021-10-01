using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private float initialSpeed;
    [SerializeField] private int initialDamage; //Damage of the arrow
    [SerializeField] private float despawnTime;
    private int currentDamage;
    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();

        currentDamage = initialDamage;
    }

    void OnEnable()
    {
        Invoke(nameof(TurnOffArrow), despawnTime); //Turn off arrow after certain time
    }

    public void Throw(Vector3 _direction)
    {
        //Stop arrow
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        //Throw arrow
        rb.AddForce(_direction * initialSpeed);
    }

    private void TurnOffArrow()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Check if the collisioned object has the ICharacter component, meaning that it can take damage
        ICharacters characters = collision.gameObject.GetComponent<ICharacters>() ;
        Debug.Log(collision.gameObject, collision.gameObject);
        if (characters != null)
        {
            characters.TakeDamage(currentDamage);
        }
    }

}
