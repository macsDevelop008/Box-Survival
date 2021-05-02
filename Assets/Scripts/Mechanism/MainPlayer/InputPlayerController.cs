using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlayerController : MonoBehaviour
{
    //Singleton
    public static InputPlayerController _shared;

    //Entrada - Teclado
    public float horizontal { get; set; }
    public float vertical { get; set; }

    //Entrada - Movil
    [SerializeField] Joystick joystickMovimiento;
    [SerializeField] Joystick joystickRotacion;
    public float joystickHorizontal { get; set; }
    public float joystickVertical { get; set; }
    public float joystickHorizontal_Rotacion { get; set; }
    public float joystickVertical_Rotacion { get; set; }

    private void Awake()
    {
        _shared = this;
    }

    private void Update()
    {
        InputTeclado();
        InputJoytick();
    }

    void InputTeclado()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    void InputJoytick() 
    {
        //Posicion - (x), (z)
        joystickHorizontal = joystickMovimiento.Horizontal;
        joystickVertical = joystickMovimiento.Vertical;
        //Rotacion - (x), (z)
        joystickHorizontal_Rotacion = joystickRotacion.Horizontal;
        joystickVertical_Rotacion = joystickRotacion.Vertical;
    }


}
