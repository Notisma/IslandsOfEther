using Data;
using System;
using System.Collections.Generic;

public class EnemyData
{
    public string name;
    public List<CardData> cards = new List<CardData>();

    public EnemyData(string name)
    {
        this.name = name;
    }
    
    public void AddCard(CardData c)
    {
        cards.Add(c);
    }
}