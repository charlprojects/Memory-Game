using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class GameManagerCard : MonoBehaviour
{
    public static GameManagerCard Instance;

    public Card cardPrefab;
    public Transform cardHolder;

    public Sprite cardBack;
    public Sprite cardFront;
    public Sprite[] cardFaces;
    public int matchesFound = 0;
    public int failedMatches = 0;
    public Text matchesText;
    public Text goodJob;
    public Button restartButton;
    public float targetTime = 0.0f;
    public Button switchGameButton;
    public Button quitGameButton;

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

    private void Update()
    {
        if (!(matchesFound >= 8))
        {
            targetTime += Time.deltaTime;
            goodJob.gameObject.SetActive(false);
            restartButton.gameObject.SetActive(false);
            switchGameButton.gameObject.SetActive(false);
            
        } else
        {
            goodJob.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            switchGameButton.gameObject.SetActive(true);
        }
            matchesText.text = $@"Time: {Mathf.Ceil(targetTime)}s 
Matches: {matchesFound.ToString()}
Failures:  {failedMatches.ToString()}";
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
        if (matchesFound <= 8)
        {
            if (firstC.cardNum == secondC.cardNum)
            {
                Debug.Log("Match");
                matchesFound++;
                //firstC.gameObject.SetActive(false);
                //secondC.gameObject.SetActive(false);
                //firstC.HideCard();
                //secondC.HideCard();
            }
            else
            {
                Debug.Log("No match");
                failedMatches++;


                firstC.Invoke("HideCard", .25f);
                //secondC.HideCard();
                secondC.Invoke("HideCard", .25f);
            }
        }
    }


    public void RestartGame()
    {
        matchesFound = 0;
        failedMatches = 0;
        targetTime = 0.0f;
        foreach (Card card in cards)
        {
            Destroy(card.gameObject);
        }
        cards.Clear();
        CreateCards();
    }

    public void SwitchGame()
    {
        SceneManager.LoadScene("BlackHoleSolitaire");

    }

    public void QuitGame()
    {
        
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
