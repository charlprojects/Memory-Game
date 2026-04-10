using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class cardspawner : MonoBehaviour
{
    //[SerializeField] public Sprite[] cardsList;
    //public Canvas canvas;
    //public int cardsX;
    //public int cardsY;
    //public GameObject Card;
    //public int rows = 4;
    //public int cols = 4;
    //public Vector2[,] cardGrid;
    // Start is called sbefore the first frame update
    void Start()
    {
        //cardGrid = new Vector2[rows, cols];
        //reset();
        //for (int i = 0; i < rows; i++)
        //{
        //    for (int j = 0; j < cols; j++)
        //    {

        //        GameObject cardInstance = Instantiate(Card, cardGrid[i,j], transform.rotation);
        //        cardInstance.transform.SetParent(canvas.transform);

        //       // Image guiImage = cardInstance.AddComponent<Image>();

        //        // 3. Assign the Sprite asset
        //        //guiImage.sprite = Resources.Load<Sprite>("Assets/Memory Game Cards/Memory_Game_Circle.png");
        //    }
        //}
        //Debug.Log(cardsList[0]);
    }

    // Update is called once per frame
    void Update()
    {
       // reset();
    }

    public void reset()
    {
        //int originalX = 150;
       // int originalY = 0;

        //int width = 180;
        //int height = 185;
        //int gap = 20;
        //for (int i = 0; i < rows; i++)
        //{
        //    for (int j = 0; j < cols; j++)
        //    {
        //        int x = cardsX + width * i + gap;
        //        int y = cardsY + height * j + gap;
        //        //Debug.Log("---\n");
        //        //Debug.Log(x.ToString() + ", " + y.ToString());
        //        cardGrid[i,j] = new Vector2(x, y);
        //    }
        //}
    }
}
