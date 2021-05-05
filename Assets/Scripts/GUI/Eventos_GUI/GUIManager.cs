using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GUIManager : MonoBehaviour
{
    [SerializeField] Text _scorePersonalTXT;

    [SerializeField] GameObject _panelCargando;

    private void Start()
    {
        ImprimirScorePersonal();
    }

    void ImprimirScorePersonal()
    {
        _scorePersonalTXT.text = PersistenciaPersonal._shared.DarScorePersonalPersistencia().ToString();
    }

    //Evento Boton Play
    public void PlayGame() 
    {
        _panelCargando.SetActive(true);
        SceneManager.LoadScene("01_Nivel");
    }
}
