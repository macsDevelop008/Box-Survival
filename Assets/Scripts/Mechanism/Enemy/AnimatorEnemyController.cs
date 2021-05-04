using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorEnemyController : MonoBehaviour
{
    [SerializeField] Animator _animator;

    public void DeadAnimator() 
    {
        _animator.SetTrigger("Dead");
    }

    public void AttackAnimator(bool b) 
    {
        _animator.SetBool("Attack", b);
    }
}
