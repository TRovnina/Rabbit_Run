using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/**
 * Class that describes behaviour of Help Scene
 */
public class HelpPanelScript : MonoBehaviour
{
    // Button to return to Menu Scene
    public GameObject Menu;

    // Start is called before the first frame update
    void Start()
    {
        Menu.GetComponent<Button>().onClick.AddListener(OpenMenuScene);
    }

    // Method to open menu scene
    void OpenMenuScene()
    {
        SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update() { }
}
