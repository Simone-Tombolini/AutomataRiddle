using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicVolumeChanger : MonoBehaviour
{
    public Slider volumeSlider;
    public float volume = 0f;
    public GameObject musicManager;

    private void Start()
    {
        volume = SaveSystem.readSettings().musicvolume;
    }
    void Update()
    {
        if(volumeSlider.value != volume )
        {
            musicManager.GetComponent<MusicManager>().Musics[musicManager.GetComponent<MusicManager>().song].volume = volume;
        }
        if(volumeSlider.value == 0)
        {
            musicManager.GetComponent<MusicManager>().Musics[musicManager.GetComponent<MusicManager>().song].volume = 0f;
        }
        volume = volumeSlider.value;
    }
}
