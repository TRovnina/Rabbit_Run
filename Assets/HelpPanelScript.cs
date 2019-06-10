using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HelpPanelScript : MonoBehaviour
{
    public GameObject Menu;

    // Start is called before the first frame update
    void Start()
    {
        Menu.GetComponent<Button>().onClick.AddListener(OpenMenuScene);
    }


    void OpenMenuScene()
    {
        SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update() { }
}
