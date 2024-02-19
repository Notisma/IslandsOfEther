using Data;
using Manager;

namespace Combat
{
    public class EnemyBehaviour
    {
        private static EnemyBehaviour INST;

        private EnemyBehaviour()
        {
        }

        public WielderData data;

        public static EnemyBehaviour I()
        {
            return INST ??= new EnemyBehaviour();
        }

        public void GetNewCard(string codename)
        {
            CardInstData c = new CardInstData(CardsManager.cards[codename]);
            data.AddCard(c);
        }
    }
}