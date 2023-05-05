using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public Button button;
    public string sceneName;
    void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Change);
    }
    void Change()
    {
        SceneManager.LoadScene(sceneName);
    }
}
