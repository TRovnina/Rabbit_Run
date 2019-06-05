using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Obj;
    public GameObject GameOverPanel;
    public GameObject Score;
    public GameObject HighScore;

    // Start is called before the first frame update
    void Start()
    {
        if (Obj == null)
            Obj = this;

        GameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetGameOverPanel()
    {
        Score.GetComponent<Text>().text = "Score: " + PlayerPrefs.GetInt("score");
        HighScore.GetComponent<Text>().text = "High score: " + PlayerPrefs.GetInt("highScore");
        GameOverPanel.SetActive(true);
    }
}
