using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialAction1 : MonoBehaviour
{
    public Button btn1;
    void Start()
    {
        if(btn1 != null)
        {
            btn1.interactable = true;
        }
        this.gameObject.SetActive(false);
    }


}
