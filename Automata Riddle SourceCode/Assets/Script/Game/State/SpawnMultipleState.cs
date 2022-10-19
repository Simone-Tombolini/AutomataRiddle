using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnMultipleState : MonoBehaviour
{
    public GameObject manager;
    public GameObject spawnManager;
    public Button stateButton;
    public Button deleteButton;
    public GameObject[] StateArray;
    public GameObject audiodestroyer;
    public Button consumeButton;
    //private int i = 0;
    public void spawnState()
    {
        for (int i = 0; i < manager.GetComponent<Manager>().maxState - 1; i++)
        {
            if(StateArray.Length - 1 == i)
            {
                stateButton.interactable = false;
            }
            if (manager.GetComponent<Manager>().qStateArray[i] == null)
            {
                GameObject clone = Instantiate(StateArray[i], new Vector2((float)7.5, (float)2.5), Quaternion.identity);
                clone.GetComponent<Drag_And_Drop>().spawnManager = spawnManager;
                clone.GetComponent<DeleteState>().manager = manager;
                clone.GetComponent<DeleteState>().delateButton = deleteButton;
                clone.GetComponent<DeleteState>().audioDestroy = audiodestroyer;
                clone.GetComponent<DeleteState>().consumeButton = consumeButton;
                manager.GetComponent<Manager>().qStateArray[i] = clone;
                manager.GetComponent<Manager>().refreshCounter();
                break;
            }
            
        }
        //    if (i < StateArray.Length - 1)
        //    {
        //        GameObject clone =Instantiate(StateArray[i], new Vector2((float)7.5, (float)2.5), Quaternion.identity);
        //        clone.GetComponent<Drag_And_Drop>().spawnManager = spawnManager;
        //        manager.GetComponent<Manager>().qStateArray[i] = clone;
        //        manager.GetComponent<Manager>().refreshCounter();
        //        i++;
        //    }
        //    else if (StateArray.Length -1 == i)
        //    {
        //        GameObject clone1 = Instantiate(StateArray[i], new Vector2((float)7.5, (float)2.5), Quaternion.identity);
        //        clone1.GetComponent<Drag_And_Drop>().spawnManager = spawnManager;
        //        stateButton.interactable = false;
        //        manager.GetComponent<Manager>().qStateArray[i] = clone1;
        //        manager.GetComponent<Manager>().refreshCounter();
        //        i++;
        //    }
        //    else
        //        print("error");
    }
}
