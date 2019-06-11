using UnityEngine;
using UnityEngine.UI;

/**
 * Controls score
 */
public class scoreManager : MonoBehaviour
{
    // class object to avoid static methods
    public static scoreManager Obj;
    // variable for counting points
    private int _score;
    // variable for showing score
    private Text _txt;

    // Start is called before the first frame update
    void Start()
    {
        // initialize variables
        if (Obj == null)
            Obj = this;

        _txt = GetComponent<Text>();

       // get score from database
        if (PlayerPrefs.HasKey("save_score"))
            _score = PlayerPrefs.GetInt("save_score");
        else
            _score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //update score
        if (!Manager.Obj.GameOver)
            _txt.text = "" + _score;
        else
            enabled = false;
    }

    // return score
    public int GetScore()
    {
        return _score;
    }

    // increment score
    public void IncrementScore(int val)
    {
        if(!Manager.Obj.GameOver)
            _score += val;
    }

    // save current score and high score in database
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
