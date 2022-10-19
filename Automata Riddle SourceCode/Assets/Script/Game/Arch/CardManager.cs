using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardManager : MonoBehaviour
{
    public Button[] CardArray;
    public Button archCreator;
    public GameObject manager;
    public bool determinitic = true;
    private void Start()
    {
        SetAllintercetableFalse();
    }

    public void setAllFalseExeptthis(Button thisButton)
    {
        SetAllintercetableFalse();
        thisButton.interactable = true;
    }
    
    
    public void setAvableArc()
    {
       
        if(getfirstCode()!=-2 && getSecondCode() != -2) {
            SetAllintercetableTrue();

            if (determinitic == true)
            {
                deterministicGenerator();
            }
            else
            {
                NotDeterministicGenerator();
            }
        }
        else
        {
            SetAllintercetableFalse();
           
        }
        setAllWhite();
    }

    void deterministicGenerator()
    {
        for (int i = 0; i < manager.GetComponent<Manager>().countDelta(); i++)
        {
            if (manager.GetComponent<Manager>().deltaArray[i] != null && manager.GetComponent<Manager>().deltaArray[i].getState1() == getfirstCode())
            {
                for (int j = 0; j < CardArray.Length; j++)
                {
                    if (CardArray[j].GetComponent<CardCodeSenderToArch>().cardValue == manager.GetComponent<Manager>().deltaArray[i].getCharachter())
                    {
                        CardArray[j].interactable = false;
                    }

                }

            }

        }
    }
    void NotDeterministicGenerator() 
    {

        for (int i = 0; i < manager.GetComponent<Manager>().countDelta(); i++)
        {
            if (manager.GetComponent<Manager>().deltaArray[i].getState1() == getfirstCode() &&
                manager.GetComponent<Manager>().deltaArray[i].getState2() == getSecondCode())
            {
                for (int j = 0; j < CardArray.Length; j++)
                {
                    if (CardArray[j].GetComponent<CardCodeSenderToArch>().cardValue == manager.GetComponent<Manager>().deltaArray[i].getCharachter())
                    {
                        CardArray[j].interactable = false;
                    }

                }

            }

        }
    }
    public void setAllWhite()
    {
        for(int i = 0; i < CardArray.Length; i++)
        {
            CardArray[i].image.color = Color.white;
            CardArray[i].GetComponent<CardCodeSenderToArch>().clicked = false;        
        }
        archCreator.interactable = false;
    }
    public void SetAllintercetableTrue()
    {
        for (int i = 0; i < CardArray.Length; i++)
        {
            CardArray[i].interactable = true;
        }

    }
    public void SetAllintercetableFalse() 
    { 
        for (int i = 0; i < CardArray.Length; i++)
        {
            CardArray[i].interactable = false;
        }

    }

    int getfirstCode()
    {
        return archCreator.GetComponent<CreateArch>().firstCode;

    }

    int getSecondCode()
    {
        return archCreator.GetComponent<CreateArch>().secondCode;

    }

}
