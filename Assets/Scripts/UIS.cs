using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIS : MonoBehaviour
{
    public GameObject Pause;
    public GameObject GameOver;
    public GameObject Map;
    public GameObject Option;
    public Scores score;
    
    public bool game = false, pausep =false;

    private void Awake()
    {
        game = false;
        
    }
    public void Options()
    {
        Map.SetActive(false);
        Option.SetActive(true);
        GameOver.SetActive(false);
        Pause.SetActive(false);
        pausep= false;
    }
    public void GameO()
    {
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
                pausep = true;

                Time.timeScale = 0.0f;
                Map.SetActive(false);
                Option.SetActive(false);
                GameOver.SetActive(false);
                Pause.SetActive(true);
               
            }
            else
            {
                Resume();
            }
        }
        
    }
    public void Restart()
    {
        SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex );
        Time.timeScale = 1.0f;
        game = false;
    }
    public void Menu()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1.0f;
    }
    public void Resume()
    {
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
