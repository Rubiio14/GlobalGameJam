using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class sonidoNiña : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        AudioManager.instance.PlayOneShot(FMODEvents.instance.SusurroNiña, this.transform.position);
        Destroy(this.gameObject);
    }
}
