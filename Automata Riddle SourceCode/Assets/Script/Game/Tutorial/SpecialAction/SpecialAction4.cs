using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAction4 : MonoBehaviour
{
    public GameObject manager;
    private void Start()
    {
        manager.GetComponent<Manager>().createDelta(-1, 0, "0");
        //manager.GetComponent<Manager>().deltaArray[0].state1 = -1;
        //manager.GetComponent<Manager>().deltaArray[0].state2 = 0;
        //manager.GetComponent<Manager>().deltaArray[0].charachter = "0";
        manager.GetComponent<Manager>().PrintDelta();
    }
}
