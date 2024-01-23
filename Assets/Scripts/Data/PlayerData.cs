using System;
using System.Collections.Generic;

namespace Data
{
    public class PlayerData
    {
        public List<CardData> cards = new List<CardData>();
        public String name;

        public PlayerData(String name)
        {
            this.name = name;
        }

        public void AddCard(CardData c)
        {
            cards.Add(c);
        }
    }
}