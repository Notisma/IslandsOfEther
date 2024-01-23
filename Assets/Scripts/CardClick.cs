using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardClick : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    public Plane dragPlane;
    public Vector3 offset;
    public Camera myMainCamera;
    public Vector3 initialPos;
    public Vector3[] placedPos;
    public bool[] placed;


    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        myMainCamera = Camera.main;
        initialPos = transform.position;
        placed = new bool[3];   
        placedPos = new Vector3[3];
        placedPos[0] = new Vector3((float)-3.1, (float)-0.2, 0);
        placedPos[1] = new Vector3((float)-2.95, (float)-0.2, 0);
        placedPos[2] = new Vector3((float)-2.8, (float)-0.2, 0);
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
        transform.localScale = new Vector3((float)2.5, (float)2.5, (float)2.5);
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
        if (placed[0] == false || placed[1] == false || placed[2] == false)
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
        if (placed[0] == false)
        {
            transform.position = placedPos[0];
            placed[0] = true;
        }
        else if (placed[1] == false)
        {
            transform.position = placedPos[1];
            placed[1] = true;
        }
        else if (placed[2] == false)
        {
            transform.position = placedPos[2];
            placed[2] = true;
        }
    }
}