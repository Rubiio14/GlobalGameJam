using UnityEngine;
using System.Collections;

public class woodenBoxBehaviour : MonoBehaviour
{
    [SerializeField] public GameObject concha;
    [SerializeField] public GameObject estrella;
    [SerializeField] public GameObject pompero;
    [SerializeField] public GameObject PlayerPompero;
    [SerializeField] public GameObject PlayerPomperoPro;
    public bool puzzleActivation = false;
    public bool changePompero = false;
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
        
        changePompero = true;
    }
    public void ChangePompero()
    {
        if(changePompero == true)
        {
            StartCoroutine(delayPompero());
            changePompero = false;          
        }
    }

    IEnumerator delayPompero()
    {
        yield return new WaitForSeconds(0.5f);
        PlayerPompero.SetActive(false);
        PlayerPomperoPro.SetActive(true);
        pompero.SetActive(false);
        PlayerPompero.SetActive(false);
    }
}

