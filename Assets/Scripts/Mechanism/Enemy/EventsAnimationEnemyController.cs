using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsAnimationEnemyController : MonoBehaviour
{
    public void AttackPlayer() 
    {
        if (GameManager._shared.EstadoJuego == EstadoJuego.InGame) 
        {
            float da�o = transform.parent.GetComponent<EnemyController>().Da�o;

            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<HealtPlayerController>().SetHealt(da�o);
        }

    }
}
