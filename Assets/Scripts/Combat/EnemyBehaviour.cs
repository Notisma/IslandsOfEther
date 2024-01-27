using Data;
using Manager;
using Unity.VisualScripting;
using UnityEngine;

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
            Object newCard = Object.Instantiate(BigManager.I.prefabCardExample);
            Card clik = newCard.GetComponent<Card>();
            clik.data = CardsManager.cards[codename];
            data.AddCard(clik);
        }
    }
}