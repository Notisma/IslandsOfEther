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
            BigManager.I.canDragAndDrop = true;
        }

        public static void AttackEnemy(Card atking, Card enemyDef)
        {
            int attack = atking.data.attack;
            enemyDef.data.hp -= attack;
        }

        public static Card ChooseAtkCard()
        {
            Random rand = new Random();
            List<Card> placedCards = PlayerBehaviour.P.data.GetPlacedCards();
            int index = rand.Next(0, placedCards.Count);
            Card carte = placedCards[index];
            return carte;
        }

        public static Card ChooseOppoCard()
        {
            Random rand = new Random();
            List<Card> placedCards = EnemyBehaviour.GetI().data.GetPlacedCards();
            int index = rand.Next(0, placedCards.Count);
            Card carte = placedCards[index];
            return carte;
        }
    }
}