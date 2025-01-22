using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Trap : MonoBehaviour
{
    [SerializeField] Transform endPoint;
    [SerializeField] float activeDuration = 1, deactiveDuration = 5;
    [SerializeField] Vector3 startPoz;
    private void Start()
    {
        startPoz = transform.localPosition;
    }
    public void ActivateTrap()
    {
        transform.DOKill();
        Debug.Log("Activate Trap");
        transform.DOLocalMove(endPoint.localPosition, activeDuration);

    }

    public void DeactiveTrap()
    {
        Debug.Log("Deactivate Trap");

        transform.DOKill();
        transform.DOLocalMove(startPoz, deactiveDuration);

    }
}
