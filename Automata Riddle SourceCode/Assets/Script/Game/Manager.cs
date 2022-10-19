using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Manager : MonoBehaviour
{
  
    public GameObject startState;
    public bool startStateIsFinal = false;
    public GameObject[] qStateArray;
    public Text stateCounter;
    public Text finalStateCounter;
    public Text archCounter;
    public Text menuFinalSatetCounter;
    public Sprite truecheckbox;
    public Sprite falsecheckbox;
    public Image checkboxstate;
    public bool[] allSateFinal;
    public string[] stateSet;
    public int minState=1;
    public int maxState=1;
    public int maxFinalState=1;
    public int maxArch = 1;

    public Button startButton;
    public Button finlaButton;
    public Button qStateButton;
    public Button archButton;
    public Button consumeButton;
    public Button deleteButton;
    public Button infoButton;

    public string consumableString;
    public string consumableStringBl;
    public GameObject[] consumableCard;
    public GameObject[] consumableCardBl;
    public GameObject[] consumableCardIstance = new GameObject[100];
    public bool[] noDestroy = new bool[100];
    public float startCardX, startCardY;
    public int lastDeltaindex = 0;
    [SerializeField]
    public const int maxDelta = 50;
    public delta[] deltaArray = new delta[maxDelta];
    public GameObject parsingPoint;
    public GameObject panelVictory;
    public GameObject[] lineArray = new GameObject[maxDelta];
    public GameObject[] arrowarray = new GameObject[maxDelta];
    public bool WhCardVicotry = false;

    public GameObject failAudio;
    public GameObject destroyAudio;
    public int levelCode;

    public GameObject specialAction1;
  

    
    
    public class delta 
    { 
        public int state1 = -2, state2 = -2;
        public string charachter = "null";
        public int getState1()
        {
            return state1;
        }
        public int getState2()
        {
            return state2;
        }
        public string getCharachter() 
        { 
            return charachter;
        }
    }
    
    public void createDelta(int state1, int state2, string consumable)
    {
        if (lastDeltaindex <= maxDelta)
        {
            delta newdelta = new delta();
            newdelta.state1 = state1;
            newdelta.state2 = state2;
            newdelta.charachter = consumable;
            deltaArray[lastDeltaindex] = newdelta;
           
            lastDeltaindex++;
           
        }
        else
        {
            print("TODO messaggio fine delta");
        }
    }
    
    public string alldeltachar(int code1, int code2)
    {
        string chars = "";

        for (int i = 0; i < deltaArray.Length; i++)
        {
            if (deltaArray[i] != null && code1 == deltaArray[i].state1 && code2 == deltaArray[i].state2)
            {
                chars = chars + deltaArray[i].charachter;
            }
        }


        return chars;
    }
    public bool alreadyExistDelta(int code1, int code2)
    {
        bool r=false;
        for(int i = 0; i < deltaArray.Length; i++)
        {
            if (deltaArray[i] != null &&
                deltaArray[i].state1 == code1 && deltaArray[i].state2== code2)
            {
                r=true;
            }
        }

        return r;
    }
    public int countDelta()
    {
        int count = 0;
        for(int i = 0; i < deltaArray.Length; i++)
        {
            if(deltaArray[i] != null)
            {
                count++;
            }
        }
        return count;
    }
    
    public void PrintDelta()
    {
        print("inizio");
        for (int i = 0; i < deltaArray.Length; i++)
        {
            if(deltaArray[i] != null)
            {
                print(deltaArray[i].state1 + "|" + deltaArray[i].state2 + "|" + deltaArray[i].charachter);
            }else
            {
                print("null");
            }
            
        }
        print("fine");
    }
    
    public void parsingDeterministicBlackCard()
    {
        //victoryScreen();
        seteemptynodestroy();
        for(int i = 0; i < consumableCardIstance.Length; i++)
        {
            consumableCardIstance[i] = null;
        }
        spawnBlackCards(startCardX, startCardY);
        
        if(consumableStringBl== "")
        {
            victoryScreen();
        }
        else {
            if (startState != null)
            {
                PrintDelta();
                blockAll();
                GameObject Point;
                Point = Instantiate(parsingPoint, new Vector2(startState.transform.position.x, startState.transform.position.y), Quaternion.identity);
                Point.GetComponent<Movement>().manager = this.gameObject;
                Point.GetComponent<Movement>().destroyaudio = destroyAudio;

                string parsingString = consumableStringBl;
                int moveIndex = 0;
                int actualstate = -1;
                bool finished = false;
                bool find = false;
                while (finished == false)
                {
                    find = false;
                    for (int i = 0; i < maxDelta; i++)
                    {
                        if (parsingString.Substring(0, 1) != "S")
                        {
                            if (deltaArray[i] != null &&
                            deltaArray[i].state1 == actualstate && parsingString.Substring(0, 1) == deltaArray[i].charachter)
                            {

                                if (deltaArray[i].state1 == deltaArray[i].state2)
                                {
                                    Point.GetComponent<Movement>().movementList[moveIndex, 0] = getXstate(deltaArray[i].state2);
                                    Point.GetComponent<Movement>().movementList[moveIndex, 1] = getYstate(deltaArray[i].state2) + 1f;
                                    noDestroy[moveIndex] = true;
                                    moveIndex++;
                                }
                                Point.GetComponent<Movement>().movementList[moveIndex, 0] = getXstate(deltaArray[i].state2);
                                Point.GetComponent<Movement>().movementList[moveIndex, 1] = getYstate(deltaArray[i].state2);
                                parsingString = parsingString.Substring(1);
                                actualstate = deltaArray[i].state2;
                                find = true;
                                moveIndex++;
                                break;
                            }

                        }
                        else
                        {
                            if (actualstate == -1)
                            {
                                Point.GetComponent<Movement>().movementList[moveIndex, 0] = startState.transform.position.x;
                                Point.GetComponent<Movement>().movementList[moveIndex, 1] = startState.transform.position.y - 1f;
                                noDestroy[moveIndex] = true;
                                moveIndex++;
                            }
                            Point.GetComponent<Movement>().movementList[moveIndex, 0] = startState.transform.position.x;
                            Point.GetComponent<Movement>().movementList[moveIndex, 1] = startState.transform.position.y;
                            parsingString = parsingString.Substring(1);

                            actualstate = -1;
                            find = true;
                            moveIndex++;
                            break;
                        }


                    }
                    if (find == false)
                    {
                        finished = true;
                    }
                    if (parsingString == "")
                    {
                        finished = true;
                        if (actualstate == -1)
                        {
                            if (startStateIsFinal == false)
                            {
                                failMessage = "the balck string has been correctly consumed";
                                
                                Point.GetComponent<Movement>().victory = false;
                                Point.GetComponent<Movement>().victoryBl = true;

                            }
                            else
                            {
                                Point.GetComponent<Movement>().victory = false;
                                Point.GetComponent<Movement>().victoryBl = false;

                            }
                        }
                        else
                        {
                            if (allSateFinal[actualstate] == true)
                            {
                                failMessage = "the balck string has been correctly consumed";
                                
                                Point.GetComponent<Movement>().victory = false;
                                Point.GetComponent<Movement>().victoryBl = false;

                            }
                            else
                            {
                                Point.GetComponent<Movement>().victory = false;
                                Point.GetComponent<Movement>().victoryBl = true;
                            }
                        }
                    }
                    else
                    {
                        Point.GetComponent<Movement>().victory = false;
                        Point.GetComponent<Movement>().victoryBl = true;
                    }

                }

                Point.GetComponent<Movement>().startMovement(moveIndex);
                print(parsingString);
            }
        }
    }
    public void parsingDeterministic()
    {
        parsingloockbutton();
        if (startState != null)
        {
            PrintDelta();
            blockAll();
            GameObject Point;
            Point = Instantiate(parsingPoint, new Vector2(startState.transform.position.x, startState.transform.position.y), Quaternion.identity);
            Point.GetComponent<Movement>().manager = this.gameObject;
            Point.GetComponent<Movement>().destroyaudio = destroyAudio;

            string parsingString = consumableString;
            int moveIndex = 0;
            int actualstate = -1;
            bool finished = false;
            bool find = false;
            while (finished == false)
            {
                find = false;
                for (int i = 0; i < maxDelta; i++)
                {
                    if (parsingString.Substring(0, 1) != "S")
                    {
                        if (deltaArray[i] != null &&
                        deltaArray[i].state1 == actualstate && parsingString.Substring(0, 1) == deltaArray[i].charachter)
                        {
                        
                            if (deltaArray[i].state1 == deltaArray[i].state2)
                            {
                                Point.GetComponent<Movement>().movementList[moveIndex, 0] = getXstate(deltaArray[i].state2);
                                Point.GetComponent<Movement>().movementList[moveIndex, 1] = getYstate(deltaArray[i].state2) + 1f;
                                noDestroy[moveIndex] = true;
                                moveIndex++;
                            }
                            Point.GetComponent<Movement>().movementList[moveIndex, 0] = getXstate(deltaArray[i].state2);
                            Point.GetComponent<Movement>().movementList[moveIndex, 1] = getYstate(deltaArray[i].state2);
                            parsingString = parsingString.Substring(1);
                            actualstate = deltaArray[i].state2;
                            find = true;
                            moveIndex++;
                            break;
                        }

                    }
                    else
                    {
                        if (actualstate == -1)
                        {
                            Point.GetComponent<Movement>().movementList[moveIndex, 0] = startState.transform.position.x;
                            Point.GetComponent<Movement>().movementList[moveIndex, 1] = startState.transform.position.y - 1f;
                            noDestroy[moveIndex] = true;
                            moveIndex++;
                        }
                        Point.GetComponent<Movement>().movementList[moveIndex, 0] = startState.transform.position.x;
                        Point.GetComponent<Movement>().movementList[moveIndex, 1] = startState.transform.position.y;
                        parsingString = parsingString.Substring(1);
                       
                        actualstate = -1;
                        find = true;
                        moveIndex++;
                        break;
                    }

                    
                }
                if (find == false)
                {
                    finished = true;
                }
                if (parsingString == "")
                {
                    finished = true;
                    if (actualstate == -1)
                    {
                        if (startStateIsFinal == false)
                        {
                            failMessage = "final state not setted";
                            
                            Point.GetComponent<Movement>().victory = false;
                            
                        }
                        else
                        {
                            Point.GetComponent<Movement>().victory = true;
                          
                        }
                    }
                    else
                    {
                        if (allSateFinal[actualstate] == true)
                        {
                            Point.GetComponent<Movement>().victory = true;
                           
                        }
                        else
                        {
                            failMessage = "final state not setted";

                            
                            Point.GetComponent<Movement>().victory = false;
                           
                        }
                    }
                }
                else
                {

                    failMessage = "not all card consumed"; 
                    
                    Point.GetComponent<Movement>().victory = false;
                    
                }

            }
            Point.GetComponent<Movement>().victoryBl = false;
            Point.GetComponent<Movement>().startMovement(moveIndex);
            print(parsingString);

        }
        else
        {
            failMessage = "set Start State";
            
        }
    }
    
    public float getXstate(int StateCode)
    {
        float r = 0;
        if(StateCode == -1)
        {
            r = startState.transform.position.x;
        }
        for(int i = 0; i < qStateArray.Length; i++) 
        {
            if (i == StateCode)
            {
                r = qStateArray[i].transform.position.x;
            }
        }

        return r;
    }
    public float getYstate(int StateCode)
    {
        float r = 0;
        if (StateCode == -1)
        {
            r = startState.transform.position.y;
        }
        for (int i = 0; i < qStateArray.Length; i++)
        {
            if (i == StateCode)
            {
                r = qStateArray[i].transform.position.y;
            }
        }

        return r;
    }
    bool startBtn;
    bool QstateBtn;
    bool finalBtn;
    bool archBtn;
    bool deleteBtn;
    bool infoBtn;
    public bool consumeBtn;
    public void DelateLoockButton()
    {
        parsingloockbutton();
        deleteButton.interactable = true;
    }
    public void parsingloockbutton()
    {
        if (startButton.interactable == true)
        {
            startBtn = true;
        }
        else
        {
            startBtn = false;
        }
        
        if (qStateButton.interactable == true)
        {
            QstateBtn = true;
        }
        else
        {
            QstateBtn = false;
        }
        
        if (finlaButton.interactable == true)
        {
            finalBtn = true;
        }
        else
        {
            finalBtn = false;
        }

        if (archButton.interactable == true)
        {
            archBtn = true;
        }
        else
        {
            archBtn = false;
        }

        if (consumeButton.interactable == true)
        {
            consumeBtn = true;
        }
        else
        {
            consumeBtn = false;
        }

        if (deleteButton.interactable == true)
        {
            deleteBtn = true;
        }
        else
        {
            deleteBtn = false;
        }

        if (infoButton.interactable == true)
        {
            infoBtn = true;
        }
        else
        {
            infoBtn = false;
        }

        startButton.interactable = false;
        qStateButton.interactable = false;
        finlaButton.interactable = false;
        archButton.interactable = false;
        deleteButton.interactable = false;
        infoButton.interactable = false;
        consumeButton.interactable = false;
    }

    public void parsingUnloockbutton()
    {
        startButton.interactable = startBtn;
        qStateButton.interactable = QstateBtn;
        finlaButton.interactable = finalBtn;
        archButton.interactable = archBtn;
        deleteButton.interactable = deleteBtn;
        infoButton.interactable = infoBtn;
        consumeButton.interactable = consumeBtn;
    }

    public void endParsingBlack()
    {
        victoryScreen();
    }
    public void endParsing(bool victory)
    {
        dragAndDropActive();
        
        if (victory == true)
        {
            parsingDeterministicBlackCard();
        }else
        {
            failScreen();
        }
    }

    public void failScreen()
    {
        seteemptynodestroy();
        parsingUnloockbutton();
        failAudio.GetComponent<ReproduceSoundEffect>().ReproduceSound();
        for(int i =0; i < consumableCardIstance.Length; i++)
        {
            if (consumableCardIstance[i] != null) { Destroy(consumableCardIstance[i].gameObject); }
        }
        if(specialAction1 == null)
        {
            spawnCards(startCardX, startCardY);
        }
       
        if(specialAction1 != null)
        {
            specialAction1.gameObject.SetActive(true);
        }
        FailMessageBox(failMessage);
    }
    public void victoryScreen()
    {
        if (SaveSystem.readlevel() <= levelCode)
        {
            SaveSystem.saveLevel(levelCode);
        }
        panelVictory.SetActive(true);
        print(SaveSystem.readlevel());
     
       
    
    }

    public Image FailMessage;
    public Text FailText;
    public string failMessage = "consuming not succeful";
    public void FailMessageBox(string message)
    {
        StartCoroutine(FailMessageBoxCouroutine(message));
    }
    IEnumerator FailMessageBoxCouroutine(string Message)
    {
        if (FailMessage != null && FailText != null)
        {
            FailText.text = Message;
            FailMessage.gameObject.SetActive(true);

            float transitiontime = 1.5f;
            yield return new WaitForSeconds(transitiontime);
            FailText.text = "consuming not succeful";
            FailMessage.gameObject.SetActive(false);
            failMessage = "consuming not succeful";
        }
    }
    public void blockAll()
        //rendi intercettable= false tutti i bottoni
    {
        dragAndDropStop();
    }

    public void dragAndDropActive()
    {
        for (int i = 0; i < qStateArray.Length; i++)
        {
            if(qStateArray[i] != null)
            {
                qStateArray[i].GetComponent<Drag_And_Drop>().active = true;
            }

        }
        startState.GetComponent<Drag_And_Drop>().active = true;
    }
    public void dragAndDropStop()
    {
        for (int i = 0; i < qStateArray.Length; i++)
        {
            if (qStateArray[i] != null){
                qStateArray[i].GetComponent<Drag_And_Drop>().active = false;
            }
            
        }
        if(startState != null)
            startState.GetComponent<Drag_And_Drop>().active = false;
    }
    //NON RIUTILIZZARE
    public GameObject specialAction2;
    private void Start()
    {
        setAllFalse(allSateFinal);
        refreshCounter();
        spawnCards(startCardX, startCardY);
        if (specialAction2 != null)
        {
            allSateFinal[1] = true;
            specialAction2.SetActive(true);
        }
        
    }

    public void seteemptynodestroy()
    {
        for(int i = 0; i < noDestroy.Length; i++)
        {
            noDestroy[i] = false;
        }
    }
    public void setAllButtonFalse()
    {
        startButton.interactable = false;
        finlaButton.interactable = false;
        qStateButton.interactable = false;
        archButton.interactable = false;
        consumeButton.interactable = false;
    }

    public void setAllButtonTrue()
    {
        finlaButton.interactable = true;
        archButton.interactable = true;
        consumeButton.interactable = true;
        if(startState == null)
        {
            startButton.interactable = true;
            consumeButton.interactable=false;
        }
        if((maxState - 1) - countFullGameObjectArray(qStateArray) != 0)
        {
            qStateButton.interactable = true;
        }
    }

    public void spawnCards(float x, float y)
    {

        for (int i = 0; i < consumableCard.Length; i++)
        {
            GameObject card =  Instantiate(consumableCard[i], new Vector2(x, y), Quaternion.identity);
            consumableCardIstance[i] = card;
            x = x + 1.2f;
            card = null;
        }
    }
    public void spawnBlackCards(float x, float y)
    {
        for (int i = 0; i < consumableCardBl.Length; i++)
        {
            GameObject card = Instantiate(consumableCardBl[i], new Vector2(x, y), Quaternion.identity);
            consumableCardIstance[i] = card;
            x = x + 1.2f;
            card = null;
        }
    }
    //USETHIS
    public void refreshCounter()
    {
        if ((maxState - 1) - countFullGameObjectArray(qStateArray) == 0)
        {
            qStateButton.interactable = false;
            QstateBtn = false;
        }
        else
        {
            //qStateButton.interactable = true;
            QstateBtn = true;
        }
       
        int r1 =(maxState - countAllGameObject());
        string rText = r1.ToString(); 
        if (rText.Length == 1) {
            rText = "0" + rText;
        }
        stateCounter.text = rText;

        string text2 = maxFinalState.ToString();
        if (maxFinalState <= 9)
        {
            text2 = "0" + text2;
        }
        finalStateCounter.text = text2;
        menuFinalSatetCounter.text = text2;

        int r3 = (maxArch - countFullGameObjectArray(deltaArray));
        string text3 = r3.ToString();
        if(r3 <= 9)
        {
            text3 = "0" + text3;
        }
        if(r3 == 0)
        {
            archButton.interactable = false;
        }
        else
        {
            //archButton.interactable = true;
            archBtn = true;
        }
        archCounter.text = text3;
        text3 = "";
        
        if (r1 <= minState)
        {
            checkboxstate.sprite = truecheckbox;
        }
        else
        {
            checkboxstate.sprite = falsecheckbox;
        }

        if(startState != null)
        {
            startButton.interactable = false;
            startBtn = false;
        }
        else
        {
            //startButton.interactable = true;
            startBtn = true;
        }
     
    }
 
    public void setAllFalse(bool[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            allSateFinal[i] = false;
        }
    }

    public int firsNullSpotArray(GameObject[] array)
    {
        int r = 0;
        int i = 0;
        while (array[i] != null)
        {
            i++;
            r = i;
            if (i == array.Length - 1) { break; }

        }
        i = 0;

        return r;
    }
    public bool allIsEmpty()
    {
        bool r = false;
        if(emptyGameObjectArray(qStateArray)==true && startState == null)
        {
            r = true;
        }
        return r;
    }

    public int countAllGameObject()
    {
        int r = 0;
        r= r + countFullGameObjectArray(qStateArray);
        if (startState != null)
            r++;
        return r;
      
    }

    public int countFullGameObjectArray(delta[] array)
    {
        int r = 0;

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] != null)
            {
                r++;
            }
        }
        return r;

    }
    public int countFullGameObjectArray(GameObject[] array) {
        int r = 0;
        
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] != null)
            {
                r++;
            }
        }
        return r;
        
    }
    
    
    public bool emptyGameObjectArray(GameObject[] array)
    {
        bool r = true;
        for (int i = 0; i<array.Length; i++) {
        if (array[i] != null)
            {
                r = false; 
            }
        }
        return r;
    }
    public void disableAllButton()
    {
        startButton.interactable = false;
        finlaButton.interactable = false;
        qStateButton.interactable = false;
        archButton.interactable = false;
        consumeButton.interactable = false;
    }
    public void enableAllButton()
    {
        startButton.interactable = true;
        finlaButton.interactable = true;
        qStateButton.interactable = true;
        archButton.interactable = true;
        consumeButton.interactable = true;
    }

    public void destroyStart()
    {
        if (startState != null)
        {
            Destroy(startState);
            startButton.interactable = true;
        }
            
    }
    
}
