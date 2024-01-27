using System.Collections.Generic;

namespace Data
{
    public class WielderData
    {
        public List<CardData> cards = new();
        public string name;

        public WielderData(string name)
        {
            this.name = name;
        }

        public void AddCard(CardData c)
        {
            cards.Add(c);
        }
    }
}