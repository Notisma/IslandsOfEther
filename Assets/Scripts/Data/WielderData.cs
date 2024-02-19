using System.Collections.Generic;

namespace Data
{
    public class WielderData
    {
        public List<CardInstData> cards = new();
        public string name;

        public WielderData(string name)
        {
            this.name = name;
        }

        public void AddCard(CardInstData c)
        {
            cards.Add(c);
        }
    }
}