using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;


public class UIS : MonoBehaviour
{
    Resolution[] resolutions;
    public RenderTexture im;
    public bool canPause = false;
    public TMP_Dropdown res;
    public GameObject text;
    public AudioMixer mixer;
    public GameObject post;
    public GameObject Pause;
    public GameObject GameOver;
    public GameObject Map;
    public GameObject Option;
    public Scores score;
    public Controls Controls;

    public bool game = false, pausep =false;

    private void Awake()
    {
        resolutions = Screen.resolutions;
        List<string> options = new List<string>();
        int currentindex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentindex = i;
            }
        }
        res.AddOptions(options);
        res.value = currentindex;
        res.RefreshShownValue();
        Controls = new Controls();
        game = false;
        UnityEngine.Cursor.visible = false;
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        pausep = false;
        Controls.P1.Enable();
        if (PlayerPrefs.GetFloat("Pixel") != 0 && PlayerPrefs.GetFloat("Pixel") >=0 )
        { 
            pixel(PlayerPrefs.GetFloat("Pixel"));
        }
        else
        {
            PlayerPrefs.SetFloat("Pixel", 0.25f);
            pixel(PlayerPrefs.GetFloat("Pixel"));
        }
       
        if (PlayerPrefs.GetFloat("Volumen") <= 0&& PlayerPrefs.GetFloat("Volumen") >= -80f)
        {
            volumen(PlayerPrefs.GetFloat("Volumen"));
        }
        else
        {
            PlayerPrefs.SetFloat("Volumen", 0);
            volumen(PlayerPrefs.GetFloat("Volumen"));
        }

        if (PlayerPrefs.GetInt("Resol" ) != 0 && PlayerPrefs.GetInt("Grafics") <= resolutions.Length) { 
        resol(PlayerPrefs.GetInt("Resol")); 
         }
        else
        {
            PlayerPrefs.GetInt("Resol", 0);
            resol(PlayerPrefs.GetInt("Resol"));
        }
        if(PlayerPrefs.GetInt("Grafics") >= 0 )
        {
            Graphs(PlayerPrefs.GetInt("Grafics"));
        }
        else
        {

        }
        
        if (PlayerPrefs.GetInt("Post") == 0)
        {
            PostP(false);
        }
        else
        {
            PostP(true);
        }
        if(PlayerPrefs.GetInt("Full") == 0)
        {
            Full(false);
        }
        else {
            Full(true);
        }



    }
    public void Options()
    {
        Option.GetComponent<SelectButton>().reselect();
        text.SetActive(false);
        Map.SetActive(false);
        Option.SetActive(true);
        GameOver.SetActive(false);
        Pause.SetActive(false);
        pausep= false;
    }
    public void GameO()
    {
        GameOver.GetComponent<SelectButton>().reselect();
        UnityEngine.Cursor.visible = true;
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        Controls.P1.Disable();

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
            if (!pausep && canPause)
            {
                Pause.GetComponent<SelectButton>().reselect();
                UnityEngine.Cursor.visible = true;
                UnityEngine.Cursor.lockState = CursorLockMode.None;
                text.SetActive(false);
                pausep = true;
                text.SetActive(false);
                Time.timeScale = 0.0f;
                Map.SetActive(false);
                Option.SetActive(false);
                GameOver.SetActive(false);
                Pause.SetActive(true);
                Controls.P1.Disable();

            }
            else
            {
                Resume();
            }
        }
        
    }
    public void Restart()
    {
        UnityEngine.Cursor.visible = false;
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        Controls.P1.Enable();

        SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex );
        Time.timeScale = 1.0f;
        game = false;
    }
    public void Menu()
    {
        UnityEngine.Cursor.visible = true;
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(2);
        Time.timeScale = 1.0f;
    }
    public void Resume()
    {
        UnityEngine.Cursor.visible = false;
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        Controls.P1.Enable();

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
    public void PostP(bool toggle)
    {
        int b;
        if (toggle) {
            PlayerPrefs.SetInt("Post", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Post", 0);
        }
        
        post.SetActive(toggle);
    }
    public void volumen(float a)
    {
        PlayerPrefs.SetFloat("Volumen", a);
        mixer.SetFloat("volume",a);
        
    }
    public void Graphs(int graphS)
    {
        PlayerPrefs.SetInt("Grafics",graphS);
        QualitySettings.SetQualityLevel(graphS);
    }
    public void Full( bool scren)
    {

        if (scren)
        {
            PlayerPrefs.SetInt("Full", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Full", 0);
        }
        Screen.fullScreen=scren;    
        
    }
    public void resol(int index)
    {
        PlayerPrefs.SetInt("Resol", index);
        Resolution resolution = resolutions[index];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void pixel(float a)
    {
        PlayerPrefs.SetFloat("Pixel", a);
        im.Release();
        im.height= (int)(Screen.height *a);
        im.width = (int)(Screen.width * a);
        im.Create();
    }
}
