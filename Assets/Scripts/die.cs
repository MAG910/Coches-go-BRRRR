using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class die : MonoBehaviour
{
    GameObject UI;


    public bool ded;

    public bool isDed;


    private void Start()
    {
        UI = GameObject.Find("UI");

        ded = false;
        isDed = false;
    }

    private void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.CompareTag("Player"))
        {
            ded = true;
            UI.GetComponent<UIS>().GameO();


        }



    }
}
