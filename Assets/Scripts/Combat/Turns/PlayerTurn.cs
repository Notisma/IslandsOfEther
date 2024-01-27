using System.Collections.Generic;
using Data;
using Manager;
using Random = System.Random;

namespace Combat.Turns
{
    public class PlayerTurn : Turn
    {
        public override void PlaceCard()
        {
            BigManager.I.canDragAndDrop = true;
        }
        
        public override Card ChooseAtkCard()
        {
            /*Random rand = new Random();
            List<Card> placedCards = PlayerBehaviour.I.data.GetPlacedCards();
            int index = rand.Next(0, placedCards.Count);
            Card carte = placedCards[index];
            return carte;*/
            return null;
        }

        public override Card ChooseOppoCard()
        {
            /*Random rand = new Random();
            List<Card> placedCards = EnemyBehaviour.I().data.GetPlacedCards();
            int index = rand.Next(0, placedCards.Count);
            Card carte = placedCards[index];
            return carte;*/
            return null;
        }

        public override string TurnText()
        {
            return "À vous de jouer !";
        }

        public override WielderData GetWielderData()
        {
            return PlayerBehaviour.I.data;
        }

        public override Turn GetNextTurn()
        {
            return new EnemyTurn();
        }
    }
}