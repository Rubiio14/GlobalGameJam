using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class sonidoPiano : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        AudioManager.instance.PlayOneShot(FMODEvents.instance.Piano, this.transform.position);
        Destroy(this.gameObject);
    }
}
