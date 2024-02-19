using Combat.Turns;
using Data;
using UnityEngine;
using static Combat.Layout.Card.CardState;

namespace Combat.Layout
{
    public class AttackButton : MonoBehaviour
    {
        public int attack;
        public CardData enemy;

        private void OnMouseDown()
        {
            Card card = transform.parent.GetComponent<Card>();
            if (card.state is OnArenaSelectableAsAttacker)
            {
                PlayerTurn.currentCard = card;
                PlayerTurn.userActionWasDone = true;
            }
        }
    }
}
