using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class sonidoCanto : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        AudioManager.instance.PlayOneShot(FMODEvents.instance.Canto, this.transform.position);
        Destroy(this.gameObject);
    }
}
