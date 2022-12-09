using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectButton : MonoBehaviour
{
    public Button pbutton;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void reselect()
    {
        pbutton.Select();
    }

}
