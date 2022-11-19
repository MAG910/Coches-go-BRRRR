<<<<<<< HEAD
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
=======
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
>>>>>>> 9f9832784973f81ea3f3f21bffa89fb39639313e
