using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateAccountController : MonoBehaviour
{
    [SerializeField] GameObject _ventanaCreateAccount;
    [SerializeField] InputField _textUsuario;
    [SerializeField] InputField _textContraseña;
    [SerializeField] InputField _textConfirmarContraseña;


    //Evento
    public void Cancel()
    {
        _ventanaCreateAccount.SetActive(false);
        Limpiartextos();
    }

    //Evento
    public void Create() 
    {
        if (TextosRellenos()) 
        {
            if (ContraseñasIguales())
            {
                //Nuevo Usuario
                CuentaUsuario cuentaUsuario = new CuentaUsuario(_textUsuario.text, _textContraseña.text, "0");
                int result = DBManager._shared.CrearCuenta(cuentaUsuario);

                if (result == 3)
                {
                    
                    VentanaAvisoController._shared.Ventana("Tu cuenta debe tener al menos 5 caracteres");
                }
                else
                if (result == 2)
                {
                    VentanaAvisoController._shared.Ventana("La cuenta ya existe");
                }
                else
                if (result == 1)
                {
                    VentanaAvisoController._shared.Ventana("Tu contraseña debe tener de 6 a 20 caracteres");
                }
                else if(result == 0)
                {
                    VentanaAvisoController._shared.Ventana("Tu Cuenta fue creada con exito");
                }
            }
            else 
            {
                VentanaAvisoController._shared.Ventana("Las Contraseñas no coinciden :u");
            }
        }
        else
        {
            VentanaAvisoController._shared.Ventana("Rellena Todo los Espacios :u");
        }

        Limpiartextos();
    }

    bool ContraseñasIguales() 
    {
        if (_textContraseña.text.Equals(_textConfirmarContraseña.text))
        {
            return true;
        }
        else 
        {
            return false;
        }
    }

    bool TextosRellenos() 
    {
        if (_textUsuario.text != "" 
                && _textContraseña.text != "" 
                    && _textConfirmarContraseña.text != "")
        {
            return true;
        }
        else 
        {
            return false;
        }
    }

    void Limpiartextos()
    {
        _textUsuario.text = null;
        _textContraseña.text = null;
        _textConfirmarContraseña.text = null;
    }
}
