using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteMusic : MonoBehaviour
{
    public AudioSource music;
    public Text text;

    private void Awake()
    {
        music = GameObject.Find("MusicPlayer").GetComponent<AudioSource>();
        text = GameObject.Find("MusicMuteText").GetComponent<Text>();
    }

    public void checkForMusic()
    {
        if (!music.mute)
        {
            music.mute = true;
            text.text = "Unmute Music";
        } else if (music.mute)
        {
            music.mute = false;
            text.text = "Mute Music";
        }
    }
}
