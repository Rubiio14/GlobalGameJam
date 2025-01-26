using UnityEngine;
using UnityEngine.InputSystem;

public class WallDrawsBehaviour : MonoBehaviour
{
    public bool playerInside; // Indica si el jugador está dentro del trigger
    public bool playerInteract; // Indica si el jugador está interactuando
    public GameObject bubble; // Esfera hija que será desactivada
    public SpriteRenderer wallDraw; // Sprite que cambiará su alpha
    public float fadeSpeed = 1f; // Velocidad de cambio de alpha

    void Update()
    {
        // Si el jugador está dentro y está interactuando
        if (playerInside && playerInteract)
        {
            // Aumenta el alpha del SpriteRenderer de forma gradual
            Color currentColor = wallDraw.color;
            currentColor.a = Mathf.Min(currentColor.a + fadeSpeed * Time.deltaTime, 1f); // Máximo alpha = 1
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
            // Si el jugador comienza a interactuar y está dentro del trigger
            playerInteract = true;
            AudioManager.instance.PlayOneShot(FMODEvents.instance.SoplarBurbujas, this.transform.position);
            AudioManager.instance.PlayOneShot(FMODEvents.instance.ExplotarBurbuja, this.transform.position);
            bubble.SetActive(false); // Desactiva la burbuja al interactuar
        }
    }
}

