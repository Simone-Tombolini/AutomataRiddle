using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DelatebuttonManager : MonoBehaviour
{
    public bool delate = false;
    
    public Sprite notActive;
    public Sprite Active;
    public Camera mainCamera;
    public GameObject manager;
    Color neutral; //ECE6D4
    private void Start()
    {
        neutral.a = 1;
        neutral.r = 236;
        neutral.g = 230;
        neutral.b = 212;
    }
    public void deleteManager()
    {
        if (delate == false)
        {
            delate = true;
            this.GetComponent<Image>().sprite = Active;
            mainCamera.backgroundColor = Color.red;
            //manager.GetComponent<Manager>().setAllButtonFalse();
            manager.GetComponent<Manager>().DelateLoockButton();

        }
        else
        {
            delate = false;
            this.GetComponent<Image>().sprite = notActive;
            mainCamera.backgroundColor = neutral;
            //manager.GetComponent<Manager>().setAllButtonTrue();
            manager.GetComponent<Manager>().parsingUnloockbutton();
        }
    }
}
