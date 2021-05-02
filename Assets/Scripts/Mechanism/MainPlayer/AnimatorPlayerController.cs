using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorPlayerController : MonoBehaviour
{
    private Animator _animator;
    private float _valorX, _valorZ;

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
        if (_valorX <= 0.0f && _valorZ <= 0.0f)
        {
            _animator.SetBool("Move", false);
        }
        else 
        {
            _animator.SetBool("Move", true);
        }
    }
}
