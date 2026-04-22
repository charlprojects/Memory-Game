using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public int cardNum;
    private bool isFlipped;
    public GameManagerCard gameManager;
    public Sprite rend;
    public Image CardImage;


    void Start()
    {
        isFlipped = false;
        if (CardImage == null)
            CardImage = GetComponent<Image>();
    }


    void Update()
    {

    }

    public void FlipCard()
    {

        //if (isFlipped)
        //    return;
        if (!isFlipped)
        {
            isFlipped = true;

            CardImage.sprite = gameManager.cardFaces[cardNum];
            gameManager.CardFlipped(this);
        }
        

    }

    public void HideCard()
    {
        isFlipped = false;
        CardImage.sprite = gameManager.cardBack;
    }
}