using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag_And_Drop : MonoBehaviour
{
    public bool active = true;
    float StartX = 0;
    float StartY = 0;
    bool detected = false;
    bool collided = false;
    public bool alreadyOccupied = false;

    public GameObject spawnManager;


    public void Start()
    {
        StartX = transform.position.x;
        StartY = transform.position.y;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collided == false && active == true)
        {
            //if(collision.tag == "Spawn" && spawnManager.GetComponent<SpawnManager>().Occupied == false)
            //{
            //    StartX = 7.5f;
            //    StartY = 2.5f;
            //    spawnManager.GetComponent<SpawnManager>().Occupied = true;
            //}
            //else
            //{
            //    if(spawnManager.GetComponent<SpawnManager>().Occupied == true && collision.tag == "Spawn")
            //    { 
            //        alreadyOccupied = true; 
            //    }

            StartX = transform.position.x;
            StartY = transform.position.y;
            //}

            if (StartY > 3.42f)
            {
                StartY = 3.42f;
            }
            if (StartY < -2.68f)
            {
                StartY = -2.68f;
                print("detected");
            }
            if (StartX < -6.64f)
            {
                print("detected");
                StartX = -6.64f;
            }
            if (StartX > 5.9f && StartY > 3.42f)
            {
                StartX = 7.5f;
                StartY = 2.5f;
            }

            collided = true;
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (active == true)
        {
            collided = true;
        }
            
    } 
    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collided == true)
        {
            collided = false;
    
        }
        //if (alreadyOccupied == false && collision.tag == "Spawn")
        //{ 
        //    spawnManager.GetComponent<SpawnManager>().Occupied = false; 
        //} else
        //{
        //    alreadyOccupied = false;
        //}
        
    }

    public void Update()
    {
        if (active == true)
        {


            if (detected == true && Input.GetMouseButton(0))
            {
                Vector2 MouseTouchPosition = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
                transform.position = MouseTouchPosition;

            }
            if (Input.GetMouseButtonUp(0) == true)
            {
                detected = false;

            }
            if (Input.GetMouseButton(0) == false && collided == true)
            {
                Vector2 Reload = new Vector2(StartX, StartY);
                transform.position = Vector2.MoveTowards(transform.position, Reload, 10f);
            }
        }
    }

    void OnMouseOver()
    {

        if (Input.GetMouseButtonDown(0) && active == true)
        {
            detected = true;
        }

    }

}
