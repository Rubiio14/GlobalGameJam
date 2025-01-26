using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using System.Collections;

public class LluviaSangre : MonoBehaviour
{
    public GameObject sangre;
    public Volume GlobalVolume;
    private ColorAdjustments colorAdjustments;

    void Start()
    {
        // Intentamos obtener el componente ColorAdjustments del GlobalVolume
        if (GlobalVolume.profile.TryGet(out colorAdjustments))
        {
            Debug.Log("ColorAdjustments encontrado.");
        }
        else
        {
            Debug.LogWarning("No se encontró ColorAdjustments en el Global Volume.");
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        sangre.SetActive(true); // Activar la sangre (lo que sea que haga tu objeto sangre)
        colorAdjustments.colorFilter.value = new Color(1f, 0.4f, 0.4f);
        StartCoroutine(CambiarColorAblanco());
    }

    private IEnumerator CambiarColorAblanco()
    {
        // Esperar 2 segundos
        yield return new WaitForSeconds(5f);
        colorAdjustments.colorFilter.value = Color.white;
        gameObject.SetActive(false);

    }
}