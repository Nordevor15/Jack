using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextoInicio : MonoBehaviour
{
    public GameObject panelTexto;
    void Start()
    {
        Time.timeScale = 0f;
    }
    public void boton()
    {
        Time.timeScale = 1f;
        panelTexto.SetActive(false);    
    }
}
