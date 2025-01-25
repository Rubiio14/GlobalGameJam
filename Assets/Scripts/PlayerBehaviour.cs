using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    // Custom
    [SerializeField, Range(0f, 10f)][Tooltip("Velocidad de movimiento")] public float playerSpeed = 2f;
    [Header("Camera")]
    public Transform camera;
    [SerializeField, Range(0f, 10f)][Tooltip("Sensibilidad cámara eje horizontal")] public float horCameraSens = 2f;
    [SerializeField, Range(0f, 10f)][Tooltip("Sensibilidad cámara eje vertical")] public float verCameraSens = 2f;

    // Atributos
    private Rigidbody rb;
    private Vector3 movementInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        HandleInput();
        CameraMovement();
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    private void HandleInput()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        movementInput = (transform.forward * vertical + transform.right * horizontal).normalized;
    }

    private void PlayerMovement()
    {
        if (movementInput != Vector3.zero)
        {
            Vector3 velocity = movementInput * playerSpeed;
            velocity.y = rb.linearVelocity.y; // Mantén la velocidad vertical (gravedad)
            rb.linearVelocity = velocity;
        }
    }

    private void CameraMovement()
    {
        float horizontal = Input.GetAxis("Mouse X");
        float vertical = Input.GetAxis("Mouse Y");

        // Rotación horizontal (gira al jugador)
        if (horizontal != 0)
        {
            transform.Rotate(0, horizontal * horCameraSens, 0);
        }

        // Rotación vertical (gira la cámara)
        if (vertical != 0)
        {
            Vector3 cameraRotation = camera.localEulerAngles;
            cameraRotation.x = (cameraRotation.x - vertical * verCameraSens + 360) % 360;

            // Limita la rotación vertical para evitar giros completos
            if (cameraRotation.x > 80 && cameraRotation.x < 180)
            {
                cameraRotation.x = 80;
            }
            else if (cameraRotation.x < 280 && cameraRotation.x > 180)
            {
                cameraRotation.x = 280;
            }

            camera.localEulerAngles = cameraRotation;
        }
    }
}