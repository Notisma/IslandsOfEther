using System.Collections.Generic;
using Data;
using Manager;
using Unity.VisualScripting;
using UnityEngine;

namespace Combat.Layout
{
    public class CardsContainer : MonoBehaviour
    {
        public List<Card> cards;

        public void CreateCardObjects(List<CardData> cardsData, bool allied)
        {
            foreach (CardData cardData in cardsData)
            {
                Card newCard = Instantiate(BigManager.I.prefabCardExample, transform).GetComponent<Card>();
                newCard.data = cardData;
                newCard.allied = allied;
                cards.Add(newCard);
            }
        }

        public void OrderDeck()
        {
            for (int i = 0; i < cards.Count; i++)
            {
                Transform child = cards[i].transform;
                Vector3 childPos = child.position;
                child.position = new Vector3(childPos.x + i * 3, childPos.y, childPos.z);
            }
        }

        public void PlaceCardOnPlate(Card card)
        {
            float y = transform.Find("ArenaContainer").position.y;

            Transform cardTransf = card.transform;
            cardTransf.position = new Vector3(cardTransf.position.x, y, 0);
            card.placed = true;
        }

        public List<Card> GetUnplacedCards()
        {
            List<Card> l = new List<Card>();
            foreach (Card c in cards)
                if (!c.placed)
                    l.Add(c);
            return l;
        }

        public int GetNbUnplacedCards()
        {
            return GetUnplacedCards().Count;
        }

        public List<Card> GetPlacedCards()
        {
            List<Card> l = new List<Card>();
            foreach (Card c in cards)
                if (c.placed)
                    l.Add(c);
            return l;
        }

        public int GetNbPlacedCards()
        {
            return GetPlacedCards().Count;
        }
    }
}