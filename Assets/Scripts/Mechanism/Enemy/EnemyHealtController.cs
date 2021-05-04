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

    public void SetHealt(float daño) 
    {
        if (this.GetComponent<EnemyController>().Estado == EstadoEnemigo.LIFE) 
        {
            _vidaActual -= daño;

            if (_vidaActual <= 0.0f)
            {
                Dead();
            }
        }
    }
    
    public void Dead() 
    {
        this.GetComponent<EnemyController>().Estado = EstadoEnemigo.DIE;

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

        this.transform.position = Vector3.MoveTowards(
            this.transform.position
            , new Vector3(this.transform.position.x, this.transform.position.y - 25.0f, this.transform.position.z)
            , 5.0f);
        yield return new WaitForSeconds(1.5f);

        Destroy(this.gameObject);
    }

}
