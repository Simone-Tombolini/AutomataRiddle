using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardCodeSenderToArch : MonoBehaviour
{
    public string cardValue = "";
    public GameObject cardManager;
    public Button Confirm;
    public bool clicked = false;
    public Button myself;
    Color mycolor = new Color32(112, 182, 105, 255);

    public void sendCode()
    {
        if (clicked== false)
        {
            cardManager.GetComponent<CardManager>().setAllFalseExeptthis(myself);
            myself.image.color = mycolor;
            clicked = true;
            Confirm.interactable = true;
            Confirm.GetComponent<CreateArch>().cardValue = cardValue;
        }
        else
        {
            cardManager.GetComponent<CardManager>().setAvableArc();
            myself.image.color = Color.white;
            clicked = false;
            Confirm.interactable = false;
            Confirm.GetComponent<CreateArch>().cardValue = "";
        }
        
    }
}
