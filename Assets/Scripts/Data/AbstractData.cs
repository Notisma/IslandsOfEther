using System.Collections.Generic;

namespace Data
{
    public abstract class AbstractData
    {
        public List<Card> cards = new List<Card>();
        public string name;

        public AbstractData(string name)
        {
            this.name = name;
        }

        public void AddCard(Card c)
        {
            cards.Add(c);
        }

        public List<Card> GetUnplacedCards()
        {
            List<Card> l = new List<Card>();
            foreach (Card c in cards)
            {
                if (!c.placed)
                {
                    l.Add(c);
                }
            }

            return l;
        }
        
        public List<Card> GetPlacedCards()
        {
            List<Card> l = new List<Card>();
            foreach (Card c in cards)
            {
                if (c.placed)
                {
                    l.Add(c);
                }
            }

            return l;
        }

        public int getNbPlacedCards()
        {
            int nb = 0;
            foreach (Card c in cards)
            {
                if (c.placed)
                {
                    nb++;
                }
            }

            return nb;
        }
    }
}