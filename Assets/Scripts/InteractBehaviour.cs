using UnityEngine;
using UnityEngine.InputSystem;

public class InteractBehaviour : MonoBehaviour
{
    public BubbleBehaviour bubbleScript;
    public BubbleBehaviourStar bubbleScriptStar;
    public BubbleBehaviourTV bubbleTVStar;
    public woodenBoxBehaviour woodenBoxScript;
    public CollectableItem _collectableItemScript;
    public Animator animator;

    private bool canInteract = false; // Indica si el jugador est� dentro del trigger
    private bool canInteractStar = false;
    private bool canInteractTV = false;
    private bool actionTriggered = false; // Evita m�ltiples ejecuciones por un solo clic

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            // Solo ejecutar en la fase 'performed' si la interacci�n est� habilitada y no se ha ejecutado ya
            if (context.performed && canInteract && !actionTriggered)
            {
                interactAction();
            }
            if (context.performed && canInteractStar && !actionTriggered)
            {
                interactActionStar();           
            }
            if (context.performed && canInteractTV && !actionTriggered)
            {
                interactActionTV();            
            }

            if (context.performed && woodenBoxScript.puzzleActivation && !actionTriggered)
            {
                if (_collectableItemScript.concha && _collectableItemScript.estrella)
                {
                    interactWoodenBox();   
                }

            }
        }
        
    }

    private void interactAction()
    {
        // Ejecutar acci�n de interacci�n
        bubbleScript.nextWaypoint();
        AudioManager.instance.PlayOneShot(FMODEvents.instance.SoplarBurbujas, this.transform.position);
        animator.SetBool("Interact", true);

        Debug.Log("Acci�n interact ejecutada");

        // Bloquear para evitar m�ltiples ejecuciones
        actionTriggered = true;

        // Desbloquear despu�s de un breve intervalo para permitir otra interacci�n
        Invoke(nameof(ResetActionTrigger), 0.1f); // Tiempo de bloqueo ajustable
    }
    private void interactActionStar()
    {
        // Ejecutar acci�n de interacci�n
        bubbleScriptStar.nextWaypoint();
        AudioManager.instance.PlayOneShot(FMODEvents.instance.SoplarBurbujas, this.transform.position);
        animator.SetBool("Interact", true);
        Debug.Log("Acci�n interact ejecutada");

        // Bloquear para evitar m�ltiples ejecuciones
        actionTriggered = true;

        // Desbloquear despu�s de un breve intervalo para permitir otra interacci�n
        Invoke(nameof(ResetActionTrigger), 0.1f); // Tiempo de bloqueo ajustable
    }

    private void interactActionTV()
    {
        // Ejecutar acci�n de interacci�n
        bubbleTVStar.nextWaypoint();
        AudioManager.instance.PlayOneShot(FMODEvents.instance.SoplarBurbujas, this.transform.position);
        animator.SetBool("Interact", true);
        Debug.Log("Acci�n interact ejecutada");

        // Bloquear para evitar m�ltiples ejecuciones
        actionTriggered = true;

        // Desbloquear despu�s de un breve intervalo para permitir otra interacci�n
        Invoke(nameof(ResetActionTrigger), 0.1f); // Tiempo de bloqueo ajustable
    }

    private void interactWoodenBox()
    {
        AudioManager.instance.PlayOneShot(FMODEvents.instance.SoplarBurbujas, this.transform.position);
        animator.SetBool("Interact", true);
        woodenBoxScript.puzzleComplete();
        woodenBoxScript.ChangePompero();
    }



    private void ResetActionTrigger()
    {
        actionTriggered = false;      
    }

    private void OnTriggerEnter(Collider other)
    {
        // Habilitar interacci�n si el jugador entra en el trigger correcto
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
        if (other.CompareTag("activateTriggerTV"))
        {
            canInteractTV = true;
            Debug.Log("Jugador dentro del trigger. Puede interactuar.");
        }
        if (other.CompareTag("BlockedDoor") && gameObject.GetComponent<CollectableItem>().concha && gameObject.GetComponent<CollectableItem>().concha)
        {
            other.gameObject.GetComponent<DoorController>().canOpen = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Deshabilitar interacci�n si el jugador sale del trigger
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