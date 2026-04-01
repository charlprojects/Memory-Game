using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class cardspawner : MonoBehaviour
{

    public GameObject Card;
    public int rows = 4;
    public int cols = 4;
    public Vector3[,] cardGrid;
    // Start is called sbefore the first frame update
    void Start()
    {
        cardGrid = new Vector3[rows, cols];
        reset();
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Instantiate(Card, cardGrid[i,j], transform.rotation);

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void reset()
    {
        int originalX = 0;
        int originalY = 0;

        int width = 180;
        int height = 166;
        int gap = 20;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                int x = originalX + width * i + gap;
                int y = originalY + height * j + gap;
                Debug.Log("---\n");
                Debug.Log(x.ToString() + ", " + y.ToString());
                cardGrid[i,j] = new Vector3(x, y);
            }
        }
    }
}
