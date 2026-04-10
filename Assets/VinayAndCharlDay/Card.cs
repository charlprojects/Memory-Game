using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.UI;
public class Card : MonoBehaviour
{

    public Image CardImage;
    public int cardID;

    public int cardNum;
    private bool isFlipped;
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


        //CardImage.sprite = gameManager.cardFaces[2];
    }

    public void HideCard()
    {

    }
}
