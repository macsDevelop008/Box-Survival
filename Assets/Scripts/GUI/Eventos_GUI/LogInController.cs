using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogInController : MonoBehaviour
{
    [SerializeField] GameObject _panelIniciarSesion, _panelCrearCuenta;
    [SerializeField] InputField _cuenta, _contrasenia;



    public void IniciarSesion() 
    {
        bool result = DBManager._shared.IniciarSesion(_cuenta.text, _contrasenia.text);
        if (result)
        {
            VentanaAvisoController._shared.Ventana("Tu cuenta inicio correctamente");
            LimpiarEspacios();
            _panelIniciarSesion.SetActive(false);
        }
        else 
        {
            VentanaAvisoController._shared.Ventana("Cuenta y/o Contraseña Incorrecta(s)");

        }
    }
    public void CrearCuenta() 
    {
        _panelIniciarSesion.SetActive(false);
        LimpiarEspacios();
        _panelCrearCuenta.SetActive(true);
    }
    public void Cancel() 
    {
        LimpiarEspacios();
        _panelIniciarSesion.SetActive(false);
    }

    void LimpiarEspacios() 
    {
        _cuenta.text = "";
        _contrasenia.text = "";
    }
}
