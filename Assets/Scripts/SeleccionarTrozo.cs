using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeleccionarTrozo : MonoBehaviour
{
    public GameObject[] Trozos;
    GameObject TrozoSeleccionado;

    public GameObject PreviousSelectedTrack;

    int randi;

    float maxNum;

    private void Start()
    {
        maxNum = Trozos.Length;
    }
    public void SelectRandomPiece(Transform t)
    {
        randi = (int) Random.Range(0, maxNum);

        TrozoSeleccionado = Trozos[randi];

        Instantiate(TrozoSeleccionado, t.position, t.rotation);
        Destroy(PreviousSelectedTrack);
    }
}
