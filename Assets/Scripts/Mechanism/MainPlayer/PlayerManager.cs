using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerManager : MonoBehaviour
{

    public static PlayerManager _shared;



    //Propiedades
    public Collider _collider { get; set; }
    public Rigidbody _rigidbody { get; set; }
    public Animator _animator { get; set; }


    [Header("Vida")]
    [SerializeField] float _vidaMaxima;

    [Header("Movimiento")]
    [SerializeField] float _velocidadMovimiento;

    [Header("Rotacion")]
    [SerializeField] float _velocidadRotacion;
    public bool _permanecerRotacion { get; set; }

    [Header("Propiedades Disparo")]
    [SerializeField] float _daņoPorDisparo;
    [SerializeField] float _tiempoEntreDisparos;
    [SerializeField] float _rangoDisparo;
    public bool Attack { get; set; }

    [Header("Raycast")]
    [Header("Calculo Movimiento")]
    [SerializeField] float _restriccionMovimiendoDistancia;
    [SerializeField] string _restriccionMovimiendoTagString;


    //Vida
    public float VidaMaxima { get { return _vidaMaxima; } set { _vidaMaxima = value; } }


    //Movimiento
    public float VelocidadMovimiento { get { return _velocidadMovimiento; } set { _velocidadMovimiento = value; } }

    //Rotacion
    public float VelocidadRotacion { get { return _velocidadRotacion; } set { _velocidadRotacion = value; } }

    //Raycast
    //Calculo Movimiento
    public float RestriccionCalculomovimientoDistancia{ get { return _restriccionMovimiendoDistancia; } set { _restriccionMovimiendoDistancia = value; } }
    public string RestriccionCalculomovimientoTagString { get { return _restriccionMovimiendoTagString; } set { _restriccionMovimiendoTagString = value; } }

    //Propiedades Disparo
    public float DaņoPorDisparo { get { return _daņoPorDisparo; } set { _daņoPorDisparo = value; } }
    public float TiempoEntreDisparos { get { return _tiempoEntreDisparos; } set { _tiempoEntreDisparos = value; } }
    public float RangoDisparo { get { return _rangoDisparo; } set { _rangoDisparo = value; } }

    private void Awake()
    {
        _shared = this;

        _collider = this.GetComponent<Collider>();
        _rigidbody = this.GetComponent<Rigidbody>();
        _animator = this.GetComponent<Animator>();

        _permanecerRotacion = true;
    }

}
