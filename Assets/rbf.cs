using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rbf : MonoBehaviour
{
    Rigidbody rb;
    public float angle;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        rb.AddForce(0, 0, 400, ForceMode.Acceleration);

        RaycastHit hit;

        if (Physics.Raycast(transform.position, -transform.up, out hit, 10))
        {
            Quaternion q = new Quaternion(transform.rotation.x, transform.rotation.y, hit.transform.rotation.z, transform.rotation.w);

            transform.rotation = Vector3.Lerp(transform.rotation, q , 5 * Time.deltaTime) ;
        }
    }
}
