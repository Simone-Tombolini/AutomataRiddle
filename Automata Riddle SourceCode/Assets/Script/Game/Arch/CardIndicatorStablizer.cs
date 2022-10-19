using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardIndicatorStablizer : MonoBehaviour
{

    public GameObject arrow;
    void Update()
    {
        this.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90 - arrow.gameObject.transform.rotation.z));
    }
}
