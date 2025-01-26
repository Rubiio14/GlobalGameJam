using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class sonidoSusurros : MonoBehaviour
{



    private void OnTriggerEnter(Collider other)
    {
        AudioManager.instance.PlayOneShot(FMODEvents.instance.SusurroGrupo, this.transform.position);
        Destroy(this.gameObject);
    }

}

