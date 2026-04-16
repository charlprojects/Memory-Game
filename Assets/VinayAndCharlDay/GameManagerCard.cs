using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerCard : MonoBehaviour
{
    public static GameManagerCard Instance;

    public Card cardPrefab;
    public Transform cardHolder;

    public Sprite cardBack;
    public Sprite cardFront;
    public Sprite[] cardFaces;

    public List<Card> cards = new List<Card>();

    private List<int> cardNums = new List<int>();
    private Card firstC;
    private Card secondC;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        CreateCards();
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
        cardNums.Clear();

        for (int i = 0; i < cardFaces.Length; i++)
        {
            cardNums.Add(i);
            cardNums.Add(i);
        }

        Shuffle(cardNums);

        foreach (int cardNum in cardNums)
        {
            Card newCard = Instantiate(cardPrefab, cardHolder);
            newCard.gameManager = this;
            newCard.cardNum = cardNum;
            if (newCard.CardImage != null)
                newCard.CardImage.sprite = cardBack;
            cards.Add(newCard);
        }
    }

    public void CardFlipped(Card flippedCard)
    {
        if (firstC == null)
        {
            firstC = flippedCard;
            secondC = null;
            Debug.Log("Card Flipped (first)");
            return;
        }
        else if (secondC == null && flippedCard != firstC)
        {
            secondC = flippedCard;
            Debug.Log("Card Flipped (second)");
            MaybeMatch();

            firstC = null;
            secondC = null;
        }
    }

    void MaybeMatch()
    {
        if (firstC == null || secondC == null)
            return;

        if (firstC.cardNum == secondC.cardNum)
        {
            Debug.Log("Match");
            //firstC.gameObject.SetActive(false);
            //secondC.gameObject.SetActive(false);
            //firstC.HideCard();
            //secondC.HideCard();
        }
        else
        {
            Debug.Log("No match");


            firstC.HideCard();
            secondC.HideCard();
        }
    }
}
