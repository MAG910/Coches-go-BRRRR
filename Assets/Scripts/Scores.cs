using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scores : MonoBehaviour
{
    public TextMeshProUGUI hs;
    public Save Managerp;
    public Meta Meta;
    public TextMeshProUGUI ts;
    public float actuallap;
    public float hslap;

    private void Start()
    {
        Meta= Meta.GetComponent<Meta>();
        Managerp = Managerp.GetComponent<Save>();
        hs=  hs.GetComponent<TextMeshProUGUI>();
        ts = ts.GetComponent<TextMeshProUGUI>();
        actuallap = Meta.lastlap;
        hslap = Managerp.Load();
    }
    private void Update()
    {

        Debug.Log(actuallap = Meta.lastlap);
        hs.text = "High score : " + Mathf.FloorToInt(hslap / 60) + " : " + Mathf.FloorToInt(hslap % 60);
        ts.text = "Your score : " + Mathf.FloorToInt(actuallap / 60) + " : " + Mathf.FloorToInt(actuallap % 60);

    }
}
