using System;
using System.Collections;
using System.Collections.Generic;
using Combat;
using Data;
using Manager;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class Card : MonoBehaviour
{
    [FormerlySerializedAs("card")] public CardData data;
    private SpriteRenderer _spriteRenderer;
    public Plane dragPlane;
    public Vector3 offset;
    public Camera myMainCamera;
    public Vector3 initialPos;

    public bool placed;
    

    public Card(CardData data)
    {
        this.data = data;
    }

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        myMainCamera = Camera.main;

        data = PlayerBehaviour.I.data.TEMP_GetFirstCard().data;
        initialPos = transform.position;
    }

    public void OnMouseDown()
    {
        if (!BigManager.I.canDragAndDrop)
        {
            return;
        }
        EnlargeCard();
        dragPlane = new Plane(myMainCamera.transform.forward, transform.position);
        Ray camRay = myMainCamera.ScreenPointToRay(Input.mousePosition);

        float planeDist;
        dragPlane.Raycast(camRay, out planeDist);
        offset = transform.position - camRay.GetPoint(planeDist);
    }

    public void OnMouseUp()
    {
        if (!BigManager.I.canDragAndDrop)
        {
            return;
        }
        transform.localScale = new Vector3((float)0.45, (float)0.45, (float)0.45);
        GameObject cardArena = GameObject.FindGameObjectWithTag("Plateau");
        if (cardArena.GetComponent<BoxCollider2D>().bounds
            .Contains(transform.position))
        {
            PlaceCard();
            BigManager.I.canDragAndDrop = false;
        }
        else
        {
            ResetCard();
        }
    }

    public void OnMouseDrag()
    {
        if (!BigManager.I.canDragAndDrop)
        {
            return;
        }
        if (PlayerBehaviour.I.data.GetNbPlacedCards() < 3)
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
        PlateauBH.Instance.PlaceCardOnPlate(this, true);

        PlayerBehaviour.I.childCards.OrderDeck();
        //BattleManager.inPlayerTurn = false;
    }
}