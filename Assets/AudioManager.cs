using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/**
 * Class to controle music and sounds on/off
 */
public class AudioManager : MonoBehaviour
{
    // Object of this class
    public static AudioManager Obj;

    private GameObject SoundsContoler; // Object that are response for sounds on/off 
    private GameObject MusicContoler; // Object that are response for music on/off 
    private bool _musicStop; // variable that indicates whether the music is off (off == true)
    private AudioSource _musicSource; // source to play audio
    private static bool _setControlersValue = true; // variable to set value of controler

    // Awake is called before the first frame update
    void Awake()
    {
        if (Obj != null && Obj != this)
        {
            Destroy(this.gameObject);
            _setControlersValue = true;
            return;
        }
        Obj = this;
        InitController();
        _musicSource = GetComponent<AudioSource>();
        AudioHelper.InitElements();
        StartMusic();
        DontDestroyOnLoad(this.gameObject);
    }

    // Initialize components to control music on/off
    private void InitController()
    {
        if (MusicContoler == null)
            MusicContoler = GameObject.Find("AudioToggle");
        if (SoundsContoler == null)
            SoundsContoler = GameObject.Find("SoundsToggle");
    }

    // Update is called once per frame
    void Update()
    {
        if (!SceneManager.GetActiveScene().name.Equals("MenuScene"))
            return;
        InitController();
        if (_setControlersValue)
        {
            MusicContoler.GetComponent<Toggle>().isOn = !AudioHelper.MusicOn;
            SoundsContoler.GetComponent<Toggle>().isOn = !AudioHelper.SoundsOn;
            _setControlersValue = false;
        }

        if (!_musicStop == MusicContoler.GetComponent<Toggle>().isOn == true)
            StopMusic();

        if (_musicStop == !MusicContoler.GetComponent<Toggle>().isOn == true)
            StartMusic();

        AudioHelper.SoundsOn = !SoundsContoler.GetComponent<Toggle>().isOn;
        AudioHelper.MusicOn = !MusicContoler.GetComponent<Toggle>().isOn;
    }

    // Start playing music 
    public void StartMusic()
    {
        _musicStop = false;
        _musicSource.Play();
    }

    // Stop music
    public void StopMusic()
    {
        _musicStop = true;
        _musicSource.Stop();
    }
}
