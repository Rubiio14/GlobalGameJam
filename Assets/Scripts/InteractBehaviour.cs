using UnityEngine;
using UnityEngine.InputSystem;

public class InteractBehaviour : MonoBehaviour
{
    public BubbleBehaviour bubbleScript;
    public BubbleBehaviourStar bubbleScriptStar;
    public woodenBoxBehaviour woodenBoxScript;
    public CollectableItem _collectableItemScript;

    private bool canInteract = false; // Indica si el jugador está dentro del trigger
    private bool canInteractStar = false;
    private bool actionTriggered = false; // Evita múltiples ejecuciones por un solo clic

    public void OnInteract(InputAction.CallbackContext context)
    {
        // Solo ejecutar en la fase 'performed' si la interacción está habilitada y no se ha ejecutado ya
        if (context.performed && canInteract && !actionTriggered)
        {
            interactAction();
        }
        if (context.performed && canInteractStar && !actionTriggered)
        {
            interactActionStar();
        }

        if (context.performed && woodenBoxScript.puzzleActivation && !actionTriggered)
        {
            if(_collectableItemScript.concha && _collectableItemScript.estrella)
            {
                interactWoodenBox();
            }
            
        }
    }

    private void interactAction()
    {
        // Ejecutar acción de interacción
        bubbleScript.nextWaypoint();
        Debug.Log("Acción interact ejecutada");

        // Bloquear para evitar múltiples ejecuciones
        actionTriggered = true;

        // Desbloquear después de un breve intervalo para permitir otra interacción
        Invoke(nameof(ResetActionTrigger), 0.1f); // Tiempo de bloqueo ajustable
    }


    private void interactActionStar()
    {
        // Ejecutar acción de interacción
        bubbleScriptStar.nextWaypoint();
        Debug.Log("Acción interact ejecutada");

        // Bloquear para evitar múltiples ejecuciones
        actionTriggered = true;

        // Desbloquear después de un breve intervalo para permitir otra interacción
        Invoke(nameof(ResetActionTrigger), 0.1f); // Tiempo de bloqueo ajustable
    }

    private void interactWoodenBox()
    {
        woodenBoxScript.puzzleComplete();
        woodenBoxScript.ChangePompero();
    }



    private void ResetActionTrigger()
    {
        actionTriggered = false;      
    }

    private void OnTriggerEnter(Collider other)
    {
        // Habilitar interacción si el jugador entra en el trigger correcto
        if (other.CompareTag("activateTrigger"))
        {
            canInteract = true;
            Debug.Log("Jugador dentro del trigger. Puede interactuar.");
        }
        if (other.CompareTag("activateTriggerStar"))
        {
            canInteractStar = true;
            Debug.Log("Jugador dentro del trigger. Puede interactuar.");
        }
        if (other.CompareTag("BlockedDoor") && gameObject.GetComponent<CollectableItem>().concha && gameObject.GetComponent<CollectableItem>().concha)
        {
            other.gameObject.GetComponent<DoorController>().canOpen = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Deshabilitar interacción si el jugador sale del trigger
        if (other.CompareTag("activateTrigger"))
        {
            canInteract = false;
            Debug.Log("Jugador fuera del trigger. No puede interactuar.");
        }
        if (other.CompareTag("activateTriggerStar"))
        {
            canInteractStar = false;
            Debug.Log("Jugador fuera del trigger. No puede interactuar.");
        }
    }
}