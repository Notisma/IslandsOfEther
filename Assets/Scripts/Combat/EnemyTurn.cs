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
            List<CardClick> unplacedCards = EnemyBehaviour.GetI().data.GetUnplacedCards();
            int index = rand.Next(0, unplacedCards.Count);
            CardClick carte = unplacedCards[index];
            PlateauBH.Instance.PlaceCardOnPlate(carte, false);
        }

        public static void AttackPlayer(CardClick atking, CardClick playerDef)
        {
            int attack = atking.data.attack;
            playerDef.data.hp -= attack;
        }

        public static CardClick ChooseAtkCard()
        {
            Random rand = new Random();
            List<CardClick> placedCards = EnemyBehaviour.GetI().data.GetPlacedCards();
            int index = rand.Next(0, placedCards.Count);
            CardClick carte = placedCards[index];
            return carte;
        }

        public static CardClick ChooseOppoCard()
        {
            Random rand = new Random();
            List<CardClick> placedCards = PlayerBehaviour.P.data.GetPlacedCards();
            int index = rand.Next(0, placedCards.Count);
            CardClick carte = placedCards[index];
            return carte;
        }
    }
}