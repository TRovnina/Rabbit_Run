using UnityEngine;
using System.Collections;

public class playerFalls : MonoBehaviour
{

    private Rigidbody rb;

    void Start()
    {

        rb = GetComponent<Rigidbody>();

    }

    void Update()
    {

        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 5f) && hit.transform.gameObject.tag == "Ground")
        {
            rb.useGravity = false;
        }
        else
        {
            rb.useGravity = true;
        }

    }

}