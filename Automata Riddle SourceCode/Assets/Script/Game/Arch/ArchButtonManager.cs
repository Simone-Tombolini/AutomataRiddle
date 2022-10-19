using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArchButtonManager : MonoBehaviour
{
    public Manager manager;
    public Button startStateButton;
    public Button[] buttonArray;


    public void setVisibleOnlyspawned()
    {
        SetAllFalse();
        if (manager.GetComponent<Manager>().startState != null)
        {
            startStateButton.gameObject.SetActive(true);
        }
        for (int i = 0; i < manager.GetComponent<Manager>().qStateArray.Length; i++) { 
            if (manager.GetComponent<Manager>().qStateArray[i] != null)
            {
                buttonArray[i].gameObject.SetActive(true); 
            }
        }
    }
    
    public void setAllWite()
    {
        startStateButton.image.color = Color.white;
        for (int i = 0; i < buttonArray.Length; i++) 
        { 
        buttonArray[i].image.color = Color.white;
        }
    }

    public void setAllClickedFalse()
    {
        startStateButton.GetComponent<ArchCodeSender>().clicked = false;
        
        for (int i = 0; i < buttonArray.Length; i++)
        {
            buttonArray[i].GetComponent<ArchCodeSender>().clicked = false;
        }
    }
    public void setAllIntercetableFalseExThis(Button thisButton)
    {
        SetAllIntercetableFalse();
        thisButton.interactable = true; 
    }

    public void SetAllIntercetableTrue()
    {
        startStateButton.interactable = true;
        for (int i = 0; i < buttonArray.Length; i++)
        {
            buttonArray[i].interactable = true;
        }
    }
    public void SetAllTrue()
    {
        startStateButton.gameObject.SetActive(true);

        for (int i = 0; i < buttonArray.Length; i++)
        {
            if (buttonArray[i] != null) { buttonArray[i].gameObject.SetActive(true); }
        }
    }

    public void SetAllIntercetableFalse()
    {
        startStateButton.interactable = false;
        for(int i = 0; i < buttonArray.Length; i++)
        {
            buttonArray[i].interactable = false;
        }
    }
    public void SetAllFalse()
    {
        startStateButton.gameObject.SetActive(false);

        for(int i = 0; i < buttonArray.Length; i++)
        {
            if(buttonArray[i] != null) { buttonArray[i].gameObject.SetActive(false); }
        }
    }
    private void Start()
    {
        
    }
}
