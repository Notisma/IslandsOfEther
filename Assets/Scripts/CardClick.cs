using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardClick : MonoBehaviour
{
    private Color _originalColor;
    private SpriteRenderer _spriteRenderer;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void OnMouseDown()
    {
        print("Card Clicked");
        EnlargeCard();
        
    }

    public void OnMouseUp()
    {
        print("Card dropped");
        ResetCard();
    }


    void EnlargeCard()
    {
        transform.localScale *= 1.5f;
        _spriteRenderer.sortingOrder = 1;
    }

    void ResetCard()
    {
        transform.localScale = new Vector3(1, 1, 1);
        _spriteRenderer.sortingOrder = 0;
    }
}
