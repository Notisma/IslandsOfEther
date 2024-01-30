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
            if (transform.parent.GetComponent<Card>().state is OnArenaSelectableAsAttacker)
            {
                Debug.Log("Attacking0");
            }
        }
    }
}
