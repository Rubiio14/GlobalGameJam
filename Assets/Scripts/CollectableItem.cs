using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    public bool concha = false;
    public bool estrella = false;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Concha"))
        {
            other.gameObject.SetActive(false);
            concha = true;
            Debug.Log("Recolecta Concha");
        }
        if (other.CompareTag("Estrella"))
        {
            other.gameObject.SetActive(false);
            estrella = true;
            Debug.Log("Recolecta Estrella");
        }
    }
}
