using Combat.Turns;
using Data;
using Manager;
using UnityEngine;
using static Combat.Layout.Card.CardState;

namespace Combat.Layout
{
    public class Card : MonoBehaviour
    {
        public enum CardState
        {
            InDeckStatic,
            InDeckSelectable,
            Moving,
            OnArenaStatic,
            OnArenaSelectableAsAttacker,
            OnArenaSelectableAsPrey,
            Dead
        }

        public CardInstData data;

        public Transform spriteFields;
        private SpriteRenderer _spriteRenderer;

        private Plane dragPlane;
        public Vector3 offset;

        public Vector3 initialPos;
        public CardState state;
        public bool allied;

        void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            initialPos = transform.position;

            state = InDeckStatic;
        }

        public void OnMouseDown()
        {
            if (allied)
            {
                if (state is not InDeckSelectable) return;

                EnlargeCard();
                dragPlane = new Plane(Camera.main.transform.forward, transform.position);
                Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

                dragPlane.Raycast(camRay, out var planeDist);
                offset = transform.position - camRay.GetPoint(planeDist);
                state = Moving;
            }
            else
            {
                if (state is not OnArenaSelectableAsPrey) return;

                PlayerTurn.currentCard = this;
                PlayerTurn.userActionWasDone = true;
            }
        }

        public void OnMouseUp()
        {
            if (!allied) return;
            if (state is not Moving) return;

            transform.localScale = new Vector3(0.45f, 0.45f, 0.45f);

            GameObject cardArena = GameObject.FindGameObjectWithTag("Plateau");

            if (cardArena.GetComponent<BoxCollider2D>().OverlapPoint(transform.position))
            {
                DropCardInArena();
            }
            else
            {
                DropCardOutsideOfArena();
            }
        }

        public void OnMouseDrag()
        {
            if (!allied) return;
            if (state is not Moving) return;

            MoveCard();
        }

        private void DropCardInArena()
        {
            BigManager.I.alliedCardsContainer.PlaceCardOnPlate(this);
            BigManager.I.alliedCardsContainer.OrderDeck();

            PlayerTurn.userActionWasDone = true;
        }

        private void DropCardOutsideOfArena()
        {
            _spriteRenderer.sortingOrder = 0;
            transform.position = initialPos;
            state = InDeckSelectable;
        }

        private void EnlargeCard()
        {
            transform.localScale *= 1.5f;
            _spriteRenderer.sortingOrder = 1;
        }

        private void MoveCard()
        {
            Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            dragPlane.Raycast(camRay, out var planeDist);
            transform.position = camRay.GetPoint(planeDist) + offset;
        }

        public override string ToString()
        {
            return data.baseData.name;
        }

        public void RefreshDisplay()
        {
            if (state is Dead) Destroy(gameObject);
            else
            {
                spriteFields.GetChild(2).GetComponent<SpriteRenderer>().sprite = CardsManager.GetAtkSprite(data);
                spriteFields.GetChild(3).GetComponent<SpriteRenderer>().sprite = CardsManager.GetHpSprite(data);
            }
        }
    }
}