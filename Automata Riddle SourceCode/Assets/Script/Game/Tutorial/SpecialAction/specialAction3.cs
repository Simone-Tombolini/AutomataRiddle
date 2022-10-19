using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class specialAction3 : MonoBehaviour
{
    public GameObject manager;
    public Image image;
    void Start()
    {
     
        manager.GetComponent<Manager>().victoryScreen();
        image.gameObject.SetActive(false);
    }

}
