using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsAnimationEnemyController : MonoBehaviour
{
    public void AttackPlayer() 
    {
        if (GameManager._shared.EstadoJuego == EstadoJuego.InGame) 
        {
            float daño = transform.parent.GetComponent<EnemyController>().Daño;

            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<HealtPlayerController>().SetHealt(daño);
        }

    }
}
