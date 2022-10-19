using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAction5 : MonoBehaviour
{
    public GameObject manager;
    void Start()
    {
        manager.GetComponent<Manager>().createDelta(-1, 0, "0");
        manager.GetComponent<Manager>().createDelta(0, 1, "1");
        manager.GetComponent<Manager>().createDelta(1, 0, "0");
        manager.GetComponent<Manager>().allSateFinal[1] = true;
        manager.GetComponent<Manager>().PrintDelta();
    }
}
