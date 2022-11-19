using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MenuManager : MonoBehaviour
{
    public void Quit()
    {
        float menu = 2;
        var emitter = GetComponent<FMODUnity.StudioEventEmitter>();
        emitter.SetParameter("menuInputType", menu);
        emitter.Play();
        Application.Quit();
    }

    public void ToEasy()
    {
        float menu = 1;
        var emitter = GetComponent<FMODUnity.StudioEventEmitter>();
        emitter.SetParameter("menuInputType", menu);
        emitter.Play();
        SceneManager.LoadScene("Easy");
    }
    public void ToMed()
    {
        float menu = 1;
        var emitter = GetComponent<FMODUnity.StudioEventEmitter>();
        emitter.SetParameter("menuInputType", menu);
        emitter.Play();
        SceneManager.LoadScene("Med");
    }
    public void ToSus()
    {
        float menu = 1;
        var emitter = GetComponent<FMODUnity.StudioEventEmitter>();
        emitter.SetParameter("menuInputType", menu);
        emitter.Play();
        SceneManager.LoadScene("Sus");
    }

}
