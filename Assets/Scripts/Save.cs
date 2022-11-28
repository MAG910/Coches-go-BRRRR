using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Save : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Guardar(float time)
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 3:
                if (PlayerPrefs.GetFloat("EasyHS") > time)
                {
                    PlayerPrefs.SetFloat("EasyHS", time);
                }
                break;

            case 4:
                if (PlayerPrefs.GetFloat("MidHS") > time)
                {
                    PlayerPrefs.SetFloat("MidHS", time);
                }
                break;

            case 5:
                if (PlayerPrefs.GetFloat("HighHS") > time)
                {
                    PlayerPrefs.SetFloat("HighHS", time);
                }
                break;

            case 6:
                if (PlayerPrefs.GetFloat("TubeyHS") > time)
                {
                    PlayerPrefs.SetFloat("TubeHS", time);
                }
                break;

            case 7:
                 if (PlayerPrefs.GetFloat("InCHS") > time)
                {
                    PlayerPrefs.SetFloat("InCHS", time);
                }
               
                break;

            case 8:
                if (PlayerPrefs.GetFloat("InTHS") > time)
                {
                    PlayerPrefs.SetFloat("InTHS", time);
                }
               
                break;

            default:    
                break;
        }
       

        
    }
    public float Load()
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 3:
                return PlayerPrefs.GetFloat("EasyHS");
  
                break;

            case 4:
                return PlayerPrefs.GetFloat("MidHS");
                
                break;

            case 5:
                return PlayerPrefs.GetFloat("HighHS");
                break;

            case 6:
                return PlayerPrefs.GetFloat("TubeyHS");
                break;

            case 7:
                return PlayerPrefs.GetFloat("InCHS");

                break;

            case 8:
                return PlayerPrefs.GetFloat("InTHS");

                break;

            default:
                return -1;
                break;
        }



    }
}
