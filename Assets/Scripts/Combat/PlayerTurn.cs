using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Data;
using Manager;
using Random = System.Random;

namespace Combat
{
    public static class PlayerTurn
    {
        public static void PlaceCard()
        {
            BigManager.canDragAndDrop = true;
        }

        public static void AttackEnemy(CardClick atking, CardClick enemyDef)
        {
            int attack = atking.data.attack;
            enemyDef.data.hp -= attack;
        }

        public static CardClick ChooseAtkCard()
        {
            Random rand = new Random();
            List<CardClick> placedCards = PlayerBehaviour.P.data.GetPlacedCards();
            int index = rand.Next(0, placedCards.Count);
            CardClick carte = placedCards[index];
            return carte;
        }

        public static CardClick ChooseOppoCard()
        {
            Random rand = new Random();
            List<CardClick> placedCards = EnemyBehaviour.GetI().data.GetPlacedCards();
            int index = rand.Next(0, placedCards.Count);
            CardClick carte = placedCards[index];
            return carte;
        }
    }
}