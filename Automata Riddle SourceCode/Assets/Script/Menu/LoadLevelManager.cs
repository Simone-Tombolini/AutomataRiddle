using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LoadLevelManager : MonoBehaviour
{
   
    public int levelMax;
    public int levelPrex;

    public Button leftarrow;
    public Button rightarrow;
    public Button[] buttonLevel;

    

    public Color color = new Color32(173, 173, 149, 200);

    public void LoadLevel()
    {
        //SaveSystem.saveLevel(0);
        print(SaveSystem.readlevel());
        int level = SaveSystem.readlevel();
        level = level - levelPrex;
        
        if(level >= levelMax)
        {
            rightarrow.interactable = true;
        }
        else
        {
            rightarrow.interactable = false;
        }
        
        for(int i = 0; i < buttonLevel.Length; i++)
        {
            if(i < level)
            {
                buttonLevel[i].interactable = true;

            }
            else if (i == level)
            {
                buttonLevel[i].interactable = true;
                buttonLevel[i].image.color = color;
                    
            }
            else
            {
                buttonLevel[i].interactable = false;
            }
        }
    }
    private void Start()
    {
        //todo.r = 173;
        //todo.g = 173;
        //todo.b = 149;
        //todo.a = 200;
        LoadLevel();
    }
}
