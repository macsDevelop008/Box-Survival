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
    [SerializeField] GameObject _ventanaConfirmarCerrarSesion;

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
        _panelLogIn.SetActive(true);
    }


    //Eventos Boton Crear cuenta
    public void PanelCrearCuenta() 
    {
        _panelCreateAccount.SetActive(true);
    }


    //Eventos Boton Tabla
    public void PanelTablaMejoresPuntos()
    {
        _panelTablaPuntos.SetActive(true);
    }

    //Eventos Boton Cerrar Sesion
    public void CerrarSesion() 
    {
        //PersistenciaCuentaIniciada._shared.CuentaActualIniciada = "";
        _ventanaConfirmarCerrarSesion.SetActive(true);

    }
    public void ConfirmarCerrarSesion() 
    {
        PersistenciaCuentaIniciada._shared.CuentaActualIniciada = "";
        _ventanaConfirmarCerrarSesion.SetActive(false);
    }

    public void CancelarCerrarSesion()
    {
        _ventanaConfirmarCerrarSesion.SetActive(false);
    }
}
