using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardClick : MonoBehaviour
{
    private Color _originalColor;
    private SpriteRenderer _spriteRenderer;
    public Plane dragPlane;
    public Vector3 offset;
    public Camera myMainCamera; 


    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        myMainCamera = Camera.main;
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
        ResetCard();
    }

    public void OnMouseDrag()
    {
        MoveCard();
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

    void MoveCard()
    {
        Ray camRay = myMainCamera.ScreenPointToRay(Input.mousePosition); 

        float planeDist;
        dragPlane.Raycast(camRay, out planeDist);
        transform.position = camRay.GetPoint(planeDist) + offset;
    }
}