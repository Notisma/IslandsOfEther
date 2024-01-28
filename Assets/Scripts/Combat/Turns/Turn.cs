using System.Collections;
using Combat.Layout;
using Data;

namespace Combat.Turns
{
    public abstract class Turn
    {
        public abstract IEnumerator PlaceCard();
        public abstract IEnumerator ChooseAtkCard(System.Action<Card> callback);
        public abstract IEnumerator ChooseOppoCard(System.Action<Card> callback);

        public abstract override string ToString();
        public abstract string TurnText();
        public abstract WielderData GetWielderData();
        public abstract Turn GetNextTurn();
        public abstract CardsContainer GetCardsContainer();

        public void Attack(Card attacking, Card defending)
        {
            int attackPower = attacking.data.attack;
            defending.data.hp -= attackPower;
        }
    }
}