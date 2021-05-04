using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealtPlayerController : MonoBehaviour
{
    
    public static HealtPlayerController _shared;
    [SerializeField] Slider _sliderHealth;
    float _vidaActual;
    //HUD
    [SerializeField] GameObject _hudDaño;

    private void Awake()
    {
        _shared = this;
    }

    private void Start()
    {
        _vidaActual = PlayerManager._shared.VidaMaxima;  
    }

    public float GetVidaActual() 
    {
        return _vidaActual;
    }

    public void SetHealt(float num) 
    {
        _vidaActual -= num;

        //Modificar vida en el HUD
        _sliderHealth.value = _vidaActual;

        //HUD daño
        StartCoroutine(rutinaDaño());

        //Calcular si es game over o no
        GameManager._shared.GameOver();

    }

    IEnumerator rutinaDaño() 
    {
        _hudDaño.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        _hudDaño.SetActive(false);
    }

    public float VidaActual()
    {
        return _vidaActual;
    }
}
