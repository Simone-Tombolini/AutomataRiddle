using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ReproduceSoundEffect : MonoBehaviour
{

    public AudioSource sound;
   
    public void ReproduceSound()
    {
        sound.volume = SaveSystem.readSettings().EffectVolume;
        sound.Play();
    }
}
