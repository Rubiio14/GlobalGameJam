using UnityEngine;

public class PosterCambia : MonoBehaviour
{
    [SerializeField] private GameObject sirena;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sirena.SetActive(true);
        }
    }
}
