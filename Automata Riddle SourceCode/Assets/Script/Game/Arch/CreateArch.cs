using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CreateArch : MonoBehaviour
{
    public GameObject SourceState1;
    public GameObject SourceState2;
    public GameObject line;
    public GameObject arrow;
    public GameObject manager;
    public GameObject lineManager;

    public int firstCode;
    public int secondCode;
    public string cardValue;

    public GameObject Statemanager1;
    public GameObject Statemanager2;
    public GameObject CardManager;
    public Button closer;

    public void generateArch()
    {
        if(secondCode != firstCode)
        {
            if (firstCode >= 0)
            {
                for (int i = 0; i <= firstCode; i++)
                {
                    if (firstCode == i)
                    {
                        SourceState1 = manager.GetComponent<Manager>().qStateArray[i];

                    }
                }
            }
            else
            {
                SourceState1 = manager.GetComponent<Manager>().startState;
            }

            if (secondCode >= 0)
            {
                for (int i = 0; i <= secondCode; i++)
                {
                    if (secondCode == i)
                    {
                        SourceState2 = manager.GetComponent<Manager>().qStateArray[i];

                    }
                }
            }
            else
            {
                SourceState2 = manager.GetComponent<Manager>().startState;
            }
            if (manager.GetComponent<Manager>().alreadyExistDelta(firstCode, secondCode) == true)
            {
                
                for (int i = 0; i < lineManager.GetComponent<LineManager>().maxLine; i++)
                {
                    if (lineManager.GetComponent<LineManager>().lines[i] != null &&
                        lineManager.GetComponent<LineManager>().lines[i].GetComponent<Line>().gameObject1 == SourceState1 &&
                        lineManager.GetComponent<LineManager>().lines[i].GetComponent<Line>().gameObject2 == SourceState2)
                    {
                        lineManager.GetComponent<LineManager>().lines[i].GetComponent<Line>().label.text =
                        manager.GetComponent<Manager>().alldeltachar(firstCode, secondCode) + cardValue;
                        //lineManager.GetComponent<LineManager>().lines[i].GetComponent<Line>().label.text
                    }
                }
            }
            else
            {
                generateline();
            }
            
            manager.GetComponent<Manager>().createDelta(firstCode, secondCode, cardValue);
        }
        else
        {
            if (firstCode >= 0)
            {
                for (int i = 0; i <= firstCode; i++)
                {
                    if (firstCode == i)
                    {
                        SourceState1 = manager.GetComponent<Manager>().qStateArray[i];

                    }
                }
            }
            else
            {
                SourceState1 = manager.GetComponent<Manager>().startState;
            }
           
            if (manager.GetComponent<Manager>().alreadyExistDelta(firstCode, secondCode) == true)
            {
                print("prova");
                SourceState1.transform.Find("SelfArch").GetComponent<SelfArchRef>().textReferenced.text =
                manager.GetComponent<Manager>().alldeltachar(firstCode, secondCode) + cardValue;

//                SourceState1.transform.Find("SelfArch").GetComponent<SelfArchRef>().textReferenced.text =
//SourceState1.transform.Find("SelfArch").GetComponent<SelfArchRef>().textReferenced.text + cardValue;
            }
            else
            {
                SourceState1.transform.Find("SelfArch").gameObject.SetActive(true);
                SourceState1.transform.Find("SelfArch").GetComponent<SelfArchRef>().textReferenced.text = cardValue;
            }
            
            manager.GetComponent<Manager>().createDelta(firstCode, secondCode, cardValue);
        }
        
        closeAll();
    }
    
    public void generateline()
    {

        GameObject lineClone;
        lineClone = Instantiate(line, new Vector2(0, 0), Quaternion.identity);
        lineClone.GetComponent<Line>().gameObject1 = SourceState1;
        lineClone.GetComponent<Line>().gameObject2 = SourceState2;
        GameObject arrowClone = Instantiate(arrow, new Vector2(SourceState2.transform.position.x, SourceState2.transform.position.y), Quaternion.identity);
        arrowClone.transform.SetParent(SourceState2.transform);
        lineClone.GetComponent<Line>().arrow = arrowClone;
        Text LabelClone = lineClone.GetComponent<Line>().arrow.GetComponent<ArchArrowCode>().Label;
        lineClone.GetComponent<Line>().arrow.GetComponent<ArchArrowCode>().FirstCode = firstCode;
        lineClone.GetComponent<Line>().arrow.GetComponent<ArchArrowCode>().SecondCode= secondCode;
        lineClone.GetComponent<Line>().label = LabelClone;
        lineClone.GetComponent <Line>().label.text = cardValue;
        //TODO levare la variabile lastCounter
        lineManager.GetComponent<LineManager>().lines[
            manager.GetComponent<Manager>().firsNullSpotArray(lineManager.GetComponent<LineManager>().lines)] = lineClone;
        //lineManager.GetComponent<LineManager>().lastcounter++;

        manager.GetComponent<Manager>().lineArray[manager.GetComponent<Manager>().firsNullSpotArray(manager.GetComponent<Manager>().lineArray)] = lineClone;
        manager.GetComponent<Manager>().arrowarray[manager.GetComponent<Manager>().firsNullSpotArray(manager.GetComponent<Manager>().arrowarray)] = arrowClone;
    }

    public void closeAll()
    {
        manager.GetComponent<Manager>().refreshCounter();
        SourceState1 = null;
        SourceState2 = null;
        firstCode = -2;
        secondCode = -2;
        cardValue = "";
        CardManager.GetComponent<CardManager>().setAllWhite();
        CardManager.GetComponent<CardManager>().SetAllintercetableFalse();

        Statemanager1.GetComponent<ArchButtonManager>().SetAllIntercetableTrue();
        Statemanager1.GetComponent<ArchButtonManager>().setAllWite();
        Statemanager1.GetComponent<ArchButtonManager>().setAllClickedFalse();

        Statemanager2.GetComponent<ArchButtonManager>().SetAllIntercetableTrue();
        Statemanager2.GetComponent<ArchButtonManager>().setAllWite();
        Statemanager2.GetComponent<ArchButtonManager>().setAllClickedFalse();
        closer.GetComponent<GenerateArchMenu>().closeMenu();
    }
}
