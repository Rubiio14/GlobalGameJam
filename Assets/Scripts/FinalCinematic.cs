using System.Collections;
using UnityEngine;
using UnityEngine.Video;
using FMOD.Studio;

public class FinalCinematic : MonoBehaviour
{
    public GameObject canvasVideo;
    public GameObject canvasInicio;

    public EventInstance intro;
    public EventInstance final;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(QuitCinematic());
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canvasVideo.SetActive(true);
            final = AudioManager.instance.CreateInstance(FMODEvents.instance.Final);
        }
    }
    IEnumerator QuitCinematic()
    {
        yield return new WaitForSeconds(23.1f);
        canvasInicio.SetActive(false);
    }
}
