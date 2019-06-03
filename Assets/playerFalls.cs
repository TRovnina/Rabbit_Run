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
            rb.tag = "Untagged";
        }
        else
        {
            rb.useGravity = true;
            rb.velocity = new Vector3(0f, -10f, 0f);
            rb.tag = "Falling";
        }

    }

}