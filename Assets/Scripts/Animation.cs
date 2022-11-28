using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;

public class Animation : MonoBehaviour
{
    public int countdown=3;
    public GameObject cam;
    public bool started = false;
    public Rigidbody rb;
    public GameObject contador;
    public GameObject mapa;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = cam.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.rotation==cam.transform.rotation && !started) {
            started= true;
            contador.gameObject.SetActive(true);
            cam.SetActive(true);
           
            StartCoroutine(display());
            
        }
        float x = Mathf.LerpAngle(transform.rotation.x, cam.transform.rotation.x, Time.deltaTime);
        float y = Mathf.LerpAngle(transform.rotation.y, cam.transform.rotation.y, Time.deltaTime);
        float z = Mathf.LerpAngle(transform.rotation.z, cam.transform.rotation.z, Time.deltaTime);
        float w = Mathf.LerpAngle(transform.rotation.w, cam.transform.rotation.w, Time.deltaTime);
        transform.rotation = new Quaternion(x,y,z,w);    
    }
    IEnumerator display()
    {


        while (countdown >=0)
        {
            contador.GetComponent<TextMeshProUGUI>().text = countdown.ToString();
            
            if (countdown == 0)
            {
                contador.GetComponent<TextMeshProUGUI>().text = "0";

             
            }
            countdown--;
            yield return new WaitForSecondsRealtime(1f);
            
        }
        if (countdown == -1)
        {
            
            rb.constraints = RigidbodyConstraints.None;
            rb.constraints = RigidbodyConstraints.FreezeRotationY;
            rb.gameObject.GetComponent<DriftController>().enabled = true;
            contador.gameObject.SetActive(false);
            mapa.gameObject.SetActive(true);
            Destroy(this.gameObject);

        }
    }
}
