using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/**
 * Class that describes behaviour of Menu Scene
 */
public class MenuBehaviourScript : MonoBehaviour
{
    // Button to start play game
    public GameObject PlayButton;
    // Button to open Help Scene
    public GameObject HelpButton;

    // Start is called before the first frame update
    void Start()
    {
        PlayButton.GetComponent<Button>().onClick.AddListener(PlayGame);
        HelpButton.GetComponent<Button>().onClick.AddListener(OpenHelpScene);
    }

    // Method is executed after clicking on the PlayButton
    void PlayGame()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    // Method is executed after clicking on the HelpButton
    void OpenHelpScene()
    {
        SceneManager.LoadScene("HelpScene", LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update() { }
}
