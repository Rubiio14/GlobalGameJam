using UnityEngine;
using UnityEngine.InputSystem;

public class InteractBehaviour : MonoBehaviour
{
    public BubbleBehaviour bubbleScript;
    public bool canInteract = false;
    public void OnInteract(InputAction.CallbackContext context)
    {
        // Ejecutar solo cuando la acción comience
        if (context.canceled)
        {
            if (canInteract)
            {
                interactAction();
            }
            
        }
    }

    private void interactAction()
    {
        bubbleScript.nextWaypoint();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Si el jugador entra en el trigger
        if (other.CompareTag("activateTrigger"))
        {
            canInteract = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        canInteract = false;
        // Si el jugador entra en el trigger
        Debug.Log("Sale");
    }
}