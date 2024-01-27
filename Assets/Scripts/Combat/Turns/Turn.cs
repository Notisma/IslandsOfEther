using Data;

namespace Combat.Turns
{
    public abstract class Turn
    {
        public abstract void PlaceCard();
        public abstract Card ChooseAtkCard();
        public abstract Card ChooseOppoCard();
        public abstract string TurnText();
        public abstract WielderData GetWielderData();
        public abstract Turn GetNextTurn();

        public void Attack(Card attacking, Card defending)
        {
            int attackPower = attacking.data.attack;
            defending.data.hp -= attackPower;
        }

    }
}