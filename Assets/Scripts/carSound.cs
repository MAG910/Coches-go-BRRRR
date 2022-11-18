using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carSound : MonoBehaviour
{
    public AudioSource carAudio;
    public float pitchfactor;
    Rigidbody rb;

    public Animator anim;

    float vel, animd;
    float b;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        vel = Mathf.Round(rb.velocity.magnitude);

        carAudio.pitch = vel / pitchfactor;

        float input = Input.GetAxis("Sideways");
        float a;
        if(input > 0)
        {
            a = 0;
        }
        else if (input < 0)
        {
            a = 1;
        }
        else
        {
            a = 0.5f;
        }
        b = Mathf.Lerp(b, a, 10 * Time.deltaTime);
        anim.SetFloat("Blend", b);

        
    }
}
