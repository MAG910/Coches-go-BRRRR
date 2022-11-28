using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ObstaculosGen : MonoBehaviour
{
     List<GameObject> gen= new List<GameObject>();
    public GameObject muerte;
    bool[] gactivados;


    int generadores=0,generados=0,objeto=0,spawneado=0;
    
    public List<GameObject> Obstaculos = new List<GameObject>();

    public bool mapa;
    // Start is called before the first frame update
    void Awake()
    {
        Instantiate(muerte,new Vector3(0,-30,0),muerte.transform.rotation);
        foreach (Transform child in transform)
        {

            gen.Add(child.gameObject);

            generadores++;
        }
        gactivados = new bool[generadores];
        for (int i = 0; i < generadores; i++)
        {
            gactivados[i] = false;
        }
        for (int i = 0; i < generadores; i++)
        {
            objeto = Random.Range(1, Obstaculos.Count);
            spawneado = Random.Range(0, generadores);
            while (gactivados[spawneado]) { spawneado = Random.Range(0, generadores); }
            if (mapa)
            {
                switch (generados)
                {
                    case 0:

                        Instantiate(Obstaculos[objeto], gen[spawneado].transform.position + Obstaculos[objeto].transform.position, Obstaculos[objeto].transform.rotation);
                        gactivados[spawneado] = true;
                        generados++;
                        break;
                    case 1:
                        if (Random.Range(0, 10) < 7)
                        {
                            Instantiate(Obstaculos[objeto], gen[spawneado].transform.position + Obstaculos[objeto].transform.position, Obstaculos[objeto].transform.rotation);
                            gactivados[spawneado] = true;
                            generados++;
                        }
                        break;
                    case 2:
                        if (Random.Range(0, 10) < 5)
                        {
                            Instantiate(Obstaculos[objeto], gen[spawneado].transform.position + Obstaculos[objeto].transform.position, Obstaculos[objeto].transform.rotation);
                            gactivados[spawneado] = true;
                            generados++;
                        }
                        break;
                    default:
                        break;

                }

            }
            else
            {
                Instantiate(Obstaculos[objeto], gen[spawneado].transform.position + Obstaculos[objeto].transform.position, Obstaculos[objeto].transform.rotation);
                gactivados[spawneado] = true;
                generados++;
            }
        }
    }
    public void crear()

    {
        generados = 0;
        for (int i = 0; i < generadores; i++)
        {
            gactivados[i] = false;
        }
        for (int i = 0; i < generadores; i++)
        {
            objeto = Random.Range(0, Obstaculos.Count);
            spawneado = Random.Range(0, generadores);
            while (gactivados[spawneado]) { spawneado = Random.Range(0, generadores); }
            if (mapa)
            {
                switch (generados)
                {
                    case 0:

                        Instantiate(Obstaculos[objeto], gen[spawneado].transform.position + Obstaculos[objeto].transform.position, Obstaculos[objeto].transform.rotation);
                        gactivados[spawneado] = true;
                        generados++;
                        break;
                    case 1:
                        if (Random.Range(0, 10) < 7)
                        {
                            Instantiate(Obstaculos[objeto], gen[spawneado].transform.position + Obstaculos[objeto].transform.position, Obstaculos[objeto].transform.rotation);
                            gactivados[spawneado] = true;
                            generados++;
                        }
                        break;
                    case 2:
                        if (Random.Range(0, 10) < 5)
                        {
                            Instantiate(Obstaculos[objeto], gen[spawneado].transform.position + Obstaculos[objeto].transform.position, Obstaculos[objeto].transform.rotation);
                            gactivados[spawneado] = true;
                            generados++;
                        }
                        break;
                    default:
                        break;

                }

            }
            else
            {
                Instantiate(Obstaculos[objeto], gen[spawneado].transform.position + Obstaculos[objeto].transform.position, Obstaculos[objeto].transform.rotation);
                gactivados[spawneado] = true;
                generados++;
            }
        }
    }

}
