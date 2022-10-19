using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class show : MonoBehaviour
{
    public GameObject panel;
    public GameObject panelGray;
    public bool selected= false;
    public void hidePanel()
    {
        if (selected == true)
        {
            panel.SetActive(true);
            panelGray.SetActive(false);
            selected = false;
        }
        else
        {
            panel.SetActive(false);
            panelGray.SetActive(true);
            selected = true;
        }

    }

}
