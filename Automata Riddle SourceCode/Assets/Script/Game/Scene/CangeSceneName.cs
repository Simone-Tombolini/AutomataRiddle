using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CangeSceneName : MonoBehaviour
{
    public string SceneName;
    public GameObject loader;

    public void changename()
    {
        loader.GetComponent<Load_Scene>().Scene_name = SceneName;
    }
}
