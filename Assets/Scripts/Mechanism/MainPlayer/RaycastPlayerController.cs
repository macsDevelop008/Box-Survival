using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastPlayerController : MonoBehaviour
{
    public static RaycastPlayerController _shared;

    Ray ray;
    RaycastHit hit;
    float distancia;

    private void Awake()
    {
        _shared = this;
    }

    private void FixedUpdate()
    {
        
    }

    public GameObject RayHitConstainsWitchInputPC() 
    {
        try 
        {
            Vector3 origen = Vector3.zero;
            Vector3 direccion = Vector3.zero;

            if (GameManager._shared.PlataformaSeleccionada == Plataforma.ESCRITORIO)
            {
                origen = this.transform.position + new Vector3(0, 0.5f, 0);
                direccion = new Vector3(InputPlayerController._shared.horizontal,
                                                0,
                                                InputPlayerController._shared.vertical);
            }
            else 
            if (GameManager._shared.PlataformaSeleccionada == Plataforma.MOVIL)
            {
                origen = this.transform.position + new Vector3(0, 0.5f, 0);
                direccion = new Vector3(InputPlayerController._shared.joystickHorizontal,
                                                0,
                                                InputPlayerController._shared.joystickVertical);
            }         

            ray = new Ray(origen, direccion);

            distancia = PlayerManager._shared.RestriccionCalculomovimientoDistancia;

            Physics.Raycast(ray, out hit, distancia);

            return hit.collider.gameObject;
        } 
        catch (System.Exception e) 
        {
            Debug.LogWarning(e);
        }

        return this.gameObject;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(ray);
    }
    
}
