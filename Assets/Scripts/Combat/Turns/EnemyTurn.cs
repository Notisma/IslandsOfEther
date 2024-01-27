using System.Collections.Generic;
using Data;
using Random = System.Random;

namespace Combat.Turns
{
    public class EnemyTurn : Turn
    {
        public override void PlaceCard()
        {
            Random rand = new Random();
            List<Card> unplacedCards = EnemyBehaviour.I().data.GetUnplacedCards();
            int index = rand.Next(0, unplacedCards.Count);
            Card carte = unplacedCards[index];
            PlateauBH.Instance.PlaceCardOnPlate(carte, false);
        }

        public override Card ChooseAtkCard()
        {
            Random rand = new Random();
            List<Card> placedCards = EnemyBehaviour.I().data.GetPlacedCards();
            int index = rand.Next(0, placedCards.Count);
            Card carte = placedCards[index];
            return carte;
        }

        public override Card ChooseOppoCard()
        {
            Random rand = new Random();
            List<Card> placedCards = PlayerBehaviour.I.data.GetPlacedCards();
            int index = rand.Next(0, placedCards.Count);
            Card carte = placedCards[index];
            return carte;
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
    }
}