using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayerController : MonoBehaviour
{
    public static ShootPlayerController _shared;

    //Porpiedades disparo
    [Header("Propiedades Disparo")]
    [SerializeField] GameObject _objectShoot;
    [SerializeField] public LineRenderer _lineRederShoot;
    [SerializeField] AudioSource _audioSourceShoot;
    [SerializeField] Light _lightShoot;
    [SerializeField] float _timeEffect;

    float _dañoPorDisparo;
    float _tiempoEntreDisparos;
    float _rangoDisparo;

    float _timer; //Contador tiempo entre disparos
    Ray _shootRay; //Rayo del disparo
    RaycastHit _hitShoot; //Almacena el objeto collisionado
    int _shootleableMask; //Mascara objetivo para el disparo

    private void Awake()
    {
        _shared = this;
    }

    private void Start()
    {
        _shootleableMask = LayerMask.GetMask("Enemy");
        _tiempoEntreDisparos = PlayerManager._shared.TiempoEntreDisparos;
    }

    private void Update()
    {
        _timer += Time.deltaTime;  //Contador entre disparos

        if (GameManager._shared.EstadoJuego == EstadoJuego.InGame)
        {
            //calcular disparo automatico con el tiempo respectivo y el auto ataque activado
            if (_timer >= _tiempoEntreDisparos && PlayerManager._shared.Attack)
            {
                ShootGun();
                _timer = 0.0f;
            }
        }        
    }


    public void ShootGun() 
    {
        _dañoPorDisparo = PlayerManager._shared.DañoPorDisparo;
        _tiempoEntreDisparos = PlayerManager._shared.TiempoEntreDisparos;
        _rangoDisparo = PlayerManager._shared.RangoDisparo;

        
        _audioSourceShoot.Play(); //Sonido de disparo
        _lightShoot.enabled = true; //Activar luz del disparo
        _lineRederShoot.enabled = true; //Activar line render
        _lineRederShoot.SetPosition(0, _objectShoot.transform.position); //Posicion inicial del line render

        _shootRay.origin = _objectShoot.transform.position;
        _shootRay.direction = _objectShoot.transform.forward;

        //Si el rayó chocó con algun objeto con esta mascara
        if (Physics.Raycast(_shootRay, out _hitShoot, _rangoDisparo, _shootleableMask))
        {
            //bajarle vida al enemigo, animacion, etc
            
            //Ajusta tamaño del lineRender con la posicion que chocó
            _lineRederShoot.SetPosition(1, _hitShoot.point);
        }
        else 
        {
            //Line render al frente con el rango seleccionado
            _lineRederShoot.SetPosition(1, _shootRay.origin + _shootRay.direction * _rangoDisparo);
        }

        Invoke("DisableEffects", _timeEffect);
    }

    void DisableEffects() 
    {
        _lineRederShoot.enabled = false;
        _lightShoot.enabled = false;
    }
}
