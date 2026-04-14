using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerCard : MonoBehaviour
{

    public static GameManagerCard Instance;

    public Card cardPrefab;

    // Start is called before the first frame update
    public int matchesFound;

    public Sprite cardBack;

    public Sprite cardFront;

    public Sprite[] cardFaces;

    public List<Card> cards;

    public List<int> cardNums;

    public Card firstC, secondC;

    public Transform cardHolder;

    // guard while waiting to unflip cards
    private bool busy;

    void Awake()
    {
        // ensure singleton and initialize collections to avoid NREs
        Instance = this;
        if (cards == null) cards = new List<Card>();
        if (cardNums == null) cardNums = new List<int>();
    }

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
        // ensure cardNums is empty before populating
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
            newCard.CardImage.sprite = cardBack;
            cards.Add(newCard);
        }


    }


    public void CardFlipped(Card flippedCard)
    {
        // ignore input while waiting for non-matching cards to flip back
        if (busy) return;

        // ignore if the card is already one of the selected ones
        if (flippedCard == firstC) return;

        // If no first card selected, set it and return
        if (firstC == null)
        {
            firstC = flippedCard;
            return;
        }

        // If first exists and second not selected, set second and evaluate
        if (secondC == null)
        {
            secondC = flippedCard;

            // If they match: keep them face-up and clear selections
            if (firstC.cardNum == secondC.cardNum)
            {
                matchesFound++;
                // Optionally disable interaction on matched cards so they can't be clicked again:
                firstC.enabled = false;
                secondC.enabled = false;

                firstC = null;
                secondC = null;
            }
            else
            {
                // Not a match — start coroutine to flip them back after a short delay
                busy = true;
                StartCoroutine(UnflipCardsRoutine());
            }

            return;
        }

        // If both were already set for some reason, clear them (safety)
        firstC = flippedCard;
        secondC = null;
    }

    private IEnumerator UnflipCardsRoutine()
    {
        // delay so player can see the second card
        yield return new WaitForSeconds(1.0f);

        if (firstC != null) firstC.HideCard();
        if (secondC != null) secondC.HideCard();

        firstC = null;
        secondC = null;
        busy = false;
    }

    void MaybeMatch()
    {

        // kept for compatibility if you want to move matching logic here
    }

}