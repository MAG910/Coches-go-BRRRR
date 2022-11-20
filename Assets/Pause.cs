using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject Menu;
    public bool enabledd = false;

    private void Start()
    {
        Menu.SetActive(false);
        enabledd = false;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !enabledd)
        {
            enabledd = true;
            Menu.SetActive(true);
            Time.timeScale = 0;
            return;
            Debug.Log("a");
        }
        if (Input.GetKeyDown(KeyCode.Escape) && enabledd)
        {
            enabledd = false;
            Menu.SetActive(false);
            Time.timeScale = 1;
            return;
        }
    }

    public void ExitToMenu()
    {
        enabledd = false;
        Menu.SetActive(false);

        Time.timeScale = 1;

        SceneManager.LoadScene("Menu");

    }
    public void Resume()
    {
        enabledd = false;
        Menu.SetActive(false);
        Time.timeScale = 1;
    }
}
