using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
    }

    public void ToEasy()
    {
        SceneManager.LoadScene("Easy");
    }
    public void ToMed()
    {
        SceneManager.LoadScene("Med");
    }
    public void ToSus()
    {
        SceneManager.LoadScene("Sus");
    }

}
