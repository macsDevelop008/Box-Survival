using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager _shared;

    [Header("MoveTarget")]
    [SerializeField] Transform _target;
    [SerializeField] float _smoothTime;

    public Transform TargetMoveTarget { get { return _target; } }
    public float SmoothTimeMovetarget { get { return _smoothTime; } }

    private void Awake()
    {
        _shared = this;
    }

}
