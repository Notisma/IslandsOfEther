using System.Collections.Generic;
using Data;
using Manager;
using Unity.VisualScripting;
using UnityEngine;
using static Combat.Layout.Card.CardState;

namespace Combat.Layout
{
    public class CardsContainer : MonoBehaviour
    {
        public Transform childCardGameObjects;
        
        public void CreateCardObjects(List<CardData> cardsData, bool allied)
        {
            foreach (CardData cardData in cardsData)
            {
                Card newCard = Instantiate(BigManager.I.prefabCardExample, childCardGameObjects).GetComponent<Card>();
                newCard.data = cardData;
                newCard.allied = allied;
            }
        }

        public void OrderDeck()
        {
            for (int i = 0; i < childCardGameObjects.childCount; i++)
            {
                Transform child = childCardGameObjects.GetChild(i);
                Vector3 childPos = child.position;
                child.position = new Vector3(childPos.x + i * 3, childPos.y, childPos.z);
            }
        }

        public void PlaceCardOnPlate(Card card)
        {
            float y = transform.Find("ArenaContainer").position.y;

            Transform cardTransf = card.transform;
            cardTransf.position = new Vector3(cardTransf.position.x, y, 0);
            card.state = OnArenaStatic;
        }

        public List<Card> GetDeckedCards()
        {
            List<Card> l = new List<Card>();
            foreach (Transform ch in childCardGameObjects)
            {
                Card c = ch.GetComponent<Card>();
                if (c.state is InDeckStatic or InDeckSelectable)
                    l.Add(c);
            }

            return l;
        }

        public int GetNbDeckedCards()
        {
            return GetDeckedCards().Count;
        }

        public List<Card> GetPlacedCards()
        {
            List<Card> l = new List<Card>();
            foreach (Transform ch in childCardGameObjects)
            {
                Card c = ch.GetComponent<Card>();
                if (c.state is OnArenaStatic or OnArenaSelectableAsAttacker or OnArenaSelectableAsPrey)
                    l.Add(c);
            }

            return l;
        }

        public int GetNbPlacedCards()
        {
            return GetPlacedCards().Count;
        }
    }
}