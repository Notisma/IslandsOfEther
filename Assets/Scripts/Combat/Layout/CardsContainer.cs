using System.Collections.Generic;
using UnityEngine;

namespace Combat.Layout
{
    public class CardsContainer : MonoBehaviour
    {
        public List<Card> cards;
        
        private void Start()
        {
            OrderDeck();
        }

        public void CreateVisuals()
        {
            /*Object newCard = Instantiate(BigManager.I.prefabCardExample, opponentCardsContainer.transform);
            Card clik = newCard.GetComponent<Card>();
            clik.data = CardsManager.cards[codename];
            data.AddCard(clik);*/
        }

        public void OrderDeck()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                child.position = new Vector3(child.position.x + i * 3, child.position.y, child.position.z);
            }
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
