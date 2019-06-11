using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/**
 * Controls panels and buttons
 */
public class UIManager : MonoBehaviour
{
    // class object to avoid static methods
    public static UIManager Obj;
    // panels and buttons
    public GameObject GameOverPanel;
    public GameObject Score;
    public GameObject HighScore;
    public GameObject Restart;  
    public GameObject Menu;
    public GameObject SaveMePanel;
    public GameObject Yep;
    public GameObject No;

    // Start is called before the first frame update
    void Start()
    {
        //initialize variables

        if (Obj == null)
            Obj = this;

        //hide panels
        GameOverPanel.SetActive(false);
        SaveMePanel.SetActive(false);

        //add Listeners on buttons
        Restart.GetComponent<Button>().onClick.AddListener(RestartGame);
        Menu.GetComponent<Button>().onClick.AddListener(OpenMenuScene);
        Yep.GetComponent<Button>().onClick.AddListener(SaveGame);
        No.GetComponent<Button>().onClick.AddListener(EndGame);
    }

    // begin new game
    void RestartGame()
    {
        GameOverPanel.SetActive(false);
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    // continue play game
    void SaveGame()
    {
        Manager.Obj.Resurrection();
    }

    // end current game
    void EndGame()
    {
        SaveMePanel.SetActive(false);
        Manager.Obj.Finish();
    }

    // open main menu
    void OpenMenuScene()
    {
        SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update()
    {
    }

    // show panel when game is over
    public void SetGameOverPanel()
    {
        Score.GetComponent<Text>().text = "Score: " + PlayerPrefs.GetInt("score");
        HighScore.GetComponent<Text>().text = "High score: " + PlayerPrefs.GetInt("highScore");
        SaveMePanel.SetActive(false);
        GameOverPanel.SetActive(true);
    }

    // show panel for saving current game
    public void ResurrectPanel()
    {
        SaveMePanel.SetActive(true);
    }
}
