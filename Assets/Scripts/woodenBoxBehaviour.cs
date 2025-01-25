using UnityEngine;

public class woodenBoxBehaviour : MonoBehaviour
{
    [SerializeField] public GameObject concha;
    [SerializeField] public GameObject estrella;
    [SerializeField] public GameObject pompero;
    public bool puzzleActivation = false;

    private void OnTriggerEnter(Collider other)
    {
        // Habilitar interacción si el jugador entra en el trigger correcto
        if (other.CompareTag("Player"))
        {
            puzzleActivation = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Habilitar interacción si el jugador entra en el trigger correcto
        if (other.CompareTag("Player"))
        {
            puzzleActivation = false;
        }
    }

    public void puzzleComplete()
    {
        concha.SetActive(false);
        estrella.SetActive(false);
        pompero.SetActive(true);
    }
}
