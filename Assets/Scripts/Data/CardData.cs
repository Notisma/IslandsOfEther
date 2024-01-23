using System;
using System.Runtime.CompilerServices;

namespace Data
{
    public class CardData
    {
        // attributs et fonctions
        public String name;
        public int attack;
        public int hp;

        public CardData(String name, int attack, int hp)
        {
            this.name = name;
            this.attack = attack;
            this.hp = hp;
        }
    }
}