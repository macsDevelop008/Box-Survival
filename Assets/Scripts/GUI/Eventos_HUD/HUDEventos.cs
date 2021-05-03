using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HUDEventos : MonoBehaviour
{
    int _contadorAttack;
    [SerializeField] Button _btnAttack;
    ColorBlock _colorBlockAttack;

    private void Start()
    {
        _contadorAttack = 0;
        _colorBlockAttack = _btnAttack.colors;
    }

    public void JoystickRotationController_Up() 
    {
        PlayerManager._shared._permanecerRotacion = false;
    }

    public void JoystickRotationController_Down()
    {
        PlayerManager._shared._permanecerRotacion = true;
    }


    public void Attack() 
    {
        if (GameManager._shared.EstadoJuego == EstadoJuego.InGame) 
        {
            if (_contadorAttack == 0)
            {
                AutoAttack();
                _contadorAttack = 1;
            }
            else
            {
                StopAttack();
                _contadorAttack = 0;
            }
        }
    }
    void AutoAttack()
    {
        PlayerManager._shared.Attack = true;
        AnimatorPlayerController._shared.AnimatorAttack(true);
        _colorBlockAttack.normalColor = new Color(255.0f, 131.0f, 131.0f);
    }

    void StopAttack() 
    {
        PlayerManager._shared.Attack = false;
        AnimatorPlayerController._shared.AnimatorAttack(false);
        _colorBlockAttack.normalColor = new Color(255.0f, 255.0f, 255.0f);
    }
}