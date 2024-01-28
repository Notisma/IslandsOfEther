using System.Collections;
using Combat.Layout;
using Data;
using Manager;
using UnityEngine;
using static Combat.Layout.Card.CardState;

namespace Combat.Turns
{
    public class PlayerTurn : Turn
    {
        public static bool userActionWasDone;

        public override IEnumerator PlaceCard()
        {
            yield return null;
            foreach (Card card in GetCardsContainer().GetDeckedCards())
            {
                card.state = InDeckSelectable;
            }

            userActionWasDone = false;
            do
            {
                yield return null;
            } while (!userActionWasDone); // waits for Card script to change bool

            foreach (Card card in GetCardsContainer().GetDeckedCards())
            {
                card.state = InDeckStatic;
            }
        }

        public override IEnumerator ChooseAtkCard(System.Action<Card> callback)
        {
            /*Random rand = new Random();
            List<Card> placedCards = PlayerBehaviour.I.data.GetPlacedCards();
            int index = rand.Next(0, placedCards.Count);
            Card carte = placedCards[index];
            return carte;*/
            yield return new WaitForSeconds(2);
            callback(null);
        }

        public override IEnumerator ChooseOppoCard(System.Action<Card> callback)
        {
            /*Random rand = new Random();
            List<Card> placedCards = EnemyBehaviour.I().data.GetPlacedCards();
            int index = rand.Next(0, placedCards.Count);
            Card carte = placedCards[index];
            return carte;*/
            yield return new WaitForSeconds(2);
            callback(null);
        }

        public override string ToString()
        {
            return "joueur";
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

        public override CardsContainer GetCardsContainer()
        {
            return BigManager.I.alliedCardsContainer;
        }
    }
}