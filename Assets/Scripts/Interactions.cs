using System.Collections;
using NUnit;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Interactions : MonoBehaviour
{
    [FormerlySerializedAs("OnInteraction")] public UnityEvent onInteraction;
    private void OnMouseEnter()
    {
        this.gameObject.GetComponent<Outline>().enabled = true;
    }

    private void OnMouseExit()
    {
        this.gameObject.GetComponent<Outline>().enabled = false;
    }

    private void OnMouseDown()
    {
        this.gameObject.GetComponent<Outline>().enabled = false;
        onInteraction.Invoke();
        Destroy(this.gameObject.GetComponent<Interactions>());
    }
}
