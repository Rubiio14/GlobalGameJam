using UnityEngine;
using UnityEngine.Video;

public class FinalCinematic : MonoBehaviour
{
    public GameObject canvasVideo;
    public VideoPlayer video;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canvasVideo.SetActive(true);
            video.Play();
        }
    }
}
