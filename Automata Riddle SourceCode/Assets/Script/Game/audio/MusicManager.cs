using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource[] Musics;
    public int song;
    private void Start()
    {
    startSong();
    }
    public void stopSong()
    {
        song = SaveSystem.readMusic();
        Musics[song].volume = SaveSystem.readSettings().musicvolume;
        Musics[song].Stop();
    }
    public void stopSong(int songplay)
    {

        Musics[songplay].volume = SaveSystem.readSettings().musicvolume;
        Musics[songplay].Stop();
    }
    public void startSong()
    {
        song = SaveSystem.readMusic();
        Musics[song].volume = SaveSystem.readSettings().musicvolume;
        Musics[song].Play();
    }
    public void startSong(int songplay)
    {
        
        Musics[songplay].volume = SaveSystem.readSettings().musicvolume;
        Musics[songplay].Play();
    }
}
