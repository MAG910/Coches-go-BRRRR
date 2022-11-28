using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Build;
using UnityEngine;

public class Meta : MonoBehaviour
{
    public GameObject Generador;
    public GameObject Manager;
    public GameObject text;
    public float lastlap = 1234;
    public float  laptime;
    public GameObject blok;
    bool hasStartedLap = false;
    float startTime;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (hasStartedLap)
            {
               
                if (laptime < lastlap) { lastlap = laptime; }
                Manager.GetComponent<Save>().Guardar(lastlap);
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
            text.GetComponent<TextMeshProUGUI>().text=Mathf.FloorToInt(laptime/60) + " : " + Mathf.FloorToInt(laptime%60) ;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            hasStartedLap = true;
            startTime = Time.time;
        }

    }
    private void activate()
    {
        blok.SetActive(true);
    }
}

