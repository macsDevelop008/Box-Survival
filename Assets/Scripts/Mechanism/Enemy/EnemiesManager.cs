using System.Collections.Generic;
using UnityEngine;


public enum EstadoEnemigo
{
    LIFE, DIE
}
public class EnemiesManager : MonoBehaviour
{
    public static EnemiesManager _shared;

    [SerializeField] float _maximoNumeroZombiesEnEscena;
    [SerializeField] List<GameObject> _listZombiesEnEscena;


    private void Awake()
    {
        _shared = this;
    }

    private void Start()
    {
        _listZombiesEnEscena = new List<GameObject>();
    }

    public float MaximoNumZombiePermitido() 
    {
        return _maximoNumeroZombiesEnEscena;
    }

    public void A�adirZombie(GameObject o) 
    {
        _listZombiesEnEscena.Add(o);
    }

    public void EliminarZombie(GameObject o) 
    {
        if (_listZombiesEnEscena.Contains(o)) 
        {
            _listZombiesEnEscena.Remove(o);
        }
    }

    public float Tama�oListaZombies()
    {
        return _listZombiesEnEscena.Count;
    }
}
