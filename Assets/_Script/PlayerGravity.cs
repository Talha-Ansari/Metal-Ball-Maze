using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    [SerializeField] float gravityMultiplay = 1;
    [SerializeField] Transform cameraOffsetObj;
    // Start is called before the first frame update
    [SerializeField] Vector3 offset = Vector3.one;
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        rb.AddForce(Vector3.down * gravityMultiplay * Time.deltaTime, ForceMode.VelocityChange);
    }
    void LateUpdate()
    {
        SetOffsetObjPosition();
    }


    void SetOffsetObjPosition()
    {

        cameraOffsetObj.transform.localPosition = offset + new Vector3(0, 0, transform.localPosition.z);
    }


}
