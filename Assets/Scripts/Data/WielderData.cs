using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Data
{
    public class WielderData
    {
        private List<Card> cards = new();
        public string name;

        public WielderData(string name)
        {
            this.name = name;
        }

        public Card TEMP_GetFirstCard()
        {
            return cards[0];
        }

        public void AddCard(Card c)
        {
            cards.Add(c);
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