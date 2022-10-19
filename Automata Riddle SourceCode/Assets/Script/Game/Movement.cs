using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject manager;
    public bool inMovement=false;
    public float x, y;
    float speed = 5f;
    public float[,] movementList = new float[1000, 2];
    public int counter = 0;
    int effettiveCounter = 0;
    int destroyer = -1;
    bool inDestroing = false;
    public bool victory;
    public bool victoryBl = false;
    public GameObject destroyaudio;
  
    private void Start()
    {
        effettiveCounter = counter;
        x=this.transform.position.x;
        y=this.transform.position.y;
    }
    void FixedUpdate()
    {
     
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(x,y), speed * Time.deltaTime);
       
        if(transform.position.x == x && transform.position.y == y)
        {
       
            if (counter == destroyer)
            {

                if (victoryBl == false)
                {
                    manager.GetComponent<Manager>().endParsing(this.victory);
                }
                else
                {
                    manager.GetComponent<Manager>().endParsingBlack();
                }
            
                
                Destroy(this.gameObject);
                inDestroing = true;
            }
            if (manager.GetComponent<Manager>().noDestroy[counter] == false && inDestroing == false && manager.GetComponent<Manager>().consumableCardIstance[effettiveCounter] != null)
            {
                destroyaudio.GetComponent<ReproduceSoundEffect>().ReproduceSound();
                Destroy(manager.GetComponent<Manager>().consumableCardIstance[effettiveCounter].gameObject);
            }
            if (inDestroing == false)
            {
                applymovement(movementList[counter, 0], movementList[counter, 1]);
                if(manager.GetComponent<Manager>().noDestroy[counter] == false)
                {
                    effettiveCounter++;
                }
                counter++;
            }



        }
  
    }
     public void startMovement(int destroyer)
    {
        this.destroyer = destroyer;
        applymovement(movementList[counter, 0], movementList[counter, 1]);
   
    }
    public void applymovement(float x, float y)
    {
        this.x = x;
        this.y = y;
        if (inDestroing == false && manager.GetComponent<Manager>().noDestroy[counter] == false)
        {
            for (int i = 0; i < 100; i++)
            {
                if (manager.GetComponent<Manager>().consumableCardIstance[i] != null)
                {
                    manager.GetComponent<Manager>().consumableCardIstance[i].GetComponent<CardMovement>().inMovemnet = true;
                }
            }
        }


    }
}
