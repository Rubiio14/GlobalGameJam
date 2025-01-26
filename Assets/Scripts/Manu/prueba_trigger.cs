using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class prueba_trigger : MonoBehaviour
{
    


    private void OnTriggerEnter(Collider other)
    {
        AudioManager.instance.PlayOneShot(FMODEvents.instance.SoplarBurbujas, this.transform.position); 
    }
    
}
