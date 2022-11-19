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
