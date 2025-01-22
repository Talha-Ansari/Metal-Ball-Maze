using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerInputs : MonoBehaviour
{
    [Header("Gyro Settings")]
    public Transform controlledObject; // The object to control with the gyroscope
    public float sensitivity = 1.0f;   // Sensitivity for rotation
    public bool invertX = false;       // Invert gyro input on the X-axis
    public bool invertY = false;       // Invert gyro input on the Y-axis

    private bool gyroEnabled = false;
    private Quaternion initialGyroRotation;

    void Start()
    {
        if (controlledObject == null)
        {
            Debug.LogError("Controlled object is not assigned!");
            enabled = false;
            return;
        }

        // Enable the gyroscope if available
        if (SystemInfo.supportsGyroscope)
        {
            Input.gyro.enabled = true;
            gyroEnabled = true;
            Debug.Log("Gyroscope enabled and available.");
        }
        else
        {
            Debug.LogError("Gyroscope not supported on this device.");
        }

        // Record the initial rotation
        initialGyroRotation = Input.gyro.attitude;
    }

    void Update()
    {
        if (!gyroEnabled)
            return;

        // Get the gyroscope attitude (orientation)
        Quaternion gyroRotation = Input.gyro.attitude;

        // Adjust sensitivity and optional inversion
        float xRotation = gyroRotation.x * sensitivity * (invertX ? -1 : 1);
        float yRotation = gyroRotation.y * sensitivity * (invertY ? -1 : 1);

        // Rotate the controlled object
        controlledObject.Rotate(Vector3.up, -xRotation * Time.deltaTime, Space.World);  // Yaw (Y-axis)
        controlledObject.Rotate(Vector3.right, yRotation * Time.deltaTime, Space.Self); // Pitch (X-axis)
    }
}
