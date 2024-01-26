using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Data;
using Unity.VisualScripting.FullSerializer;
using Random = System.Random;

namespace Combat
{
    public static class EnemyTurn
    {
        public static void PlaceCard()
        {
            Random rand = new Random();
            List<Card> unplacedCards = EnemyBehaviour.GetI().data.GetUnplacedCards();
            int index = rand.Next(0, unplacedCards.Count);
            Card carte = unplacedCards[index];
            PlateauBH.Instance.PlaceCardOnPlate(carte, false);
        }

        public static void AttackPlayer(Card atking, Card playerDef)
        {
            int attack = atking.data.attack;
            playerDef.data.hp -= attack;
        }

        public static Card ChooseAtkCard()
        {
            Random rand = new Random();
            List<Card> placedCards = EnemyBehaviour.GetI().data.GetPlacedCards();
            int index = rand.Next(0, placedCards.Count);
            Card carte = placedCards[index];
            return carte;
        }

        public static Card ChooseOppoCard()
        {
            Random rand = new Random();
            List<Card> placedCards = PlayerBehaviour.P.data.GetPlacedCards();
            int index = rand.Next(0, placedCards.Count);
            Card carte = placedCards[index];
            return carte;
        }
    }
}