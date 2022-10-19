using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpecialAction2 : MonoBehaviour
{
    public Image image;
    public GameObject tutorial;
    private void Start()
    {
        image.gameObject.SetActive(true);
        tutorial.GetComponent<Tutorial>().courrentImage++;

        this.gameObject.SetActive(false);

    }
}
