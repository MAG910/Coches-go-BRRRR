using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class copyPos : MonoBehaviour
{
    public Transform tocpy;

    void Update()
    {
        transform.position = new Vector3(tocpy.position.x,50,tocpy.transform.position.z);
        transform.localRotation.Set(90, tocpy.transform.rotation.y,0,0);
        
        
    }
}
