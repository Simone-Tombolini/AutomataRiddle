using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnSingleState : MonoBehaviour
{
    public GameObject manager;
    public Button delateButton;
    public GameObject spawnManager;
    public GameObject StartState;
    public Button button;
    public Button consumebutton;
    public GameObject audiodestroyer;
   
    public void spawnStart()
    {
  
        GameObject temp;
        temp = Instantiate(StartState, new Vector2((float)7.5,(float)2.5), Quaternion.identity);
        temp.GetComponent<Drag_And_Drop>().spawnManager = spawnManager;
        temp.GetComponent<DeleteState>().manager = manager;
        temp.GetComponent<DeleteState>().delateButton = delateButton;
        temp.GetComponent<DeleteState>().consumeButton = consumebutton;
        temp.GetComponent<DeleteState>().audioDestroy = audiodestroyer;
        //temp.GetComponent<DeleteState>().startButton = button;
        manager.GetComponent<Manager>().startState = temp; 
        button.interactable = false;
        consumebutton.interactable = true;
        manager.GetComponent<Manager>().refreshCounter();    
   
    }

}
