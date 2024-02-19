using System;

namespace Data
{
    [Serializable]
    public class CardInstData
    {
        public CardData baseData;
        public int hp;

        public CardInstData(CardData baseData)
        {
            this.baseData = baseData;
            hp = this.baseData.baseHp;
        }
    }
}