using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carSound : MonoBehaviour
{
    public AudioSource carAudio;
    public float pitchfactor;
    Rigidbody rb;

    float vel;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        vel = Mathf.Round(rb.velocity.magnitude);

        carAudio.pitch = vel / pitchfactor;
    }
}
