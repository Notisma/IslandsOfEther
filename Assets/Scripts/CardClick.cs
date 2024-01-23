using System;
using System.Collections;
using System.Collections.Generic;
using Data;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardClick : MonoBehaviour
{
    public CardData card;
    private SpriteRenderer _spriteRenderer;
    public Plane dragPlane;
    public Vector3 offset;
    public Camera myMainCamera;
    public Vector3 initialPos;
    public bool placed;


    void Start()
    {
        card = PlayerBehaviour.P.data.cards[0];
        _spriteRenderer = GetComponent<SpriteRenderer>();
        myMainCamera = Camera.main;
        initialPos = transform.position;
    }

    public void OnMouseDown()
    {
        print("Card Clicked");
        EnlargeCard();
        dragPlane = new Plane(myMainCamera.transform.forward, transform.position);
        Ray camRay = myMainCamera.ScreenPointToRay(Input.mousePosition);

        float planeDist;
        dragPlane.Raycast(camRay, out planeDist);
        offset = transform.position - camRay.GetPoint(planeDist);
    }

    public void OnMouseUp()
    {
        print("Card dropped");
        transform.localScale = new Vector3((float)0.45, (float)0.45, (float)0.45);
        if (transform.parent.GetComponent<CardContainer>().cardArena.GetComponent<BoxCollider2D>().bounds
            .Contains(transform.position))
        {
            PlaceCard();
        }
        else
        {
            ResetCard();
        }
    }

    public void OnMouseDrag()
    {
        if (transform.parent.GetComponent<CardContainer>().placed[0] == false ||
            transform.parent.GetComponent<CardContainer>().placed[1] == false ||
            transform.parent.GetComponent<CardContainer>().placed[2] == false)
        {
            MoveCard();
        }
    }


    void EnlargeCard()
    {
        transform.localScale *= 1.5f;
        _spriteRenderer.sortingOrder = 1;
    }

    void ResetCard()
    {
        _spriteRenderer.sortingOrder = 0;
        transform.position = initialPos;
    }

    void MoveCard()
    {
        Ray camRay = myMainCamera.ScreenPointToRay(Input.mousePosition);

        float planeDist;
        dragPlane.Raycast(camRay, out planeDist);
        transform.position = camRay.GetPoint(planeDist) + offset;
    }

    void PlaceCard()
    {
        if (transform.parent.GetComponent<CardContainer>().placed[0] == false)
        {
            transform.position = transform.parent.GetComponent<CardContainer>().placedPos[0];
            transform.parent.GetComponent<CardContainer>().placed[0] = true;
            placed = true;
            transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (transform.parent.GetComponent<CardContainer>().placed[1] == false)
        {
            transform.position = transform.parent.GetComponent<CardContainer>().placedPos[1];
            transform.parent.GetComponent<CardContainer>().placed[1] = true;
            placed = true;
            transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (transform.parent.GetComponent<CardContainer>().placed[2] == false)
        {
            transform.position = transform.parent.GetComponent<CardContainer>().placedPos[2];
            transform.parent.GetComponent<CardContainer>().placed[2] = true;
            placed = true;
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}