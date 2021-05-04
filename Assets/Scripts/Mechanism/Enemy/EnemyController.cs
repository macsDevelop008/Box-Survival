using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    [SerializeField] EstadoEnemigo _estado;
    [SerializeField] float _daño;
    [SerializeField] float _vidaMaxima;

    public EstadoEnemigo Estado{ get { return _estado; } set { _estado = value; } }
    public float Daño { get { return _daño; } set { _daño = value; } }
    public float VidaMaxima { get { return _vidaMaxima; } set { _vidaMaxima = value; } }

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
