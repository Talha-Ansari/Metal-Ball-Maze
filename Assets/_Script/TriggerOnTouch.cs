using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerOnTouch : MonoBehaviour
{
    [SerializeField] string triggerTag;
    [SerializeField] UnityEvent action;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(triggerTag))
        {
            action?.Invoke();
        }
    }
}
