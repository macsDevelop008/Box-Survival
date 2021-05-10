using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistenciaCuentaIniciada : MonoBehaviour
{
    public static PersistenciaCuentaIniciada _shared;

    public string CuentaActualIniciada { get; set; }

    private void Awake()
    {
        _shared = this;
    }
}
