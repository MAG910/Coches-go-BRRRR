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

    private void Start()
    {
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
    }

    private void Update()
    {
        if (OnNitro)
        {
            timerd -= Time.deltaTime;
            car.Nitro = true;
            car.TopSpeed = MaxVelOnNitro;
            NitroEffect.SetActive(true);
            
        }
        if(timerd <= 0)
        {
            OnNitro = false;
            timerd = TimeOnNitro;
            car.Nitro = false;
            car.TopSpeed = OrigMaxVelOnNitro;
            NitroEffect.SetActive(false);

        }
    }
}
