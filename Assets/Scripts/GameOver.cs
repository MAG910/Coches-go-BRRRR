using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject menu;
    private void Awake()
    {
        menu.SetActive(true);
    }
    public void restartt()
    {
        //SceneManager.LoadScene();
        Debug.Log("restart");
    }
    public void mainMenu()
    {
        //SceneManager.LoadScene();
        Debug.Log("MainMenu");
    }
}
