using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    
    public GameObject MenuP;
    private bool p = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (p)
            {
                Resume();
            }
            else
            {
                P();
            }
        }
    }
    public void P()
    {
        p= true;    
        Time.timeScale = 0;
        
        MenuP.SetActive(true);
    }

    public void Resume()
    {
        p = false;
        Time.timeScale = 1;
       
        MenuP.SetActive(false);
    }
    public void Restart()
    {
        p = false ;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
