using Data;
using UnityEngine;

namespace Combat.Layout
{
    public class AttackButton : MonoBehaviour
    {
        public int attack;
        public CardData enemy;

        private void OnMouseDown()
        {
            attack = transform.parent.GetComponent<Card>().data.attack;
            enemy.hp -= attack;
        }
    }
}
