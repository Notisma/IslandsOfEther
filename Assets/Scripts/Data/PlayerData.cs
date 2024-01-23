using System;
using System.Collections.Generic;

namespace Data
{
    public class PlayerData
    {
        public List<CardData> cards = new List<CardData>();
        public String name;
        public int nbCrystals;

        public PlayerData(String name, int nbCrystals)
        {
            this.name = name;
            this.nbCrystals = nbCrystals;
        }

        public void AddCard(CardData c)
        {
            cards.Add(c);
        }
    }
}