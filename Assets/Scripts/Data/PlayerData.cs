using System.Collections.Generic;

namespace Data
{
    public class PlayerData
    {
        public List<CardData> cards = new List<CardData>();

        public void AddCard(CardData c)
        {
            cards.Add(c);
        }
    }
}