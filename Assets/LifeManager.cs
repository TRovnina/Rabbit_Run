using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    public static LifeManager Obj;
    private int _lives;
    private Text _txt;

    // Start is called before the first frame update
    void Start()
    {
        if (Obj == null)
            Obj = this;

        _txt = GetComponent<Text>();
        _txt.text = "x 1";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int GetLives()
    {
        return _lives;
    }

    public void UpdateLives(int val)
    {
            _lives += val;
            _txt.text = "x " + _lives;
    }
}
