using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArchCodeSender : MonoBehaviour
{
    public GameObject CardManager;
    public int archCode;
    public Button Confirm;
    public bool first=true;
    public GameObject buttonManager;
    public bool clicked = false;
    public Button myself;
    Color mycolor = new Color32(112, 182, 105, 255);
   public void sendCode()
    {
        if (clicked == false)
        {
            buttonManager.GetComponent<ArchButtonManager>().setAllIntercetableFalseExThis(myself);
            myself.image.color = mycolor;
            clicked = true;
            sendNumberCode(archCode);
        }
        else
        {
            buttonManager.GetComponent<ArchButtonManager>().SetAllIntercetableTrue();
            
            myself.image.color = Color.white;
            clicked = false;
            sendNumberCode(-2);
        }


        CardManager.GetComponent<CardManager>().setAvableArc();
    }
    public void sendNumberCode(int code)
    {

        if (first)
        {
            Confirm.GetComponent<CreateArch>().firstCode = code;

        }
        else
        {
            Confirm.GetComponent<CreateArch>().secondCode = code;

        }
    }
}
