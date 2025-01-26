using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class sonidoCristales : MonoBehaviour
{



    private void OnTriggerEnter(Collider other)
    {
        AudioManager.instance.PlayOneShot(FMODEvents.instance.Cristales, this.transform.position);
        Destroy(this.gameObject);
    }

}
