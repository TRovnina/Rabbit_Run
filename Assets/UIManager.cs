using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Obj;
    public GameObject GameOverPanel;

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
        GameOverPanel.SetActive(true);
    }
}
