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

    [Header("Movimiento")]
    [SerializeField] float _velocidadMovimiento;

    [Header("Rotacion")]
    [SerializeField] float _velocidadRotacion;
    public bool _permanecerRotacion { get; set; }

    [Header("Da�o Por Disparo")]
    [SerializeField] float _da�oPorDisparo;

    [Header("Raycast")]
    [Header("Calculo Movimiento")]
    [SerializeField] float _restriccionMovimiendoDistancia;
    [SerializeField] string _restriccionMovimiendoTagString;


    //Movimiento
    public float VelocidadMovimiento { get { return _velocidadMovimiento; } set { _velocidadMovimiento = value; } }

    //Rotacion
    public float VelocidadRotacion { get { return _velocidadRotacion; } set { _velocidadRotacion = value; } }

    //Da�o por disparo
    public float Da�oPorDiaparo { get { return _da�oPorDisparo; } set { _da�oPorDisparo = value; } }

    //Raycast
    //Calculo Movimiento
    public float RestriccionCalculomovimientoDistancia{ get { return _restriccionMovimiendoDistancia; } set { _restriccionMovimiendoDistancia = value; } }
    public string RestriccionCalculomovimientoTagString { get { return _restriccionMovimiendoTagString; } set { _restriccionMovimiendoTagString = value; } }

    private void Awake()
    {
        _shared = this;

        _collider = this.GetComponent<Collider>();
        _rigidbody = this.GetComponent<Rigidbody>();
        _animator = this.GetComponent<Animator>();

        _permanecerRotacion = true;
    }

}
