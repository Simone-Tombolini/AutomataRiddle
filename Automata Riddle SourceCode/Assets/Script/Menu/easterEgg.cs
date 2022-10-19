
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class easterEgg : MonoBehaviour
{
    [SerializeField]
    int c = 0;
    bool appear = false;
    public int i = 0;
    public GameObject egg;
    public AudioSource eggsound;
    public AudioSource pop;
    public void clikegg()
    {
        c++;
        if(c == 42)
        {
            print("doEasterEgg");
            appear = true;
            egg.SetActive(true);
            eggsound.Play(0);
            c =0;
        }
    }
    public void Update()
    {
        if(appear == true)
        {
            i++;
        }
        if(i >= 420)
        {
            egg.SetActive(false);
            appear = false;
            i = 0;
            pop.Play(0);
            
        }
    }
}
