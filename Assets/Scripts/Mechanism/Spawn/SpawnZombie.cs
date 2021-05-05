using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombie : MonoBehaviour
{

    [SerializeField] float _tiempoMinSpawn, _tiempoMaxSpawn;
    float _tiempoRandom;
    float _tiempoContador;

    [SerializeField] GameObject[] _prefabsZombies;

    private void Start()
    {
        _tiempoContador = 0.0f;
        _tiempoRandom = GetNuevoTiempoRandom();
    }

    private void Update()
    {
        //print(Random.Range(0, 2));
        if (GameManager._shared.EstadoJuego == EstadoJuego.InGame)
        {
            _tiempoContador += Time.deltaTime;

            if (_tiempoContador >= _tiempoRandom)
            {
                _tiempoContador = 0.0f;
                _tiempoRandom = GetNuevoTiempoRandom();
                InvokeZombie();
            }
        }
    }

    void InvokeZombie() 
    {
        GameObject zombie = Instantiate(_prefabsZombies[Random.Range(0, _prefabsZombies.Length)]
                                        , this.gameObject.transform);
    }

    float GetNuevoTiempoRandom() 
    {
        return Random.Range(_tiempoMinSpawn, _tiempoMaxSpawn);
    }

}
