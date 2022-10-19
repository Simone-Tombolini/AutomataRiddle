using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateFinalState : MonoBehaviour
{
    public bool state = false;
    public GameObject manager;
    public Button menu;
    public int code;
    public void enableFinalState()
    {
        //trova il componete ring del bottone
        GameObject ring = transform.Find("Ring").gameObject;
       //contollo cambio stato
        if (state) { state = false; } else { state = true; }
        //controllo che lo start state sia correttamente inserito
        if (code == -1 && state==true)
        {
            manager.GetComponent<Manager>().startState.transform.Find("FinalState").gameObject.SetActive(true);
            manager.GetComponent<Manager>().startStateIsFinal = true;
        }else if (code == -1 && state == false)
        {
            manager.GetComponent<Manager>().startState.transform.Find("FinalState").gameObject.SetActive(false);
            manager.GetComponent<Manager>().startStateIsFinal = false;
        }
        //contollo tutti gli altri stati
        for(int i = 0; i < manager.GetComponent<Manager>().qStateArray.Length; i++)
        {
            if (manager.GetComponent<Manager>().qStateArray[i] != null && manager.GetComponent<Manager>().qStateArray[i].GetComponent<EnableFinalState>().code == code)
            {
                if (state == true)
                {
                    manager.GetComponent<Manager>().qStateArray[i].transform.Find("FinalState").gameObject.SetActive(true);
                    manager.GetComponent<Manager>().allSateFinal[i] = true;
                   // state= false;
                }
                else
                {
                    manager.GetComponent<Manager>().qStateArray[i].transform.Find("FinalState").gameObject.SetActive(false);
                    manager.GetComponent<Manager>().allSateFinal[i] = false;
                   // state = true;
                }
            }
            
        }
       
        //se lo stato è falso attiva il ring
        if (ring != null && state == true)
        {
           
            ring.SetActive(true);
            manager.GetComponent<Manager>().maxFinalState--;
            manager.GetComponent<Manager>().refreshCounter();
          
         
        }
        //invece se è vero disattivalo
        else if (ring != null && state == false)
        {
            
            ring.SetActive(false);
            manager.GetComponent<Manager>().maxFinalState++;
            manager.GetComponent<Manager>().refreshCounter();
            
            
        }
        prova();
    }
    public void prova()
    {

        if (manager.GetComponent<Manager>().maxFinalState > 0)
        {
            menu.GetComponent<GenerateFinalStateMenu>().setActiveButton();
        }
        else
        {
            menu.GetComponent<GenerateFinalStateMenu>().setFalseNotFinalButton(); ;
        }
        //if (manager.GetComponent<Manager>().maxFinalState == 0)
        //{
            
        //}
        //else if (manager.GetComponent<Manager>().maxFinalState >= 1)
        //{
            
        //}
    }
}
