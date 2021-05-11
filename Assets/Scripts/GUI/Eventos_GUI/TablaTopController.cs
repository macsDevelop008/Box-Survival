using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TablaTopController : MonoBehaviour
{
    [SerializeField] GameObject _ventanaTablaRegistros;
    [SerializeField] GameObject _baseRegistro;
    [SerializeField] Transform _transformContenedoraVertical;

    public void VerTabla() 
    {
        //Si hay internet
        if (ConeccionInternet._shared.coneccionRed()) 
        {
            _ventanaTablaRegistros.SetActive(true);
            ObtenerRegistros();
        }
    }

    public void CerrarTabla() 
    {
        for (int i = 0; i < _transformContenedoraVertical.childCount; i++) 
        {
            Destroy(_transformContenedoraVertical.GetChild(i).gameObject);
        }
        _ventanaTablaRegistros.SetActive(false);
    }

    //Obtener registros
    void ObtenerRegistros() 
    {
        Instanciar(DBManager._shared.TopMejoresScore());
    }

    //Instanciarlos en el contenedor
    void Instanciar(CuentaUsuario[] cuentaUsuarios) 
    {
        for (int i = 0; i < cuentaUsuarios.Length; i++) 
        {
            GameObject gameObject = Instantiate(_baseRegistro, _transformContenedoraVertical);

            AjusteInformacion(gameObject, cuentaUsuarios[i], i+1);
        }

    }

    //ajustar objetos con sus respectivos valores
    void AjusteInformacion(GameObject pRegistro, CuentaUsuario pInfo, int pNumero) 
    {
        Registro info = pRegistro.GetComponent<Registro>();

        info.Numero.text = pNumero.ToString();
        info.Nombre.text = pInfo.cuenta;
        info.Score.text = pInfo.score;
    }
}
