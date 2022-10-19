using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpawner : MonoBehaviour
{
    public GameObject[] cardArray;
    public float startX, startY;

    private void Start()
    {
        spawnCards(startX, startY);
    }
    public void spawnCards(float x, float y)
    {
        
        for (int i = 0; i < cardArray.Length; i++)
        {
            Instantiate(cardArray[i], new Vector2(x, y), Quaternion.identity);
            x = x + 1.2f;
        }
    }


}
