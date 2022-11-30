using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class UIS : MonoBehaviour
{
    
    public GameObject text;
    public GameObject Pause;
    public GameObject GameOver;
    public GameObject Map;
    public GameObject Option;
    public Scores score;
    public Controls Controls;

    public bool game = false, pausep =false;

    private void Awake()
    {
        Controls = new Controls();
        game = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void Options()
    {
        
        text.SetActive(false);
        Map.SetActive(false);
        Option.SetActive(true);
        GameOver.SetActive(false);
        Pause.SetActive(false);
        pausep= false;
    }
    public void GameO()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Controls.P1.Disable();
        Controls.UI.Enable();
        text.SetActive(false);
        score.enabled = true;
        game = true;
        Invoke("parar", 2f);
        Map.SetActive(false);
        Option.SetActive(false);
        GameOver.SetActive(true);
        Pause.SetActive(false) ;
        
    }
    public void Paus() 
    {
        if (!game)
        {
            if (!pausep)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                text.SetActive(false);
                pausep = true;
                text.SetActive(false);
                Time.timeScale = 0.0f;
                Map.SetActive(false);
                Option.SetActive(false);
                GameOver.SetActive(false);
                Pause.SetActive(true);
                Controls.P1.Disable();
                Controls.UI.Enable();

            }
            else
            {
                Resume();
            }
        }
        
    }
    public void Restart()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Controls.P1.Enable();
        Controls.UI.Disable();
        SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex );
        Time.timeScale = 1.0f;
        game = false;
    }
    public void Menu()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(2);
        Time.timeScale = 1.0f;
    }
    public void Resume()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Controls.P1.Enable();
        Controls.UI.Disable();
        Map.SetActive(true);
        Option.SetActive(false);
        GameOver.SetActive(false);
        Pause.SetActive(false);
        pausep= false;
        Time.timeScale= 1.0f;
    }
    private void parar()
    {
        Time.timeScale = 0.0f;
    }

}
