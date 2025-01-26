using UnityEngine;
using UnityEngine.InputSystem;

public class WallDrawsBehaviour : MonoBehaviour
{
    public bool playerInside; // Indica si el jugador est� dentro del trigger
    public bool playerInteract; // Indica si el jugador est� interactuando
    public GameObject bubble; // Esfera hija que ser� desactivada
    public SpriteRenderer wallDraw; // Sprite que cambiar� su alpha
    public float fadeSpeed = 1f; // Velocidad de cambio de alpha

    void Update()
    {
        // Si el jugador est� dentro y est� interactuando
        if (playerInside && playerInteract)
        {
            // Aumenta el alpha del SpriteRenderer de forma gradual
            Color currentColor = wallDraw.color;
            currentColor.a = Mathf.Min(currentColor.a + fadeSpeed * Time.deltaTime, 1f); // M�ximo alpha = 1
            wallDraw.color = currentColor;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Si el jugador entra al trigger
        if (other.CompareTag("Player"))
        {
            playerInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Si el jugador sale del trigger
        if (other.CompareTag("Player"))
        {
            playerInside = false;
        }
    }

    public void OnPlayerWallInteract(InputAction.CallbackContext context)
    {
        if (context.started && playerInside)
        {
            // Si el jugador comienza a interactuar y est� dentro del trigger
            playerInteract = true;
            AudioManager.instance.PlayOneShot(FMODEvents.instance.SoplarBurbujas, this.transform.position);
            AudioManager.instance.PlayOneShot(FMODEvents.instance.ExplotarBurbuja, this.transform.position);
            bubble.SetActive(false); // Desactiva la burbuja al interactuar
        }
    }
}

