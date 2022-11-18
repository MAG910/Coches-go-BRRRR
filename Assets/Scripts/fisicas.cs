using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fisicas : MonoBehaviour
{
    public Transform tubo;

    public GameObject Coche;
    void Update()
    {
        tubo.transform.Rotate(0, 0, Input.GetAxis("Sideways"));

    }
}
