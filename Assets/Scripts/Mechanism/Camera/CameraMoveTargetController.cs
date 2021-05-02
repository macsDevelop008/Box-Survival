using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveTargetController : MonoBehaviour
{

    private Vector3 _diferenciaInicialTargetToCamera;

    private void Start()
    {
        _diferenciaInicialTargetToCamera = CameraManager._shared.TargetMoveTarget.transform.position
                                            - this.transform.position;
    }

    void Update()
    {
        if (GameManager._shared.EstadoJuego == EstadoJuego.InGame) 
        {
            MoveTargetPlayer();
        }
    }

    void MoveTargetPlayer() 
    {
        Vector3 currecntVelocity = Vector3.zero;
        this.transform.position = Vector3.SmoothDamp(
                                                        this.transform.position,
                                                        CameraManager._shared.TargetMoveTarget.transform.position - _diferenciaInicialTargetToCamera,
                                                        ref currecntVelocity,
                                                        CameraManager._shared.SmoothTimeMovetarget,
                                                        Mathf.Infinity,
                                                        Time.deltaTime
                                                    );
    }
}
