using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardContainer : MonoBehaviour
{
    private void Start()
    {
        OrderDeck();
    }

    public void OrderDeck()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            child.position = new Vector3(child.position.x + i * 3, child.position.y, child.position.z);
        }
    }
}
