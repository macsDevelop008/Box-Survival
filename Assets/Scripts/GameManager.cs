using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Plataforma
{
    ESCRITORIO, MOVIL
}
public enum EstadoJuego 
{
    InGame, Pause, GameOver
}
public class GameManager : MonoBehaviour
{
    public static GameManager _shared;

    //Plataforma
    [SerializeField] Plataforma _plataforma;
    //Estado del juego
    [SerializeField] EstadoJuego _estadoJuego;

    //Plataforma
    public Plataforma PlataformaSeleccionada { get { return _plataforma; } set { _plataforma = value; } }

    //Estado del juego
    public EstadoJuego EstadoJuego { get { return _estadoJuego; } set { _estadoJuego = value; } }


    private void Awake()
    {
        _shared = this;
    }

}
