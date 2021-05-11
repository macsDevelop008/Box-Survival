using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Registro : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI _numero, _nombre, _score;

    public TextMeshProUGUI Numero { get { return _numero; } set { _numero = value; } }
    public TextMeshProUGUI Nombre { get { return _nombre; } set { _nombre = value; } }
    public TextMeshProUGUI Score { get { return _score; } set { _score = value; } }
}
