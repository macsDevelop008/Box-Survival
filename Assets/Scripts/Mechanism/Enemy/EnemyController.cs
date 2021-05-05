using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    [SerializeField] EstadoEnemigo _estado;
    [SerializeField] float _da�oAlPlayer;
    [SerializeField] float _vidaMaxima;
    [SerializeField] float _puntosAlMorir;

    public EstadoEnemigo Estado{ get { return _estado; } set { _estado = value; } }
    public float Da�o { get { return _da�oAlPlayer; } set { _da�oAlPlayer = value; } }
    public float VidaMaxima { get { return _vidaMaxima; } set { _vidaMaxima = value; } }
    public float PuntosAlMorir { get { return _puntosAlMorir; } set { _puntosAlMorir = value; } }

    private void Start()
    {
        _estado = EstadoEnemigo.LIFE;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") 
            && GameManager._shared.EstadoJuego == EstadoJuego.InGame
              && _estado == EstadoEnemigo.LIFE) 
        {
            this.GetComponent<AnimatorEnemyController>().AttackAnimator(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") 
            && GameManager._shared.EstadoJuego == EstadoJuego.InGame
              && _estado == EstadoEnemigo.LIFE)
        {
            this.GetComponent<AnimatorEnemyController>().AttackAnimator(false);

        }
    }

}
