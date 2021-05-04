using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealtController : MonoBehaviour
{
    [SerializeField] float _vidaActual;

    private void Start()
    {
        _vidaActual = this.GetComponent<EnemyController>().VidaMaxima;
    }

    public void SetHealt(float daño) 
    {
        _vidaActual -= daño;

        if (_vidaActual <= 0.0f) 
        {
            Dead();
        }
    }
    
    public void Dead() 
    {
        this.GetComponent<EnemyController>().Estado = EstadoEnemigo.DIE;

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
            , new Vector3(this.transform.position.x, this.transform.position.y - 5.0f, this.transform.position.z)
            , 5.0f);
        yield return new WaitForSeconds(1.5f);

        Destroy(this.gameObject);
    }

}
