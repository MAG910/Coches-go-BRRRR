using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shadow : MonoBehaviour
{
    Vector3 OrigScale;
    bool f;

    private void Start()
    {
        OrigScale = transform.localScale;
    }

    void Update()
    {
        RaycastHit hit;

        Vector3 v3;

        if(Physics.Raycast(transform.position, -transform.up, out hit, 1))
        {
            v3 = OrigScale;

        }
        else
        {
            v3 = Vector3.zero;

        }

        Vector3.Lerp(transform.localScale, v3, 5 * Time.deltaTime);
    }
}
