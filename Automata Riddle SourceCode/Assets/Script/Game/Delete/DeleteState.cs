using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class DeleteState : MonoBehaviour
{
    public int code;
    //public bool destroyer = true;
    public GameObject manager;
    public Button delateButton;
    public Button consumeButton;
    public GameObject audioDestroy;
    public bool specialAction1 = false;
    
    private void Start()
    {
        code = this.GetComponent<EnableFinalState>().code;
    }
    public void OnMouseOver()
    {
        if (delateButton.GetComponent<DelatebuttonManager>().delate == true)
        {

     

            //destroyer == true &&
            if (Input.GetMouseButtonDown(0))
            {
             
                
                if (code == -1)
                {
                    manager.GetComponent<Manager>().startState = null;
                    manager.GetComponent<Manager>().startStateIsFinal = false;
                    consumeButton.interactable = false;
                    manager.GetComponent<Manager>().consumeBtn = false;

                }
                else
                {
                    manager.GetComponent<Manager>().qStateArray[code] = null;
                    manager.GetComponent<Manager>().allSateFinal[code] = false;
                }
                for (int i = 0; i < manager.GetComponent<Manager>().lineArray.Length; i++)
                {
                    if(manager.GetComponent<Manager>().lineArray[i] != null && 
                        (manager.GetComponent<Manager>().lineArray[i].GetComponent<Line>().gameObject1 == this.gameObject ||
                        manager.GetComponent<Manager>().lineArray[i].GetComponent<Line>().gameObject2 == this.gameObject))
                    {
                        Destroy(manager.GetComponent<Manager>().lineArray[i]);
                        manager.GetComponent<Manager>().lineArray[i] = null;
                    }
                }
                for (int i = 0; i < manager.GetComponent<Manager>().arrowarray.Length; i++)
                {
                    if (manager.GetComponent<Manager>().arrowarray[i] != null &&
                        (manager.GetComponent<Manager>().arrowarray[i].GetComponent<ArchArrowCode>().FirstCode == this.gameObject.GetComponent<EnableFinalState>().code 
                        || manager.GetComponent<Manager>().arrowarray[i].GetComponent<ArchArrowCode>().SecondCode == this.gameObject.GetComponent<EnableFinalState>().code))
                    {
                        Destroy(manager.GetComponent<Manager>().arrowarray[i]);
                        manager.GetComponent<Manager>().arrowarray[i] = null;
                    }
                }
                for (int i = 0; i < manager.GetComponent<Manager>().deltaArray.Length; i++)
                {
                    if(manager.GetComponent<Manager>().deltaArray[i] != null &&
                        (manager.GetComponent<Manager>().deltaArray[i].state1 == this.gameObject.GetComponent<EnableFinalState>().code ||
                        manager.GetComponent<Manager>().deltaArray[i].state2 == this.gameObject.GetComponent<EnableFinalState>().code))
                    {
                        print(manager.GetComponent<Manager>().deltaArray[i].charachter);
                        manager.GetComponent<Manager>().deltaArray[i] = null;
                    }
                }
                audioDestroy.GetComponent<ReproduceSoundEffect>().ReproduceSound();
                if (specialAction1 == true)
                {
                    manager.GetComponent<Manager>().victoryScreen();
                }
                Destroy(this.gameObject);
                manager.GetComponent<Manager>().refreshCounter();
            }
        }
    }
}
