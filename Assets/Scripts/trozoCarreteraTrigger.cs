<<<<<<< HEAD
<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trozoCarreteraTrigger : MonoBehaviour
{
    public Transform ToInstantiateT;
    SeleccionarTrozo M;

    private void Start()
    {
        M = GameObject.Find("Seleccionar").GetComponent<SeleccionarTrozo>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            M.SelectRandomPiece(ToInstantiateT);

            //M.PreviousSelectedTrack = this.transform.parent.gameObject;
        }
    }
}
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trozoCarreteraTrigger : MonoBehaviour
{
    public Transform ToInstantiateT;
    SeleccionarTrozo M;

    private void Start()
    {
        M = GameObject.Find("Seleccionar").GetComponent<SeleccionarTrozo>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            M.SelectRandomPiece(ToInstantiateT);

            //M.PreviousSelectedTrack = this.transform.parent.gameObject;
        }
    }
}
>>>>>>> 9f9832784973f81ea3f3f21bffa89fb39639313e
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trozoCarreteraTrigger : MonoBehaviour
{
    public Transform ToInstantiateT;
    SeleccionarTrozo M;

    private void Start()
    {
        M = GameObject.Find("Seleccionar").GetComponent<SeleccionarTrozo>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            M.SelectRandomPiece(ToInstantiateT);

            //M.PreviousSelectedTrack = this.transform.parent.gameObject;
        }
    }
}
>>>>>>> 9f9832784973f81ea3f3f21bffa89fb39639313e
