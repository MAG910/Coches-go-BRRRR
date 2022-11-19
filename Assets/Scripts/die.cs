using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class die : MonoBehaviour
{
    public GameObject GameOverMenu;
    

    public Rigidbody Car;

    public bool ded;

    public bool isDed;


    private void Start()
    {
        ded = false;
        isDed = false;
    }

    private void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.CompareTag("Player"))
        {
            Car.isKinematic = true;

            GameOverMenu.SetActive(true);

            ded = true;
        }
       


    }

    private void Update()
    {
        if (isDed)
        {
            Car.isKinematic = true;

            GameOverMenu.SetActive(true);

            ded = true;
        }
    }
}
