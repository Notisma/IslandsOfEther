using Combat.Layout;
using Data;
using Manager;

namespace Combat
{
    public class EnemyBehaviour
    {
        private static EnemyBehaviour INST;

        public CardsContainer cardsContainer;
    
        private EnemyBehaviour()
        {
            cardsContainer = BigManager.I.opponentCardsContainer;
        }

        public WielderData data;

        public static EnemyBehaviour I()
        {
            return INST ??= new EnemyBehaviour();
        }
        
        public void GetNewCard(string codename)
        {
            CardData c = CardsManager.cards[codename];
            data.AddCard(c);
        }
    }
}