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

    public die die;


    private void Start()
    {
        timerd = TimeOnNitro;

        OrigMaxVelOnNitro = car.Accel;
        OrigMaxVelOnNitro = car.TopSpeed;

        materal.SetColor("_EmissionColor", Color.white);

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
            die.isDed = true;
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
           // materal.color = new Color(88, 255, 174);
            materal.SetColor("_EmissionColor", new Color(88, 255, 174));
        }
        if (timerd <= 0)
        {
            OnNitro = false;
            timerd = TimeOnNitro;
            car.Nitro = false;
            car.TopSpeed = OrigMaxVelOnNitro;
            NitroEffect.SetActive(false);
            //materal.color = Color.white;
            materal.SetColor("_EmissionColor",Color.white );

        }
    }
}
