using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openLink : MonoBehaviour
{
    public string linkName;
    
    public void openlink()
    {
        Application.OpenURL(linkName);
    }
}
