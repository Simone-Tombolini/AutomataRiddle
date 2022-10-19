using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class imageChanger : MonoBehaviour
{
    public int imagenumber;
    public GameObject tutorial;
    public bool nextImage = true;
    public GameObject specialAction;
    public GameObject sound;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (nextImage == true)
            {
                tutorial.GetComponent<Tutorial>().courrentImage++;
                tutorial.GetComponent<Tutorial>().SetNextImage();
            }
            else
            {
                tutorial.GetComponent<Tutorial>().SetCouurentImageOff();
            }
            sound.GetComponent<ReproduceSoundEffect>().ReproduceSound();
        }

     

        if(specialAction!= null)
        {
            specialAction.SetActive(true);
        }
     
    }
}
