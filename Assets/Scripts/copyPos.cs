using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class copyPos : MonoBehaviour
{
    public Transform tocpy;
    float rotationx = 0;
    float rotationz = 0;

    private void Awake()
    {
        rotationx= transform.eulerAngles.x;
        rotationz = transform.eulerAngles.z;
    }
    void Update()
    {
        transform.position = new Vector3(tocpy.position.x,50,tocpy.transform.position.z);
        transform.localEulerAngles=new Vector3(rotationx, tocpy.transform.eulerAngles.y+35,rotationz);
        
        
    }
}
