using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateFinalStateMenu : MonoBehaviour
{
    public int SpawnPositionX = -350, SpawnPositionY = 100;
    public GameObject manager;
    public Button[] StatesButton;
    public Button startState;
    public GameObject panel;
    public void genereteMenu()
    {
        
 
        if(manager.GetComponent<Manager>().maxFinalState > 0)
        {
            setActiveButton();
        }else
        {
            setFalseNotFinalButton();
        }

        panel.SetActive(true);

    }
    public void closeMenu()
    {
        panel.SetActive(false);
        setFlaseAllbutton();
     
    }

    public void setFlaseAllbutton()
    {
        startState.interactable = false;

        for (int i = 0; i < manager.GetComponent<Manager>().qStateArray.Length; i++)
        {
            StatesButton[i].interactable = false;
        
        }
    }
    public void setFalseNotFinalButton()
    {
        setFlaseAllbutton();
        if (manager.GetComponent<Manager>().startState != null 
            && manager.GetComponent<Manager>().startStateIsFinal==true)
        {
            startState.interactable = true;

        }

        for (int i = 0; i < manager.GetComponent<Manager>().qStateArray.Length; i++)
        {
            if (manager.GetComponent<Manager>().qStateArray[i] != null
                && manager.GetComponent<Manager>().qStateArray[i].GetComponent<EnableFinalState>().code == i
                && manager.GetComponent<Manager>().allSateFinal[i] == true)
            {
                StatesButton[i].interactable = true;
            }
        }
    }
    public void setActiveButton()
    {
        if (manager.GetComponent<Manager>().startState != null)
        {
            startState.interactable = true;
        }

        for (int i = 0; i < manager.GetComponent<Manager>().qStateArray.Length; i++)
        {
            if (manager.GetComponent<Manager>().qStateArray[i] != null 
                && manager.GetComponent<Manager>().qStateArray[i].GetComponent<EnableFinalState>().code == i)
            {
                StatesButton[i].interactable = true;
                
            }
        }
    }
}
