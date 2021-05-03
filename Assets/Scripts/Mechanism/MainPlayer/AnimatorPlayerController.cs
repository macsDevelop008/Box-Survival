using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorPlayerController : MonoBehaviour
{
    public static AnimatorPlayerController _shared;

    private Animator _animator;
    private float _valorX, _valorZ;


    private void Awake()
    {
        _shared = this;
    }

    private void Start()
    {
        _animator = PlayerManager._shared._animator;

    }

    private void Update()
    {
        AnimatorMove();
    }

    public void AnimatorMove()
    {
        _valorX = InputPlayerController._shared.joystickHorizontal;
        _valorZ = InputPlayerController._shared.joystickVertical;

        _animator.SetFloat("Run_X", _valorX);
        _animator.SetFloat("Run_Y", _valorZ);
        if (_valorX == 0.0f && _valorZ == 0.0f)
        {
            _animator.SetBool("Move", false);
            if (PlayerManager._shared.Attack) 
            {
                AnimatorAttack(true);
            }
        }
        else 
        {
            _animator.SetBool("Move", true);
            AnimatorAttack(false);
        }
    }

    public void AnimatorAttack(bool b) 
    {
        _animator.SetBool("Attack", b);
    }
    public bool AttackState() 
    {
        return _animator.GetBool("Attack");
    }
    public void Hit() 
    {
        _animator.SetTrigger("Hit");
    }

    public void GameOver() 
    {
        _animator.SetTrigger("Die");
    }
}
