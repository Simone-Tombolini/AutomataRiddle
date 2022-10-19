using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Settings 
{
    public float musicvolume;
    public float EffectVolume;
    public int trackmusic;
    public Settings(float vol1, float vol2)
    {
        musicvolume = vol1;
        EffectVolume = vol2;
    }
    public Settings(float vol1, float vol2, int trak)
    {
        musicvolume = vol1;
        EffectVolume = vol2;
        trackmusic = trak;
    }
}
