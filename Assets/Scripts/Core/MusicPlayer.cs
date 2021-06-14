using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip musicSFX;

    private void Awake()
    {
        if(FindObjectsOfType<MusicPlayer>().Length > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.mute = PlayerPrefs.GetInt(AudioManager.MUTE_MUSIC) == 1;
        PlayBackgroundMusic();
    }

    void Update()
    {
        transform.position = UnityEngine.Camera.main.transform.position;
    }

    private void PlayBackgroundMusic()
    {
        audioSource.loop = true;
        audioSource.clip = musicSFX;
        audioSource.Play();
    }

    public bool Mute()
    {
        audioSource.mute = !audioSource.mute;
        return audioSource.mute;
    }
}
