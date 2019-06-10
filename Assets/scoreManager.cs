using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour
{
    public static scoreManager Obj;
    private int _score;
    private Text _txt;

    // Start is called before the first frame update
    void Start()
    {
        if (Obj == null)
            Obj = this;

        _txt = GetComponent<Text>();

        if (PlayerPrefs.HasKey("save_score"))
            _score = PlayerPrefs.GetInt("save_score");
        else
            _score = 0;
   
    }

    // Update is called once per frame
    void Update()
    {
        if (!Manager.Obj.GameOver)
            _txt.text = "" + _score;
        else
            enabled = false;
    }

    public int GetScore()
    {
        return _score;
    }

    public void IncrementScore(int val)
    {
        if(!Manager.Obj.GameOver)
            _score += val;
    }

    public void StopScore()
    {
        PlayerPrefs.SetInt("score", _score);

        if (PlayerPrefs.HasKey("highScore"))
        {
            if (_score > PlayerPrefs.GetInt("highScore"))
                PlayerPrefs.SetInt("highScore", _score);
        }
        else
            PlayerPrefs.SetInt("highScore", _score);

        _txt.text = "";
    }
}
