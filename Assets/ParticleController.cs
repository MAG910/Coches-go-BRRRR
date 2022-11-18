using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    Rigidbody rb;

    public TrailRenderer[] particlesystem;

    float angle;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        angle = Input.GetAxis("Sideways");
        float f;
        if(angle > 0)
        {
            f = 1;
        }
        else if (angle < 0)
        {
            f = 1;
        }
        else
        {
            f = 0;

        }

        foreach(TrailRenderer p in particlesystem)
        {
            p.time = f;
        }
    }
}
