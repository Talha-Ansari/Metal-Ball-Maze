using UnityEngine;

public class ConditionalSmoothTargetRotation : MonoBehaviour
{

    public Transform targetObject;
    public float rotationSpeed = 5f;
    public float rotationLimits = .38f;

    public bool invertInput = false;


    void Start()
    {
        if (targetObject == null)
        {
            Debug.LogError("Target object is not assigned!");
            enabled = false;
            return;
        }


    }
    float previousXInput = 0;
    float previousYInput = 0;


    void Update()
    {

        previousXInput = Input.GetAxis("Horizontal");
        previousYInput = Input.GetAxis("Vertical");

        Debug.Log(targetObject.rotation);
        if (invertInput)
        {
            previousXInput = -previousXInput;
            previousYInput = -previousYInput;
        }
        // Negative
        previousXInput = targetObject.rotation.x > rotationLimits && previousXInput > 0 ? 0 : previousXInput;

        // Debug.Log(currentRotation.x + " : " + rotationLimits.y + " : " + previousXInput);
        Debug.Log(targetObject.rotation);
        previousYInput = targetObject.rotation.z > rotationLimits && previousYInput > 0 ? 0 : previousYInput;

        // Positive
        previousXInput = targetObject.rotation.x < -rotationLimits && previousXInput < 0 ? 0 : previousXInput;

        previousYInput = targetObject.rotation.z < -rotationLimits && previousYInput < 0 ? 0 : previousYInput;




        targetObject.Rotate(new Vector3(previousXInput * rotationSpeed * Time.deltaTime, 0, previousYInput * rotationSpeed * Time.deltaTime));
    }

    // Optional: Function to toggle input inversion
    public void ToggleInvertInput()
    {
        invertInput = !invertInput;
    }
}
