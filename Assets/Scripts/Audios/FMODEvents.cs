using UnityEngine;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;

public class FMODEvents : MonoBehaviour
{


    [field: Header("Abrir Puerta")]
    [field: SerializeField] public EventReference AbrirPuerta { get; private set; }


    [field: Header("Caminar")]
    [field: SerializeField] public EventReference Caminar { get; private set; }

    [field: Header("Clacs")]
    [field: SerializeField] public EventReference Clacs { get; private set; }

    [field: Header("Cristales Romperse")]
    [field: SerializeField] public EventReference Cristales { get; private set; }



    [field: Header("Susurro Grupo")]
    [field: SerializeField] public EventReference SusurroGrupo { get; private set; }

    [field: Header("Susurro Niña")]
    [field: SerializeField] public EventReference SusurroNiña { get; private set; }


    [field: Header("Soplar burbujas")]
    [field: SerializeField] public EventReference SoplarBurbujas { get; private set; }

    [field: Header("explotar burbuja")]
    [field: SerializeField] public EventReference ExplotarBurbuja { get; private set; }

    public static FMODEvents instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("encontrado mas de un fmodevents");
        }
        instance = this;
    }
}
