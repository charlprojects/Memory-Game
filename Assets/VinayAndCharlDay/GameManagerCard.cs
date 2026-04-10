using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerCard : MonoBehaviour
{

    public static GameManagerCard Instance;

    public Card cardPrefab;

    // Start is called before the first frame update

    public Sprite cardBack;

    public Sprite[] cardFaces;

    public List<Card> cards;

    public List<int> cardNums;

    public Card firstC, secondC;

    public Transform cardHolder;
    
    void Start()
    {
        cards = new List<Card>();
        CreateCards();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateCards()
    {
        for (int i = 0; i < cardFaces.Length; i++)
        {
            cardNums.Add(i);
            cardNums.Add(i);
        }

        foreach (int cardNum in cardNums)
        {
            Card newCard = Instantiate(cardPrefab,cardHolder);
            newCard.gameManager = this;
            newCard.cardNum = cardNum;
            cards.Add(newCard);
        }


    }


    public void CardFlipped(Card flippedCard)
    {
        if (firstC == null)
        {
            firstC = flippedCard;
        }
        else if (secondC == null)
        {
            secondC = flippedCard;
            MaybeMatch();
        }

    }

    void MaybeMatch()
    {
    }

}
