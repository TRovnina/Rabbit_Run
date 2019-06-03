using UnityEngine;
using System.Collections;

public class cameraFollow : MonoBehaviour
{

    public GameObject player;
    public Vector3 offset;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void Update()
    {
        if(player.tag != "Falling")
            transform.position = player.transform.position + offset;
    }

}