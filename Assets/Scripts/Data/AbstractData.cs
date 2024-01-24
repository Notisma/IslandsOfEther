using System.Collections.Generic;

namespace Data
{
    public abstract class AbstractData
    {
        public List<CardClick> cards = new List<CardClick>();
        public string name;
        public bool canPlay;

        public AbstractData(string name)
        {
            this.name = name;
        }
        public void AddCard(CardClick c)
        {
            cards.Add(c);
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