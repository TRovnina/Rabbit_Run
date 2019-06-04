using UnityEngine;
using System.Collections;

public class playerFalls : MonoBehaviour
{

    private Rigidbody _rb;

    void Start()
    {

        _rb = GetComponent<Rigidbody>();

    }

    void Update()
    {

        RaycastHit hit;
        //print(Physics.Raycast(transform.position, Vector3.down, out hit, 5f));
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 5f) && hit.transform.gameObject.tag == "Ground")
        {
            _rb.useGravity = false;
           // rb.tag = "Untagged";
        }
        else
        {
            _rb.useGravity = true;
            _rb.velocity = new Vector3(0f, -10f, 0f);
            //rb.tag = "Falling";
            Manager.Obj.GameOver = true;
        }

    }

}