using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAudio : MonoBehaviour
{
    //public AudioSource carAudio; Ahora lo hace FMOD
    //public float pitchfactor; Ahora lo hace FMOD
    Rigidbody rb;
    //SecondOrderDynamics1D dynamicsRPM;

    public Animator anim; // No lo toco no se lo que es

    float vel, effectiveVel;
    float animd;
    float b;

    float Dvel, lastVel;
    float f, z, r, x0; //Variables para SecondOrderDynamics1D

    public float effectiveRPM, DRPM;
    public float minRPM, maxRPM;

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        f = 1;
        z = 1;
        r = 1;
        x0 = 0;
        lastVel = 0;
        minRPM = 1800;
        maxRPM = 8000;
        //dynamicsRPM = GetComponent<SecondOrderDynamics1D>();
        //dynamicsRPM.SecondOrderDynamicsConstants(f, z, r, x0);

    }


    void Update()
    {

        vel = rb.velocity.magnitude;
        effectiveVel = Mathf.Lerp(minRPM,maxRPM, vel > maxRPM ? 1 : 100 * vel / maxRPM);


        Dvel = (lastVel - effectiveVel) / Time.deltaTime;
        lastVel = effectiveVel;



        //carAudio.pitch = vel / pitchfactor;

        (effectiveRPM, DRPM) = SecondOrderDynamics1D.EulerMethodStep(effectiveRPM, DRPM, f, z, r, x0, Time.deltaTime, effectiveVel, Dvel);


        var emitter = GetComponent<FMODUnity.StudioEventEmitter>();
        emitter.SetParameter("RPM", effectiveRPM);






        //Código antiguo no se que hace así que no lo he tocado
        float input = Input.GetAxis("Sideways");
        float a;
        if (input > 0)
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
