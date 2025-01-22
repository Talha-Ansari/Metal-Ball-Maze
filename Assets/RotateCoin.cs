using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class RotateCoin : MonoBehaviour
{
    [SerializeField] float duration;
    [SerializeField] bool rotate = false;
    // Start is called before the first frame update
    void Start()
    {
        if (rotate)
            transform.DOLocalRotate(new Vector3(0, 360, 0), duration, RotateMode.LocalAxisAdd).SetLoops(-1).SetEase(Ease.Linear);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transform.DOKill();
            Destroy(gameObject);
        }
    }
}
