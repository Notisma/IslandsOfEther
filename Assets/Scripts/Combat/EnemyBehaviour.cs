using Manager;
using Unity.VisualScripting;
using UnityEngine;

namespace Combat
{
    public class EnemyBehaviour
    {
        private static EnemyBehaviour I;

        private EnemyBehaviour()
        {
        }

        public EnemyData data;

        public static EnemyBehaviour GetI()
        {
            return I ??= new EnemyBehaviour();
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