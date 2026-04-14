using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.UI;
public class Card : MonoBehaviour
{

    public Image CardImage;
    public int cardID;

    public int cardNum;
    public bool isFlipped;
    public GameManagerCard gameManager;
    public Sprite rend;
    // Start is called before the first frame update
    void Start()
    {
        isFlipped = false;


       //CardImage.sprite = GameManagerCard.Instance.cardBack;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FlipCard()
    {
        isFlipped = true;
        CardImage.sprite = gameManager.cardFaces[cardNum];
        gameManager.CardFlipped(this);
    }

    public void HideCard()
    {
        isFlipped = false;
        CardImage.sprite = gameManager.cardBack;

        //if(gameManager.firstC != null && gameManager.firstC == this)
        //{
        //    gameManager.firstC = null;
        //}
        //if(gameManager.secondC != null && gameManager.secondC == this)
        //{
        //    gameManager.secondC = null;
        //}

    }
}
