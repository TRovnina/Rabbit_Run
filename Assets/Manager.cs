using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class Manager : MonoBehaviour
{
    public static Manager Obj;
    private bool _gameOver;

    // Start is called before the first frame update
    void Start()
    {
        if (Obj == null)
            Obj = this;

        GameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public bool GameOver { get; set; }

    public void Finish()
    {
        scoreManager.Obj.StopScore();
        UIManager.Obj.SetGameOverPanel();
    }
}
