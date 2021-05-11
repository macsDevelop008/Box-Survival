using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateAccountController : MonoBehaviour
{
    [SerializeField] GameObject _ventanaCreateAccount;
    [SerializeField] InputField _textUsuario;
    [SerializeField] InputField _textContrase�a;
    [SerializeField] InputField _textConfirmarContrase�a;


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
            if (Contrase�asIguales())
            {
                //Nuevo Usuario
                CuentaUsuario cuentaUsuario = new CuentaUsuario(_textUsuario.text, _textContrase�a.text, "0");
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
                    VentanaAvisoController._shared.Ventana("Tu contrase�a debe tener de 6 a 20 caracteres");
                }
                else if(result == 0)
                {
                    VentanaAvisoController._shared.Ventana("Tu Cuenta fue creada con exito");
                }
            }
            else 
            {
                VentanaAvisoController._shared.Ventana("Las Contrase�as no coinciden :u");
            }
        }
        else
        {
            VentanaAvisoController._shared.Ventana("Rellena Todo los Espacios :u");
        }

        Limpiartextos();
    }

    bool Contrase�asIguales() 
    {
        if (_textContrase�a.text.Equals(_textConfirmarContrase�a.text))
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
                && _textContrase�a.text != "" 
                    && _textConfirmarContrase�a.text != "")
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
        _textContrase�a.text = null;
        _textConfirmarContrase�a.text = null;
    }
}
