using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Obj;
    public GameObject GameOverPanel;
    public GameObject Score;
    public GameObject HighScore;
    public GameObject Restart;
    public GameObject Menu;

    // Start is called before the first frame update
    void Start()
    {
        if (Obj == null)
            Obj = this;

        GameOverPanel.SetActive(false);
        Restart.GetComponent<Button>().onClick.AddListener(RestartGame);
        Menu.GetComponent<Button>().onClick.AddListener(OpenMenuScene);
    }

    void RestartGame()
    {
        GameOverPanel.SetActive(false);
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    void OpenMenuScene()
    {
        SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
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
