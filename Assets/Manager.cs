using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

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
        PlayerPrefs.SetInt("save_score", 0);
        PlayerPrefs.SetInt("save_lives", 1);
        ScoreManager.Obj.StopScore();
        UIManager.Obj.SetGameOverPanel();
    }

    public void Resurection()
    {
        PlayerPrefs.SetInt("save_score", ScoreManager.Obj.GetScore());
        PlayerPrefs.SetInt("save_lives", LifeManager.Obj.GetLives());
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
}
