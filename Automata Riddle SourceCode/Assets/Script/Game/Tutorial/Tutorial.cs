using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tutorial : MonoBehaviour
{
    public Image[] imageSet;
    public int courrentImage;
    public void SetNextImage()
    {
        imageSet[courrentImage - 1].gameObject.SetActive(false);
        imageSet[courrentImage].gameObject.SetActive(true);
        
    }

    public void SetCouurentImageOff()
    {
        imageSet[courrentImage].gameObject.SetActive(false);
    }
}
