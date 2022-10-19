using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenugenericManager : MonoBehaviour
{

    public GameObject Panel;

    public void OpenMenu()
    {
        Panel.SetActive(true);
    }

    public void closeMenu() 
    { 
        Panel.SetActive(false); 
    }
}
