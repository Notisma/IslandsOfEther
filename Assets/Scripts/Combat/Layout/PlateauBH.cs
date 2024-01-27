using UnityEngine;

namespace Combat.Layout
{
    public class PlateauBH : MonoBehaviour
    {
        public static PlateauBH Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        public void PlaceCardOnPlate(Card card, bool isAllied)
        {
            int y = (isAllied ? -5 : 5);
            int x = 0 - PlayerBehaviour.I.cardsContainer.GetNbPlacedCards() * 3;
            card.transform.position = new Vector3(x, y, 0);
            card.placed = true;
        }
    }
}
