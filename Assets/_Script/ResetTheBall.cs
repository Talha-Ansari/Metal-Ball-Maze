using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ResetTheBall : MonoBehaviour
{
    Transform currentObj;
    [SerializeField] Transform target;
    [SerializeField] float jumpPower, jumpDuration;

    // Start is called before the first frame update


    void ResetPosition()
    {
        currentObj.DOLocalJump(target.localPosition, jumpPower, 1, jumpDuration).OnComplete(() => { ToggleTarget(false); });
    }
    void ToggleTarget(bool active)
    {

        currentObj.GetComponent<Rigidbody>().isKinematic = active;

    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            currentObj = other.transform;
            ToggleTarget(true);
            ResetPosition();

        }
    }
}
