using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class girar : MonoBehaviour
{
  
    void Update()
    {
        transform.Rotate(0, 0, -Input.GetAxis("Sideways") * 2);
    }
}
