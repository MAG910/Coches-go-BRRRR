using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class copyPos : MonoBehaviour
{
    public Transform tocpy;
    void Update()
    {
        transform.position = tocpy.position;
    }
}
