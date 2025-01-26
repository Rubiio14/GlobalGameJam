using UnityEngine;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;

public class FMODEvents : MonoBehaviour
{


    [field: Header("Abrir Puerta")]
    [field: SerializeField] public EventReference AbrirPuerta { get; private set; }

    [field: Header("Footsteps")]
    [field: SerializeField] public EventReference Footsteps { get; private set; }

    [field: Header("Audio Video Proyector")]
    [field: SerializeField] public EventReference AudioProyector { get; private set; }

    [field: Header("LLuvia sangre")]
    [field: SerializeField] public EventReference Lluvia { get; private set; }

    [field: Header("Canto sirena")]
    [field: SerializeField] public EventReference Canto { get; private set; }

    [field: Header("Platos partiendose")]
    [field: SerializeField] public EventReference Platos { get; private set; }

    [field: Header("Piano")]
    [field: SerializeField] public EventReference Piano { get; private set; }

    [field: Header("Click")]
    [field: SerializeField] public EventReference Click { get; private set; }

    [field: Header("Hover")]
    [field: SerializeField] public EventReference Hover { get; private set; }

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
