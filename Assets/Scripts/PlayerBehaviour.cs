using UnityEngine;
using UnityEngine.InputSystem;
using FMOD.Studio;

public class PlayerBehaviour : MonoBehaviour
{
    // Custom
    [SerializeField, Range(0f, 10f)][Tooltip("Velocidad de movimiento")] public float playerSpeed = 2f;
    [Header("Camera")]
    public Transform camera;
    [SerializeField, Range(0f, 10f)][Tooltip("Sensibilidad cámara eje horizontal")] public float horCameraSens = 2f;
    [SerializeField, Range(0f, 10f)][Tooltip("Sensibilidad cámara eje vertical")] public float verCameraSens = 2f;

    [Header("Audio")]
    public EventInstance playerFootSteps;

    // Atributos
    private Rigidbody rb;
    private Vector2 moveInput; // Solo guarda el input del jugador
    private Vector2 lookInput;
    private float verticalRotation = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;

        playerFootSteps = AudioManager.instance.CreateInstance(FMODEvents.instance.Footsteps);
    }

    void Update()
    {
        CameraMovement();
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        // Leer el input de movimiento del jugador
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }

    private void PlayerMovement()
    {
        // Si hay input de movimiento
        if (moveInput != Vector2.zero)
        {
            // Obtener la dirección basada en la orientación de la cámara
            Vector3 forward = camera.forward;
            Vector3 right = camera.right;

            // Ignorar la componente vertical para evitar movimiento en Y
            forward.y = 0f;
            right.y = 0f;

            forward.Normalize();
            right.Normalize();

            // Combinar los inputs con la orientación de la cámara
            Vector3 movementDirection = (forward * moveInput.y + right * moveInput.x).normalized;

            // Aplicar movimiento
            Vector3 velocity = movementDirection * playerSpeed;
            velocity.y = rb.linearVelocity.y; // Mantener la velocidad vertical (gravedad)
            rb.linearVelocity = velocity;

            PLAYBACK_STATE playbackState;
            playerFootSteps.getPlaybackState(out playbackState);
            if (playbackState.Equals(PLAYBACK_STATE.STOPPED))
            {
                Debug.Log("music playing");
                playerFootSteps.start();
            }
            else
            {
                Debug.Log("music stopped");
            }
        }
        else
        {
            // Si no hay input, detener el movimiento horizontal
            Vector3 velocity = rb.linearVelocity;
            velocity.x = 0;
            velocity.z = 0;
            rb.linearVelocity = velocity;
            playerFootSteps.stop(STOP_MODE.ALLOWFADEOUT);
        }
    }

    private void CameraMovement()
    {
        // Rotación horizontal (gira al jugador)
        if (lookInput.x != 0)
        {
            transform.Rotate(0, lookInput.x * horCameraSens, 0);
        }

        // Rotación vertical (gira la cámara)
        if (lookInput.y != 0)
        {
            verticalRotation -= lookInput.y * verCameraSens;
            verticalRotation = Mathf.Clamp(verticalRotation, -80f, 80f); // Limitar rotación vertical

            camera.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
        }
    }
}