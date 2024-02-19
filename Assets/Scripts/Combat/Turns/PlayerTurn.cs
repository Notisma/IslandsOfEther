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
        public static bool userActionWasDone; // on le met à true depuis d'autres classes pour passer à la suite

        public static Card currentCard; // on la change depuis d'autres classes, onClick sur des cartes notamment

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
            yield return null;
            foreach (Card card in GetCardsContainer().GetSelectableAttackCards())
            {
                card.state = OnArenaSelectableAsAttacker;
            }

            userActionWasDone = false;
            do
            {
                yield return null;
            } while (!userActionWasDone);

            foreach (Card card in GetCardsContainer().GetSelectableAttackCards())
            {
                card.state = OnArenaStatic;
            }

            callback(currentCard);
        }

        public override IEnumerator ChooseOppoCard(System.Action<Card> callback)
        {
            yield return null;
            foreach (Card oppoCard in GetOppoContainer().GetSelectablePreyCards())
            {
                oppoCard.state = OnArenaSelectableAsPrey;
            }

            userActionWasDone = false;
            do
            {
                yield return null;
            } while (!userActionWasDone);

            foreach (Card oppoCard in GetOppoContainer().GetSelectablePreyCards())
            {
                oppoCard.state = OnArenaStatic;
            }

            callback(currentCard);
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