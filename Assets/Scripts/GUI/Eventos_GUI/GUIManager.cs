using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GUIManager : MonoBehaviour
{
    [SerializeField] Text _scorePersonalTXT;

    [SerializeField] GameObject _panelCargando, _panelLogIn, 
        _panelCreateAccount, _panelTablaPuntos;

    private void Start()
    {
        ImprimirScorePersonal();
    }

    void ImprimirScorePersonal()
    {
        _scorePersonalTXT.text = PersistenciaPersonal._shared.DarScorePersonalPersistencia().ToString();
    }

    //Evento Boton Play
    public void PlayGame() 
    {
        _panelCargando.SetActive(true);
        SceneManager.LoadScene("01_Nivel");
    }

    //Eventos Boton Iniciar Cuenta
    public void PanelIniciarCuenta()
    {

    }


    //Eventos Boton Crear cuenta
    public void PanelCrearCuenta() 
    {

    }

    //Eventos Boton Tabla
    public void PanelTablaMejoresPuntos()
    {

    }
}
