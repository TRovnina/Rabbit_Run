﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Controls game
 */
public class Manager : MonoBehaviour
{
    // class object to avoid static methods
    public static Manager Obj;
    private bool _gameOver;

    //background
    public GameObject Background;
    private readonly String[] _materials = { "Snow", "Grass", "Desert", "Sea" };
    private int _materialCounter = -1;
    private int _scoreCounter;


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
        //exit
        if(Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

        //change background and run faster
        if (ScoreManager.Obj.GetScore() > _scoreCounter)
        {
            Background.GetComponent<Renderer>().material.mainTexture =
                Resources.Load(_materials[(++_materialCounter) % _materials.Length]) as Texture;
            _scoreCounter += 50;

            if(ScoreManager.Obj.GetScore() != 0)
                PlayerBehavior.Obj.RunFaster();
        }

        //cheat code to add lives
        if (Input.GetKeyDown(KeyCode.RightAlt) && Input.GetKeyDown(KeyCode.L))
            LifeManager.Obj.UpdateLives(1);
 
    }

    // modificator for GameOver
    public bool GameOver { get; set; }

    // finish current game
    public void Finish()
    {
        PlayerPrefs.SetInt("save_score", 0);
        PlayerPrefs.SetInt("save_lives", 1);
        ScoreManager.Obj.StopScore();
        UIManager.Obj.SetGameOverPanel();
    }

    // save current game and resurrect Player
    public void Resurrection()
    {
        PlayerBehavior.Obj.RunSlower();
        PlayerPrefs.SetInt("save_score", ScoreManager.Obj.GetScore());
        PlayerPrefs.SetInt("save_lives", LifeManager.Obj.GetLives());
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
}
