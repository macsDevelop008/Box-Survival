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
    [SerializeField] GameObject _hudDa�o;

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

        //HUD da�o
        StartCoroutine(rutinaDa�o());

        //Calcular si es game over o no
        GameManager._shared.GameOver();

    }

    IEnumerator rutinaDa�o() 
    {
        _hudDa�o.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        _hudDa�o.SetActive(false);
    }

    public float VidaActual()
    {
        return _vidaActual;
    }
}
