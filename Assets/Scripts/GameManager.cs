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

    //HUD GameOver
    [SerializeField] GameObject _hudGameOver;

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

    public void GameOver() 
    {
        if (HealtPlayerController._shared.GetVidaActual() <= 0.0f) 
        {
            _estadoJuego = EstadoJuego.GameOver;

            StartCoroutine(RutinaGameOver());

        }
    }

    IEnumerator RutinaGameOver()
    {
        //Animacion player gameOver
        AnimatorPlayerController._shared.GameOver();

        yield return new WaitForSeconds(2.0f);

        //HUD GameOver
        _hudGameOver.SetActive(true);

        //Calcular score y demas textos en ventana del gameOver
        HUDEventos._shared.GameOverTextos();

        //Calcular score para puntuacion glonal (si hay internet)
    }
}
