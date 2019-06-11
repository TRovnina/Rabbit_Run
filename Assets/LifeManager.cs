using UnityEngine;
using UnityEngine.UI;

/**
 * Controls Player`s lives
 */
public class LifeManager : MonoBehaviour
{
    // class object to avoid static methods
    public static LifeManager Obj;
    private int _lives;
    private Text _txt;

    // Start is called before the first frame update
    void Start()
    {
        // init variables
        if (Obj == null)
            Obj = this;

        _txt = GetComponent<Text>();

        // get information from database
        if (PlayerPrefs.HasKey("save_lives"))
            _lives = PlayerPrefs.GetInt("save_lives");
        else
            _lives = 1;

        _txt.text = "x " + _lives;
    }

    // Update is called once per frame
    void Update()
    {
    }

    //return lives
    public int GetLives()
    {
        return _lives;
    }

    // update and set lives
    public void UpdateLives(int val)
    {
            _lives += val;
            _txt.text = "x " + _lives;
    }
}
