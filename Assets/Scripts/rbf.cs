using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rbf : MonoBehaviour
{
    Rigidbody rb;
    float rotationZ;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()

    {
        
        rb.AddForce(0, 0, 4, ForceMode.Acceleration);
        Debug.Log(transform.rotation.z + " a");
        if (transform.rotation.z > 0.25f || transform.rotation.z < -0.25f){
            rotationZ = Mathf.Clamp(transform.rotation.z, -0.25f, 0.25f);
            transform.localEulerAngles = (new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, Mathf.LerpAngle(transform.localEulerAngles.z, rotationZ, Time.deltaTime))).normalized;
        }
        
    }

}
