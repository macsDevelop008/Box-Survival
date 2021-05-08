using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class HUDEventos : MonoBehaviour
{
    public static HUDEventos _shared;

    [Header("BOTON ATACAR")]
    //Boton atacar
    int _contadorAttack;
    [SerializeField] Button _btnAttack;
    ColorBlock _colorBlockAttack;

    [Header("VENTANA GAMEOVER")]
    //Ventana GameOver
    [SerializeField] Text _scoreActual, _scoreMaxPersonal, _logroEntrarTop;

    [Header("VENTANA SETTINGS")]
    [SerializeField] GameObject _panelSettings;

    //Score
    float ContadorScore { get; set; }
    [Header("SCORE")]
    [SerializeField] TextMeshProUGUI _scoreTXT;


    private void Awake()
    {
        _shared = this;
    }
    private void Start()
    {
        _contadorAttack = 0;
        _colorBlockAttack = _btnAttack.colors;
        Score(0);
    }

    public void JoystickRotationController_Up() 
    {
        PlayerManager._shared._permanecerRotacion = false;
    }

    public void JoystickRotationController_Down()
    {
        PlayerManager._shared._permanecerRotacion = true;
    }

    public void Score(float n) 
    {
        //HUD
        ContadorScore += n;
        _scoreTXT.text = ContadorScore.ToString();

        //Enviar al PersistenciaPersonal
        PersistenciaPersonal._shared.ModificarScorePersonalPersistencia(ContadorScore);
    }

    public void Attack() 
    {
        if (GameManager._shared.EstadoJuego == EstadoJuego.InGame) 
        {
            if (_contadorAttack == 0)
            {
                AutoAttack();
                _contadorAttack = 1;
            }
            else
            {
                StopAttack();
                _contadorAttack = 0;
            }
        }
    }
    void AutoAttack()
    {
        PlayerManager._shared.Attack = true;
        AnimatorPlayerController._shared.AnimatorAttack(true);
        _colorBlockAttack.normalColor = new Color(255.0f, 131.0f, 131.0f);
    }

    void StopAttack() 
    {
        PlayerManager._shared.Attack = false;
        AnimatorPlayerController._shared.AnimatorAttack(false);
        _colorBlockAttack.normalColor = new Color(255.0f, 255.0f, 255.0f);
    }

    //-------------

    public void GameOverTextos()
    {
        _scoreActual.text = ContadorScore.ToString();
        _scoreMaxPersonal.text = PersistenciaPersonal._shared.
                                        DarScorePersonalPersistencia().ToString();

        //Logró entrar o no al top 10
        //_logroEntrarTop.text = ""
    }

    //------------
    public void PanelGameOver_Reset() 
    {
        SceneManager.LoadScene("01_Nivel");
    }

    public void PanelGameOver_BackToMenu()
    {
        SceneManager.LoadScene("00_GUI");
    }

    //------------
    public void Settings() 
    {
        _panelSettings.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void SettingsBackToMenu()
    {
        SceneManager.LoadScene("00_GUI");
    }

    public void SettingsResume()
    {
        _panelSettings.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
