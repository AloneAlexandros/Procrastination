using System.Collections;
using NUnit;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Interactions : MonoBehaviour
{
    [FormerlySerializedAs("OnInteraction")] public UnityEvent onInteraction;
    [SerializeField] private bool mustBeClose = false;
    private bool _isInRange = false;
    private void OnMouseEnter()
    {
        if (!mustBeClose || _isInRange)
        {
            this.gameObject.GetComponent<Outline>().enabled = true;
        }
    }

    private void OnMouseExit()
    {
        if (!mustBeClose || _isInRange)
        {
            this.gameObject.GetComponent<Outline>().enabled = false;
        }
    }

    private void OnMouseDown()
    {
        if (!mustBeClose || _isInRange)
        {
            this.gameObject.GetComponent<Outline>().enabled = false;
            onInteraction.Invoke();
            Destroy(this.gameObject.GetComponent<Interactions>()); 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "PlayerCapsule")
        {
            _isInRange = true;
            OnMouseEnter();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "PlayerCapsule")
        {
            OnMouseExit();
            _isInRange = false;
        }
    }
}
