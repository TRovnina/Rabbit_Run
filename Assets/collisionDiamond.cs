//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class collisionDiamond : MonoBehaviour
//{

//    private Rigidbody rb;

//    void Start()
//    {

//        rb = GetComponent<Rigidbody>();

//    }

//    void Update()
//    {

//        RaycastHit hit;

//        if (Physics.Raycast(transform.position, Vector3.forward, out hit, 1f) && hit.transform.gameObject.tag == "Diamond")
//        {
//            if (other.gameObject.tag == "Diamond")
//            {
//                GameObject part = Instantiate(particle, other.gameObject.transform.position, Quaternion.identity);
//                Destroy(other.gameObject);
//                Destroy(part, 1f);
//                ScoreManager.instance.startScore();

//            }
//            //hit.transform.gameObject.transform.position = new Vector3(0f, -4f, 0f);
//            rb.velocity = new Vector3(0f, 10f, 0f);
//        }

//    }
//}
