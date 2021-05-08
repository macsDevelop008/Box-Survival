using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeccionInternet : MonoBehaviour
{
    public static ConeccionInternet _shared;

    private void Awake()
    {
        _shared = this;
    }
    //Si está conectado a internet.
    public bool coneccionRed()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
