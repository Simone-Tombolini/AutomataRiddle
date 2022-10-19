using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class MusicAudio : MonoBehaviour
{

    public AudioSource prova;
    public Slider prova2;
    void Update()
    {
        prova.volume = prova2.value;
    }
}
