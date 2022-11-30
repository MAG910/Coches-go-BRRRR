using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;

public class Meta : MonoBehaviour
{
    public GameObject Generador;
    public GameObject Manager;
    public GameObject text;

    public float lastlap = 0;
    public float besttime = 0;
    public float  laptime;
    public GameObject blok;
    public bool hasStartedLap = false;
    float startTime;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (hasStartedLap)
            {
               
               
                 lastlap = laptime; 
                if(besttime> lastlap||besttime==0) {
                    besttime = lastlap;
                    Manager.GetComponent<Save>().Guardar(besttime);
                }
               
            }

            startTime = Time.time;
            foreach (var gameObj in GameObject.FindGameObjectsWithTag("CanDie"))
            {
                Destroy(gameObj);

            }
            foreach (var gameObj in GameObject.FindGameObjectsWithTag("Turbo"))
            {
                
                Destroy(gameObj);
            }

            Generador.GetComponent<ObstaculosGen>().crear();
            blok.SetActive(false);
            Invoke("activate", 2f);
        }
    }
    private void Update()
    {
        if (hasStartedLap) {
            laptime = Time.time - startTime;
            text.GetComponent<TextMeshProUGUI>().text = Mathf.FloorToInt(laptime / 60) + " : " + (Mathf.Floor(laptime % 60) + ((laptime - (int)laptime).ToString(".000")));

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            hasStartedLap = true;
            startTime = Time.time;
            text.SetActive(true);
        }

    }
    private void activate()
    {
        blok.SetActive(true);
    }
}

