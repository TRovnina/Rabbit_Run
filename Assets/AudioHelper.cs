/**
 * Class to help music/sounds work correct
 */
public static class AudioHelper
{
    // variable that indicates whether the sound is on
    public static bool SoundsOn { set; get; }

    // variable that indicates whether the music is on
    public static bool MusicOn { set; get; }

    // Initialize elements at first time only
    public static void InitElements()
    {
        SoundsOn = true;
        MusicOn = true;
    }
}
