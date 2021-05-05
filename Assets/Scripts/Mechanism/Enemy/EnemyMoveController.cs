using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveController : MonoBehaviour
{
    Transform _player;
    NavMeshAgent _nav;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _nav = this.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (GameManager._shared.EstadoJuego == EstadoJuego.InGame)
        {
            if (this.GetComponent<EnemyController>().Estado == EstadoEnemigo.LIFE) 
            {
                Move();
            }            
        }
    }

    public void Move()
    {
        _nav.SetDestination(_player.position);       
    }
}
