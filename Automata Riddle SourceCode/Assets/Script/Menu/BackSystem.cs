using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackSystem : MonoBehaviour
{
    public GameObject loader;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            this.GetComponent<CangeSceneName>().changename();
            this.GetComponent<ReproduceSoundEffect>().ReproduceSound();
            loader.GetComponent<Load_Scene>().LoadNewSceneTransition1();
        }
    }
}
