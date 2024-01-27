using System.Collections.Generic;

namespace Data
{
    public class WielderData
    {
        private List<CardData> cards = new();
        public string name;

        public WielderData(string name)
        {
            this.name = name;
        }

        public CardData TEMP_GetFirstCard()
        {
            return cards[0];
        }

        public void AddCard(CardData c)
        {
            cards.Add(c);
        }
    }
}