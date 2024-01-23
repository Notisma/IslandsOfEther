using System;
using System.Collections;
using System.Collections.Generic;
using Data;
using UnityEngine;

public class AttackButton : MonoBehaviour
{
    public int attack;
    public CardData enemy;

    private void OnMouseDown()
    {
        attack = transform.parent.GetComponent<CardClick>().card.attack;
        enemy.hp -= attack;
    }
}
