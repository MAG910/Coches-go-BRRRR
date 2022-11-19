using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAudio : MonoBehaviour
{
    //public AudioSource carAudio; Ahora lo hace FMOD
    //public float pitchfactor; Ahora lo hace FMOD
    Rigidbody rb;
    DriftController dc;
    public die deathIndicator;
    //SecondOrderDynamics1D dynamicsRPM;

    public Animator anim; // No lo toco no se lo que es

    public float vel, effectiveVel;
    public bool isDrift;
    float effectiveDrift;

    float gear;

    bool death;
    public float effectiveDeath;

    float animd;
    float b;

    float Dvel, lastVel;
    float f, z, r, x0; //Variables para SecondOrderDynamics1D

    public float effectiveRPM, DRPM;
    public float minRPM, maxRPM;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        dc = GetComponent<DriftController>();
        f = 1;
        z = 1;
        r = 1;
        x0 = 0;
        lastVel = 0;
        minRPM = 1800;
        maxRPM = 8000;
        gear = 1;
        //dynamicsRPM = GetComponent<SecondOrderDynamics1D>();
        //dynamicsRPM.SecondOrderDynamicsConstants(f, z, r, x0);

    }


    void Update()
    {

        isDrift = dc.inSlip;
        effectiveDrift = isDrift ? 1 : 0;


        vel = rb.velocity.magnitude;
        effectiveVel = Mathf.Lerp(minRPM,maxRPM, vel > maxRPM ? 1 : 100 * vel / maxRPM);


        Dvel = (lastVel - effectiveVel) / Time.deltaTime;
        lastVel = effectiveVel;



        //carAudio.pitch = vel / pitchfactor;

        (effectiveRPM, DRPM) = SecondOrderDynamics1D.EulerMethodStep(effectiveRPM, DRPM, f, z, r, x0, Time.deltaTime, effectiveVel, Dvel);
        death = deathIndicator.ded;
        effectiveDeath = death ? 1 : 0;

        if (vel > 0 && vel <= 30) {
            if (gear == 2)
            {
                effectiveRPM = effectiveRPM + 500;
                gear = 1;
            }
        }
        if (vel > 30 && vel <= 50) {
            if (gear == 1)
            {
                effectiveRPM = effectiveRPM - 500;
                gear = 2;
            }
            if (gear == 3)
            {
                effectiveRPM = effectiveRPM + 500;
                gear = 2;
            }
        }
        if (vel > 50 && vel <= 80) {
            if (gear == 2)
            {
                effectiveRPM = effectiveRPM - 500;
                gear = 3;
            }
            if (gear == 4)
            {
                effectiveRPM = effectiveRPM + 500;
                gear = 3;
            }
        }
        if (vel > 80 && vel <= 110) {
            if (gear == 3)
            {
                effectiveRPM = effectiveRPM - 500;
                gear = 4;
            }
            if (gear == 5)
            {
                effectiveRPM = effectiveRPM + 500;
                gear = 4;
            }
        }
        if (vel > 110)
        {
            if (gear == 4)
            {
                effectiveRPM = effectiveRPM - 500;
                gear = 5;
            }
            if (gear == 6)
            {
                effectiveRPM = effectiveRPM + 500;
                gear = 5;
            }

        }

     



        var emitter = GetComponent<FMODUnity.StudioEventEmitter>();
        emitter.SetParameter("RPM", effectiveRPM);
        emitter.SetParameter("DriftRate", effectiveDrift);
        emitter.SetParameter("death", effectiveDeath);





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
