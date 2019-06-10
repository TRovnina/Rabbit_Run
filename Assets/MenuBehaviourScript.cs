using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuBehaviourScript : MonoBehaviour
{
    public GameObject PlayButton;
    public GameObject HelpButton;

    // Start is called before the first frame update
    void Start()
    {
        PlayButton.GetComponent<Button>().onClick.AddListener(PlayGame);
        HelpButton.GetComponent<Button>().onClick.AddListener(OpenHelpScene);
    }

    void PlayGame()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    void OpenHelpScene()
    {
        SceneManager.LoadScene("HelpScene", LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update() { }
}
