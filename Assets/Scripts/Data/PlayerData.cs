using System;
using System.Collections.Generic;

namespace Data
{
    public class PlayerData
    {
        public List<CardData> cards = new List<CardData>();
        public string name;

        public PlayerData(string name)
        {
            this.name = name;
        }

        public void AddCard(CardData c)
        {
            cards.Add(c);
        }
    }
}