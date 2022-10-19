using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableFinalState : MonoBehaviour
{
    public GameObject Ring;
    public GameObject manager;
    public int code = 0;
    public void enableFinalState()
    {
        Ring.SetActive(true);
        manager.GetComponent<Manager>().allSateFinal[code] = true;

    }
}
