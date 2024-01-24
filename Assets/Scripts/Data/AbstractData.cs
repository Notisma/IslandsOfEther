using System.Collections.Generic;

namespace Data
{
    public abstract class AbstractData
    {
        public List<CardData> cards = new List<CardData>();
        public string name;
        public bool canPlay;

        public AbstractData(string name)
        {
            this.name = name;
        }
        public void AddCard(CardData c)
        {
            cards.Add(c);
        }

        public int getNbPlacedCards()
        {
            int nb = 0;
            foreach (CardData c in cards)
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