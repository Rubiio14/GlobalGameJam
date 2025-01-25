using UnityEngine;
using UnityEngine.InputSystem;

public class InteractBehaviour : MonoBehaviour
{
    public void OnInteract(InputAction.CallbackContext context)
    {
        // Ejecutar solo cuando la acci�n comience
        if (context.canceled)
        {
            interactAction();
        }
    }

    private void interactAction()
    {
        print("Interact�a");
    }
}