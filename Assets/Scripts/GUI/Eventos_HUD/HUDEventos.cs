using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDEventos : MonoBehaviour
{
    public void JoystickRotationController_Up() 
    {
        PlayerManager._shared._permanecerRotacion = false;
    }

    public void JoystickRotationController_Down()
    {
        PlayerManager._shared._permanecerRotacion = true;
    }
}
