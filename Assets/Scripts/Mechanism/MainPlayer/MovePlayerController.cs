using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerController : MonoBehaviour
{

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 inputSeleccionado = Vector3.zero;
        string tagRestriccion = PlayerManager._shared.RestriccionCalculomovimientoTagString;


        if (GameManager._shared.PlataformaSeleccionada == Plataforma.ESCRITORIO)
        {
            inputSeleccionado = new Vector3(InputPlayerController._shared.horizontal,
                                           0,
                                           InputPlayerController._shared.vertical);
        }
        else 
        if(GameManager._shared.PlataformaSeleccionada == Plataforma.MOVIL)
        {
            inputSeleccionado = new Vector3(InputPlayerController._shared.joystickHorizontal,
                                            0,
                                            InputPlayerController._shared.joystickVertical);
        }
        

        if (!RaycastPlayerController._shared.RayHitConstainsWitchInputPC().tag.Equals(tagRestriccion))
        {
            PlayerManager._shared._rigidbody.
                MovePosition(this.transform.position + inputSeleccionado
                                * PlayerManager._shared.VelocidadMovimiento
                                * Time.deltaTime);
        }
        else
        {
            Debug.LogWarning("No Puedo moverme en esa dirección");
        }



    }
}
