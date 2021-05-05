using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistenciaPersonal : MonoBehaviour
{
    public static PersistenciaPersonal _shared;


    private void Awake()
    {
        _shared = this;
    }

    void Start()
    {
        //print(PlayerPrefs.HasKey("Prueba"));
        if (!PlayerPrefs.HasKey("ScorePersonal")) 
        {
            CrearPersistencia();
        }
    }

    void CrearPersistencia()
    {
        PlayerPrefs.SetFloat("ScorePersonal",0.0f);
    }

    public void ModificarScorePersonalPersistencia(float num) 
    {
        PlayerPrefs.SetFloat("ScorePersonal", num);
    }

    public float DarScorePersonalPersistencia() 
    {
        return PlayerPrefs.GetFloat("ScorePersonal");
    }
}
