using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationPlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        if (GameManager._shared.EstadoJuego == EstadoJuego.InGame) 
        {
            Rotation();
        }
            
    }

    void Rotation() 
    {
        if (PlayerManager._shared._permanecerRotacion) 
        {
            //float velocidad = PlayerManager._shared.VelocidadRotacion;
            float h = -InputPlayerController._shared.joystickHorizontal_Rotacion;
            float v = InputPlayerController._shared.joystickVertical_Rotacion;

            float angulo = Mathf.Atan2(h, v) * Mathf.Rad2Deg;
            this.transform.eulerAngles = new Vector3(0, -angulo, 0);
        }
    }
}
