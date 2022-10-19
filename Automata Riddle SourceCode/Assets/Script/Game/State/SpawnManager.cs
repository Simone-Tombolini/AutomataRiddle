using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public bool Occupied = false;
    public bool occupied2;

    public Button button1;
    public bool btn1State;
    public Button button2;
    public bool btn2State;
    public Button button3;
    public bool btn3State;
    public Button button4;
    public bool btn4State;
    public Button button5;
    public bool btn5State;
    public Button button6;
    public bool btn6State;
    public bool checkButtonState(Button button)
    {
        bool r = true;
        if (button.interactable == false)
        {
            r = false;
        }
        return r;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Occupied == false && collision.gameObject.tag != "CardIndicator")
        {
            Occupied = true;
            btn1State = checkButtonState(button1);
            btn2State = checkButtonState(button2);
            btn3State = checkButtonState(button3);
            btn4State = checkButtonState(button4);
            btn5State = checkButtonState(button5);
            btn6State = checkButtonState(button6);
        }else if(Occupied == true)
        {
            occupied2 = true;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "CardIndicator")
        {
            button1.interactable = false;
            button2.interactable = false;
            button3.interactable = false;
            button4.interactable = false;
            button5.interactable = false;
            button6.interactable = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (Occupied == true && collision.gameObject.tag != "CardIndicator")
        {
            if(occupied2 == true)
            {
                occupied2 = false;
            }
            else
            {
                Occupied = false;
                button1.interactable = btn1State;
                button2.interactable = btn2State;
                button3.interactable = btn3State;
                button4.interactable = btn4State;
                button5.interactable = btn5State;
                button6.interactable = btn6State;
            }
          
        }
    }
}
