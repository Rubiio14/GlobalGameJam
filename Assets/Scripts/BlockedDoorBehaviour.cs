using UnityEngine;
using FMOD.Studio;

public class DoorController : MonoBehaviour
{
    public float targetRotation = -112f;  // �ngulo de rotaci�n objetivo
    public float rotationSpeed = 1f;      // Velocidad de rotaci�n (en grados por segundo)
    public bool canOpen = false;

    public EventInstance door;
    

    void Update()
    {
        if (canOpen)
        {
            if (targetRotation < gameObject.transform.rotation.y)
            {
                transform.Rotate(0, -(1f * rotationSpeed * Time.deltaTime), 0);
                door = AudioManager.instance.CreateInstance(FMODEvents.instance.AbrirPuerta);
            }
        }       
    }
}
