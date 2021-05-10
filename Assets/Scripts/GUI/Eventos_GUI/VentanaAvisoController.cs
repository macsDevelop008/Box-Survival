using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class VentanaAvisoController : MonoBehaviour
{
    public static VentanaAvisoController _shared;


    [SerializeField] GameObject _ventana;
    [SerializeField] TextMeshProUGUI _texto;


    private void Awake()
    {
        _shared = this;
    }

    public void Ventana(string textoAviso) 
    {
        _texto.text = textoAviso;
        _ventana.SetActive(true);
    }

    public void CerrarVentanaAviso() 
    {
        _ventana.SetActive(false);
        _texto.text = "";
    }
}
