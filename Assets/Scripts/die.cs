<<<<<<< HEAD
<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class die : MonoBehaviour
{
    public GameObject GameOverMenu;
    

    public Rigidbody Car;

    public bool ded;


    private void Start()
    {
        ded = false;
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
}
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class die : MonoBehaviour
{
    public GameObject GameOverMenu;
    

    public Rigidbody Car;

    public bool ded;


    private void Start()
    {
        ded = false;
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
}
>>>>>>> 9f9832784973f81ea3f3f21bffa89fb39639313e
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class die : MonoBehaviour
{
    public GameObject GameOverMenu;
    

    public Rigidbody Car;

    public bool ded;


    private void Start()
    {
        ded = false;
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
}
>>>>>>> 9f9832784973f81ea3f3f21bffa89fb39639313e
