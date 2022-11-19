using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicIntensity : MonoBehaviour
{

    public float vel;
    public float intensity;
    bool death;
    public float effectiveDeath;

    public die deathIndicator;
    public GameObject car;
    public Rigidbody rb; 
    
    // Start is called before the first frame update
    void Start()
    {
        rb = car.GetComponent<Rigidbody>();

        intensity = 1;
        vel = 30;
        death = false;
    }

    // Update is called once per frame
    void Update()
    {
        vel = rb.velocity.magnitude;
        death = deathIndicator.ded;
        effectiveDeath = death ? 1 : 0;

        var emitter = GetComponent<FMODUnity.StudioEventEmitter>();
        emitter.SetParameter("vel", vel);
        emitter.SetParameter("Intensity", intensity);
        emitter.SetParameter("death", effectiveDeath);

    }
}
