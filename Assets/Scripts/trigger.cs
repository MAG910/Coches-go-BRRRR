using FMOD;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    public float TimeOnNitro;
    float timerd;

    public float VelOnNitro;
    public float MaxVelOnNitro;

    public float OrigVelOnNitro;
    public float OrigMaxVelOnNitro;

    public DriftController car;

    public GameObject NitroEffect;

    public bool OnNitro;

    public Material materal;
    
    public Color colorbase;
    public Color colorturbo;




    private void Start()
    {
     
        materal.SetColor("_EmissionColor", colorbase);

        timerd = TimeOnNitro;

        OrigMaxVelOnNitro = car.Accel;
        OrigMaxVelOnNitro = car.TopSpeed;


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Turbo"))
        {
            OnNitro = true;
            Destroy(other.gameObject);            
        }
        if (other.gameObject.tag == "CanDie")
        {
            other.GetComponent<die>().isDed = true;
        }
    }

    private void Update()
    {
       
        
        if (OnNitro)
        {
            timerd -= Time.deltaTime;
            car.Nitro = true;
            car.TopSpeed = MaxVelOnNitro;
            NitroEffect.SetActive(true);

            materal.SetColor("_EmissionColor", colorturbo);

        }
        if (timerd <= 0)
        {
            OnNitro = false;
            timerd = TimeOnNitro;
            car.Nitro = false;
            car.TopSpeed = OrigMaxVelOnNitro;
            NitroEffect.SetActive(false);

           
            materal.SetColor("_EmissionColor",  colorbase);

        }
    }
}
