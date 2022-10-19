using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickImageChanger : MonoBehaviour
{
    public int imagenumber;
    public GameObject tutorial;
    public bool nextImage = true;
    public GameObject specialAction;
    public GameObject sound;
    bool detected=false;
    void OnMouseOver()
    {
        print("prova");
        if (Input.GetMouseButtonDown(0))
        {
            detected = true;
        }
    }
    void Update()
    {
        if (detected== true)
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
            detected = false;
        }



        if (specialAction != null)
        {
            specialAction.SetActive(true);
        }

    }
}
