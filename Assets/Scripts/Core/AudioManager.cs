using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{

    public const string MUTE_MUSIC = "music";
    public const string MUTE_SOUND = "sound";

    MusicPlayer musicPlayer;


    [SerializeField] Button musicButton;
    [SerializeField] Button soundButton;

    [SerializeField] Sprite muteMusicSprite;
    [SerializeField] Sprite unmuteMusicSprite;
    [SerializeField] Sprite muteSoundSprite;
    [SerializeField] Sprite unmuteSoundSprite;

    private void Start()
    {
        musicButton.image.sprite = PlayerPrefs.GetInt(MUTE_MUSIC) == 1 ? muteMusicSprite : unmuteMusicSprite;
        soundButton.image.sprite = PlayerPrefs.GetInt(MUTE_SOUND) == 1 ? muteSoundSprite : unmuteSoundSprite;
    }

    public void MuteMusic()
    {
        musicPlayer = FindObjectOfType<MusicPlayer>();
        bool isMuted = musicPlayer.Mute();

        SetPrefs(MUTE_MUSIC, isMuted);

        musicButton.image.sprite = isMuted ? muteMusicSprite : unmuteMusicSprite;
    }    

    public void MuteSound()
    {
        bool isMuted = PlayerPrefs.GetInt(MUTE_SOUND) == 1;
        isMuted = !isMuted;

        SetPrefs(MUTE_SOUND, isMuted);

        soundButton.image.sprite = isMuted ? muteSoundSprite : unmuteSoundSprite;
    }

    private static void SetPrefs(string prefKey, bool isMuted)
    {
        PlayerPrefs.SetInt(prefKey, isMuted ? 1 : 0);
        PlayerPrefs.Save();
    }
}
