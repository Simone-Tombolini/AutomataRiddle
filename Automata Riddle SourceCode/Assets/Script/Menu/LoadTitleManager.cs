using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadTitleManager : MonoBehaviour
{
    public GameObject loader;
    public string[] scenes;
    private void Start()
    {
        
        if (SaveSystem.readlevel() < 12)
        {
            loader.GetComponent<Load_Scene>().Scene_name = scenes[0];
        }
        else
        {
            loader.GetComponent<Load_Scene>().Scene_name = scenes[1];
        }
    }
}
