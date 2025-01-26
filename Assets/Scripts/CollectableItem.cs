using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    public Rigidbody[] sillas;
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
            foreach (Rigidbody silla in sillas)
            {
                silla.useGravity = true; // Activa la gravedad para cada Rigidbody
            }
            Debug.Log("Recolecta Estrella");
        }
    }
}
