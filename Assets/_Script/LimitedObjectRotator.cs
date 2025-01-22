using UnityEngine;
using UnityEngine.InputSystem;
public class LimitedObjectRotator : MonoBehaviour
{
    [Header("Rotation Settings")]
    public Vector2 rotationSpeed = new Vector2(100f, 100f); // Speed of rotation for X and Y
    public bool rotateOnInput = true; // If true, rotation is controlled by input
    public bool inverseDirection; // Toggle for inverting input direction

    [Header("Gyro Settings")]
    public bool useGyro = false; // Enable or disable gyroscopic input
    public float gyroSensitivity = 1.0f; // Sensitivity for gyro input
    public bool invertGyroX = false; // Invert gyro X-axis
    public bool invertGyroY = false; // Invert gyro Y-axis

    [Header("Rotation Limits")]
    public Vector2 xRotationLimits = new Vector2(-45f, 45f); // Min and max limits for X-axis
    public Vector2 yRotationLimits = new Vector2(-45f, 45f); // Min and max limits for Y-axis

    private Vector3 currentRotation; // Stores the current rotation of the object


    private bool gyroEnabled = false;
    [SerializeField] Transform verticalOBj;

    [SerializeField] PlayerControlar playerInput;
    private void Awake()
    {
        playerInput = new PlayerControlar();
    }
    void Start()
    {
        playerInput.Player.Enable();
        // Initialize the current rotation to the object's starting rotation
        currentRotation = transform.localEulerAngles;

        // Enable gyroscope if supported
        if (SystemInfo.supportsGyroscope)
        {
            Input.gyro.enabled = true;
            gyroEnabled = true;
            Debug.Log("Gyroscope enabled.");
        }
        else
        {
            Debug.LogWarning("Gyroscope not supported on this device.");
        }
    }
    void Update()
    {
        Vector2 input = Vector2.zero;


        // Input-based rotation
        if (rotateOnInput)
        {
            // input.x = Input.GetAxis("Vertical"); // X-axis rotation from Vertical input (W/S or Up/Down arrows)
            // input.y = Input.GetAxis("Horizontal"); // Y-axis rotation from Horizontal input (A/D or Left/Right arrows)
            if (inverseDirection)
            {
                input = playerInput.Player.Move.ReadValue<Vector2>();
                input *= -1;
            }
            float temp = input.x;
            input.x = input.y;
            input.y = temp;
        }

        // Gyroscopic rotation
        if (useGyro && gyroEnabled)
        {
            input = Vector2.zero;
            // Vector3 gyroInput = Input.gyro.rotationRateUnbiased; // Get the unbiased gyro rotation
            Vector3 gyroInput = playerInput.Player.MoveGyro.ReadValue<Vector3>(); // Get the unbiased gyro rotation
            Debug.Log(gyroInput);
            gyroInput.z = gyroInput.y;
            gyroInput.y = gyroInput.x;
            gyroInput.x = gyroInput.z;

            input.x += gyroInput.x * gyroSensitivity * (invertGyroX ? -1 : 1); // Add gyro X-axis input
            input.y += gyroInput.y * gyroSensitivity * (invertGyroY ? -1 : 1); // Add gyro Y-axis input
        }

        // Calculate the rotation change based on input and speed
        Vector3 rotationChange = new Vector3(
            input.x * rotationSpeed.x * Time.deltaTime, 0,
            input.y * rotationSpeed.y * Time.deltaTime
        );

        // Apply the rotation change and clamp it within limits
        currentRotation.x = Mathf.Clamp(currentRotation.x - rotationChange.x, xRotationLimits.x, xRotationLimits.y); // Subtract for inverse input effect
        currentRotation.z = Mathf.Clamp(currentRotation.z + rotationChange.z, yRotationLimits.x, yRotationLimits.y);
        if (verticalOBj != null)
            verticalOBj.localEulerAngles = new Vector3(currentRotation.x, 90, 0);
        // Apply the clamped rotation to the object
        transform.localEulerAngles = currentRotation;
    }

    // void OnMove(InputAction.CallbackContext context)
    // {
    //     input = context.ReadValue<Vector2>();
    // }
}

