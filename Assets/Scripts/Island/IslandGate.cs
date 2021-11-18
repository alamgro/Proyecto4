using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class IslandGate : MonoBehaviour
{

    [SerializeField] private Collider colliderGate;
    [SerializeField] private float duration;
    private float targetY;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(K.Tag.player))
        {
            OpenGate();
        }
    }

    private void OpenGate()
    {
        targetY = transform.position.y - colliderGate.bounds.size.y - 0.25f;
        transform.parent.DOMoveY(targetY, duration); //Move gate
    }
}
