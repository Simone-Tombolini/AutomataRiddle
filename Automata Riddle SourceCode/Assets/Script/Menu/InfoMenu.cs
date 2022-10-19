using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoMenu : MonoBehaviour
{
    public GameObject panel;
    public void openMenu()
    {
        panel.SetActive(true);
    }
    public void closeMenu()
    {
        panel.SetActive(false);
    }
}
