using System.Collections.Generic;

namespace Data
{
    public abstract class AbstractData
    {
        public List<CardClick> cards = new List<CardClick>();
        public string name;

        public AbstractData(string name)
        {
            this.name = name;
        }

        public void AddCard(CardClick c)
        {
            cards.Add(c);
        }

        public List<CardClick> GetUnplacedCards()
        {
            List<CardClick> l = new List<CardClick>();
            foreach (CardClick c in cards)
            {
                if (!c.placed)
                {
                    l.Add(c);
                }
            }

            return l;
        }
        
        public List<CardClick> GetPlacedCards()
        {
            List<CardClick> l = new List<CardClick>();
            foreach (CardClick c in cards)
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
            foreach (CardClick c in cards)
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