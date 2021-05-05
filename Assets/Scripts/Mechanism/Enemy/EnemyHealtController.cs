using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealtController : MonoBehaviour
{
    float _vidaActual;
    [SerializeField] GameObject _particulasVFX;

    private void Start()
    {
        _vidaActual = this.GetComponent<EnemyController>().VidaMaxima;
    }

    public void SetHealt(float da�o) 
    {
        if (this.GetComponent<EnemyController>().Estado == EstadoEnemigo.LIFE) 
        {
            _vidaActual -= da�o;

            if (_vidaActual <= 0.0f)
            {
                Dead();
            }
        }
    }
    
    public void Dead() 
    {
        this.GetComponent<EnemyController>().Estado = EstadoEnemigo.DIE;

        this.GetComponent<Rigidbody>().velocity = Vector3.zero;

        this.GetComponent<Collider>().enabled = false;

        //Sangre particulas
        _particulasVFX.SetActive(true);

        //Score
        HUDEventos._shared.Score(this.GetComponent<EnemyController>().PuntosAlMorir);

        //Animacion
        //Desaparecer bajo el suelo
        //Destruir
        StartCoroutine(RutinaDead());
    }

    IEnumerator RutinaDead()
    {
        this.GetComponent<AnimatorEnemyController>().DeadAnimator();

        yield return new WaitForSeconds(1.5f);

        Destroy(this.gameObject);
    }

}
