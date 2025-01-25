using UnityEngine;

public class DoorController : MonoBehaviour
{
    public float targetRotation = -112f;  // �ngulo de rotaci�n objetivo
    public float rotationSpeed = 1f;      // Velocidad de rotaci�n (en grados por segundo)
    public bool canOpen = false;
    

    void Update()
    {
        if (canOpen)
        {
            if (targetRotation < gameObject.transform.rotation.y)
            {
                transform.Rotate(0, -(1f * rotationSpeed * Time.deltaTime), 0);
            }
        }       
    }
}
