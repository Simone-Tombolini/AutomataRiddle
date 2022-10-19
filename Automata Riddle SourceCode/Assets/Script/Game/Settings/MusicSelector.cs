using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSelector : MonoBehaviour
{
    public int selNumber = 1;
    public GameObject audiomanager;
    public Text text;
    public Button plus;
    public Button minus;

    private void Start()
    {
        selNumber = SaveSystem.readMusic();
        if(selNumber == 1)
        {
            minus.interactable = false;

        }
        if(selNumber == 5)
        {
            plus.interactable=false;
        }
    }
    public void ActualSecectionPlus()
    {
        audiomanager.GetComponent<MusicManager>().stopSong(selNumber);
        selNumber++;
        text.text = selNumber.ToString();
        if(selNumber >= 5)
        {
            plus.interactable= false;
        }
        minus.interactable = true;
        //audiomanager.SetActive(false);
        //audiomanager.SetActive(true);
        
        audiomanager.GetComponent<MusicManager>().song = selNumber;
        audiomanager.GetComponent<MusicManager>().startSong(selNumber);
       
    }
    public void ActualSecectionMinus()
    {

        audiomanager.GetComponent<MusicManager>().stopSong(selNumber); 
        selNumber--;
        text.text = selNumber.ToString();
        if (selNumber <= 1)
        {
            minus.interactable= false;  
        }

        plus.interactable = true;
        //audiomanager.SetActive(false);
        //audiomanager.SetActive(true);
        //audiomanager.GetComponent<MusicManager>().startSong();
        audiomanager.GetComponent<MusicManager>().song = selNumber;
        audiomanager.GetComponent<MusicManager>().startSong(selNumber);
    }

}
