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
        if (!Manager.Obj.GameOver)
            transform.position = player.transform.position + offset;
    }

}