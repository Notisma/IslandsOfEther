using System.Collections;
using System.Collections.Generic;
using Combat.Layout;
using Data;
using UnityEngine;
using Random = System.Random;

namespace Combat.Turns
{
    public class EnemyTurn : Turn
    {
        public override IEnumerator PlaceCard()
        {
            Random rand = new Random();
            List<Card> unplacedCards = EnemyBehaviour.I().cardsContainer.GetUnplacedCards();
            int index = rand.Next(0, unplacedCards.Count);
            Card carte = unplacedCards[index];
            PlateauBH.Instance.PlaceCardOnPlate(carte, false);
            yield return new WaitForSeconds(2);
        }

        public override IEnumerator ChooseAtkCard(System.Action<Card> callback)
        {
            yield return new WaitForSeconds(2);

            List<Card> placedCards = EnemyBehaviour.I().cardsContainer.GetPlacedCards();

            if (placedCards.Count == 0)
            {
                callback(null);
                yield break;
            }

            Random rand = new Random();
            int index = rand.Next(0, placedCards.Count);
            Card carte = placedCards[index];
            callback(carte);
        }

        public override IEnumerator ChooseOppoCard(System.Action<Card> callback)
        {
            Random rand = new Random();
            List<Card> placedCards = PlayerBehaviour.I.cardsContainer.GetPlacedCards();
            int index = rand.Next(0, placedCards.Count);
            Card carte = placedCards[index];
            yield return new WaitForSeconds(2);
            callback(carte);
        }

        public override string TurnText()
        {
            return "Au tour de l'adversaire.";
        }

        public override WielderData GetWielderData()
        {
            return EnemyBehaviour.I().data;
        }

        public override Turn GetNextTurn()
        {
            return new PlayerTurn();
        }

        public override CardsContainer GetCardsContainer()
        {
            return EnemyBehaviour.I().cardsContainer;
        }
    }
}