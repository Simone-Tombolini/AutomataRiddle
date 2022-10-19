using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttonimagechanger : MonoBehaviour
{
    public GameObject specialaction;
    public void activateSpecialAction()
    {
        specialaction.SetActive(true);
    }
}
