using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    //Custom
    [SerializeField, Range(0f, 10f)] [Tooltip("Velocidad de movimiento")] public float playerSpeed = 2f;
    [Header("Camera")]
    public new Transform camera;
    [SerializeField, Range(0f, 10f)] [Tooltip("Sensibilidad cámara eje horizontal")] public float horCameraSens = 2f;
    [SerializeField, Range(0f, 10f)] [Tooltip("Sensibilidad cámara eje vertical")] public float verCameraSens = 2f;
    
    //Atributes
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        playerMovement();
        cameraMovement();
    }

    private void playerMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        if (horizontal != 0 || vertical != 0)
        {
            Vector3 direction = (transform.forward * vertical + transform.right * horizontal).normalized;
            rb.linearVelocity = direction * playerSpeed;
        }
        else
        {
            rb.linearVelocity = Vector3.zero;
        }

    }

    private void cameraMovement()
    {
        float horizontal = Input.GetAxis("Mouse X");
        float vertical = Input.GetAxis("Mouse Y");

        if (horizontal != 0)
        {
            transform.Rotate(0, horizontal * horCameraSens, 0);
        }

        if (vertical != 0)
        {
            Vector3 cameraRotation = camera.localEulerAngles;
            cameraRotation.x = (cameraRotation.x - vertical * verCameraSens + 360) % 360;
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
