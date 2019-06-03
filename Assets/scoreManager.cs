using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour
{
    public static int score;
    public Text txt;

    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<Text>();
        txt.text = "" + score;
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = "" + score;
    }


    public static void incrementScore()
    {
        ++score;
    }
}
