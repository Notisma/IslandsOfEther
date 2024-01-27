using Data;
using Manager;
using UnityEngine;

namespace Combat.Layout
{
    public class Card : MonoBehaviour
    {
        public CardData data;
    
        private SpriteRenderer _spriteRenderer;
        public Plane dragPlane;
        public Vector3 offset;
        public Camera myMainCamera;
    
        public Vector3 initialPos;
        public bool placed;
        public bool allied;

        void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            myMainCamera = Camera.main;

            data = PlayerBehaviour.I.data.cards[0];
            initialPos = transform.position;
        }

        public void OnMouseDown()
        {
            if (!allied) return;
            
            if (!BigManager.I.canDragAndDrop)
            {
                return;
            }
            EnlargeCard();
            dragPlane = new Plane(myMainCamera.transform.forward, transform.position);
            Ray camRay = myMainCamera.ScreenPointToRay(Input.mousePosition);

            float planeDist;
            dragPlane.Raycast(camRay, out planeDist);
            offset = transform.position - camRay.GetPoint(planeDist);
        }

        public void OnMouseUp()
        {
            if (!allied) return;
            
            if (!BigManager.I.canDragAndDrop)
            {
                return;
            }
            transform.localScale = new Vector3((float)0.45, (float)0.45, (float)0.45);
            GameObject cardArena = GameObject.FindGameObjectWithTag("Plateau");
            if (cardArena.GetComponent<BoxCollider2D>().bounds
                .Contains(transform.position))
            {
                PlaceCard();
                BigManager.I.canDragAndDrop = false;
            }
            else
            {
                ResetCard();
            }
        }

        public void OnMouseDrag()
        {
            if (!allied) return;
            
            if (!BigManager.I.canDragAndDrop)
            {
                return;
            }
            if (BigManager.I.alliedCardsContainer.GetNbPlacedCards() < 3)
            {
                MoveCard();
            }
        }


        void EnlargeCard()
        {
            transform.localScale *= 1.5f;
            _spriteRenderer.sortingOrder = 1;
        }

        void ResetCard()
        {
            _spriteRenderer.sortingOrder = 0;
            transform.position = initialPos;
        }

        void MoveCard()
        {
            Ray camRay = myMainCamera.ScreenPointToRay(Input.mousePosition);

            float planeDist;
            dragPlane.Raycast(camRay, out planeDist);
            transform.position = camRay.GetPoint(planeDist) + offset;
        }

        void PlaceCard()
        {
            BigManager.I.alliedCardsContainer.PlaceCardOnPlate(this);

            BigManager.I.alliedCardsContainer.OrderDeck();
            //BattleManager.inPlayerTurn = false;
        }

        public override string ToString()
        {
            return data.name;
        }
    }
}