using Manager;
using Unity;
using Unity.VisualScripting;
using UnityEngine;

    public class EnemyBehaviour
    {
        private static EnemyBehaviour E;

        private EnemyBehaviour()
        {
        }

        public EnemyData data;

        public static EnemyBehaviour GetI()
        {
            if (E == null) E = new EnemyBehaviour();
            return E;
        }
        
        public void GetNewCard(string codename)
        {
            Object newCard = Object.Instantiate(BigManager.GetI().prefabCardExample);
            Card clik = newCard.GetComponent<Card>();
            clik.data = CardsManager.cards[codename];
            data.AddCard(clik);
        }
    }