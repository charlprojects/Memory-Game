using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerCard : MonoBehaviour
{

    public static GameManagerCard Instance;

    public Card cardPrefab;

    // Start is called before the first frame update

    public Sprite cardBack;

    public Sprite cardFront;

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
    void Shuffle<T>(List<T> inputList)
    {
        for (int i = 0; i < inputList.Count; i++)
        {
            T temp = inputList[i];
            int randomIndex = Random.Range(i, inputList.Count);
            inputList[i] = inputList[randomIndex];
            inputList[randomIndex] = temp;
        }
    }

    void CreateCards()
    {
        for (int i = 0; i < cardFaces.Length; i++)
        {
            cardNums.Add(i);
            cardNums.Add(i);
        }
        Shuffle(cardNums);
        foreach (int cardNum in cardNums)
        {
            Card newCard = Instantiate(cardPrefab,cardHolder);
            newCard.gameManager = this;
            newCard.cardNum = cardNum;
            newCard.CardImage.sprite = cardBack;
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
