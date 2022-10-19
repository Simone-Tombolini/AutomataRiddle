using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMovement : MonoBehaviour
{
    public float  x;
    public bool inMovemnet = false;
    public float newX;
    public GameObject manager;
    
    void Start()
    {
        x = this.gameObject.transform.position.x;
       
    }

    void Update()
    {
        if (inMovemnet == true )
        {
            //this.transform.position = new Vector2(x - 1 * Time.deltaTime, gameObject.transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(x -1.2f, gameObject.transform.position.y), 10f * Time.deltaTime);
            if (this.gameObject.transform.position.x <= x - 1.19f)
            {
                inMovemnet = false;
                x = this.gameObject.transform.position.x;

            }
        }
        
    }
}
