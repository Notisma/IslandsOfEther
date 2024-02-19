using System;

namespace Data
{
    [Serializable]
    public class CardData
    {
        public string codename;
        public string name;
        public int attack;
        public int baseHp;
        public string description;

        public CardData(string codename, string name, int attack, int baseHp, string description)
        {
            this.codename = codename;
            this.name = name;
            this.attack = attack;
            this.baseHp = baseHp;
            this.description = description;
        }
    }
}