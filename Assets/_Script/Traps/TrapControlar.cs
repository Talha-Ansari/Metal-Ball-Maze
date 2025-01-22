using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TrapControlar : MonoBehaviour
{
    [SerializeField] UnityEvent onEnter;
    [SerializeField] UnityEvent onExit;
    [SerializeField] string targetTag;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))

            onEnter?.Invoke();

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(targetTag))

            onExit?.Invoke();
    }
}
