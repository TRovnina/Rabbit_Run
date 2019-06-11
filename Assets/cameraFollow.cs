using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    // player
    public GameObject Player;
    // camera position
    public Vector3 Offset;

    void Start()
    {
        //initialize
        Offset = transform.position - Player.transform.position;
    }

    void Update()
    {
        // update camera position
        if (!Manager.Obj.GameOver)
            transform.position = Player.transform.position + Offset;
    }

}