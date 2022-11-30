using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scores : MonoBehaviour
{
    public TextMeshProUGUI hs;
    public Save Managerp;
    public TextMeshProUGUI ts;
    public GameObject ne;
    public float actuallap;
    public float hslap;
    private void Awake()
    {
        Managerp = Managerp.GetComponent<Save>();
        hs = hs.GetComponent<TextMeshProUGUI>();
        ts = ts.GetComponent<TextMeshProUGUI>();
        actuallap = GameObject.Find("Meta").GetComponent<Meta>().besttime;
        hslap = Managerp.Load();
        

        hs.text = "Best time : " + Mathf.FloorToInt(hslap / 60) + " : " + (Mathf.Floor(hslap % 60) + ((hslap - (int)hslap).ToString(".000")));
        ts.text = "Your time : " + Mathf.FloorToInt(actuallap / 60) + " : " + (Mathf.Floor(actuallap % 60) + ((actuallap - (int)actuallap).ToString(".000")));

    }
    private void Start()
    {
        if (actuallap == hslap)
        {
            ne.SetActive(true);
        }
      
    }
}
