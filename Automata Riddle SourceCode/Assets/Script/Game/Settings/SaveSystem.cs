
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.Collections;
using System.Collections.Generic;

public static class SaveSystem
{
    public static void saveLevel(int level)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/level.txt";
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, level);
        stream.Close();
        
    }

    public static int readlevel()
    {
        string path = Application.persistentDataPath + "/level.txt";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            int level = (int)formatter.Deserialize(stream);
            stream.Close();
            return level;
        }
        else
        {
            return 1;
        }
    }

    public static int readMusic()
    {
        string path = Application.persistentDataPath + "/settings.txt";


        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Settings settinf = formatter.Deserialize(stream) as Settings;
            stream.Close();
            return settinf.trackmusic;

        }
        else
        {
            Settings middleSettinf = new Settings(0.5f, 0.5f, 1);

            return middleSettinf.trackmusic;

        }
        
    }
    public static void saveSetting(float vol1, float vol2)
    {
        Settings settings = new Settings(vol1, vol2);
        settings.musicvolume = vol1;
        settings.EffectVolume = vol2;

        string path = Application.persistentDataPath + "/settings.txt";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, settings);
        stream.Close();
    }
    public static void saveSetting(float vol1, float vol2, int track)
    {
        Settings settings = new Settings(vol1, vol2, track);
        settings.musicvolume = vol1;
        settings.EffectVolume = vol2;

        string path = Application.persistentDataPath + "/settings.txt";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, settings);
        stream.Close();
    }

    public static Settings readSettings()
    {
        string path = Application.persistentDataPath + "/settings.txt";
        

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Settings settinf =  formatter.Deserialize(stream) as Settings;
            stream.Close();
            return settinf;
            
        }
        else
        {
            Settings middleSettinf = new Settings(0.5f, 0.5f);
            
            return middleSettinf;
            
        }
    }

 
}
