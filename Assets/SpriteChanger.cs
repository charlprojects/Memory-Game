using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChanger : MonoBehaviour
{
    public Sprite cardSprite;
    Sprite newSprite;
    // Start is called before the first frame updat
    void Start()
    {
        newSprite = cardSprite;

        gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
