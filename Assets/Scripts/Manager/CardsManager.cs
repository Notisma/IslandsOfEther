using System;
using System.Collections.Generic;
using System.Linq;
using Data;

public static class CardsManager
{
    public static Dictionary<String, CardData> cards;

    static CardsManager() {
        cards = new Dictionary<string, CardData>();
        cards.Add("Ange", new CardData("Ange", 6,  45));
    }

    public static CardData GetRandomCard()
    {
        Random rand = new Random();
        return cards.ElementAt(rand.Next(0, cards.Count)).Value;
    }
}