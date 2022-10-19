using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class saveSettings : MonoBehaviour
{
    public Slider musicsetting;
    public Slider effectsetting;
    public Text track;


    public void loadSetting()
    {
        
        Settings settings  = SaveSystem.readSettings();
    
        musicsetting.value = settings.musicvolume;
        effectsetting.value = settings.EffectVolume;
        track.text = SaveSystem.readMusic().ToString();
        print(settings.EffectVolume);
    }

    public void save()
    {
        SaveSystem.saveSetting(musicsetting.value, effectsetting.value, track.GetComponent<MusicSelector>().selNumber);
    }

    private void Start()
    {
        loadSetting();
    }
}
