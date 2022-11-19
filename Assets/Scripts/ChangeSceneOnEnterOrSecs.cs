using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class ChangeSceneOnEnterOrSecs : MonoBehaviour
{
    public string SceneName;

    public float timeBeforeChange;

    public bool CanChangeOnTime = true;
    
    
    void Update()
    {
        timeBeforeChange -= Time.deltaTime;

        if(timeBeforeChange <= 0 && CanChangeOnTime)
        {
            Change();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Change();
        }

    }

    private void Change()
    {
        SceneManager.LoadScene(SceneName);
    }
}
