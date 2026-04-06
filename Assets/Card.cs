using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteChanger : MonoBehaviour
{
   // [SerializeField] private Sprite[] cardSprites;
   // [SerializeField] private Image cardFront;

    private SpriteRenderer rend;
    [SerializeField]private Sprite cardSpriteBack;

    
    // Start is called before the first frame updat
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        cardSpriteBack = Resources.Load<Sprite>("Assets/MemoryCards/Back.png");
        //cardSpriteFront = Resources.Load<Sprite>("")
        rend.sprite = cardSpriteBack;
        GetComponent<Image>().sprite = cardSpriteBack;
    }

    public void ChangeSprite()
    {
       // if()
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
