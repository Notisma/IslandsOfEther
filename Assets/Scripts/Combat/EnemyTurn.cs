using UnityEngine;
using System.Linq;
using Data;
using Random = System.Random;

namespace Combat
{

    public static class EnemyTurn
    {
        public static CardClick card;
        public static CardClick playerCard;

        public static void Loop()
        {
            if (!EnemyBehaviour.GetI().data.canPlay) return;

            if (EnemyBehaviour.GetI().data.getNbPlacedCards() == 0)
            {
                PlaceCard();
            }
            else if (EnemyBehaviour.GetI().data.cards.Count() - EnemyBehaviour.GetI().data.getNbPlacedCards() == 0)
            {
                AttackPlayer();
            }
            else
            {
                Random rand = new Random();
                int randint = rand.Next(0, 1);
                if (randint == 0)
                {
                    PlaceCard();
                }
                else
                {
                    AttackPlayer();
                }
            }
        }

        public static void PlaceCard()
        {
            CardContainer cont = GameObject.FindGameObjectsWithTag("CardContainer")[0].GetComponent<CardContainer>();
            if (cont.placed[3] == false)
            {
                card.transform.position = card.transform.parent.GetComponent<CardContainer>().placedPos[3];
                card.transform.parent.GetComponent<CardContainer>().placed[0] = true;
                card.placed = true;
            }
            else if (card.transform.parent.GetComponent<CardContainer>().placed[4] == false)
            {
                card.transform.position = card.transform.parent.GetComponent<CardContainer>().placedPos[4];
                card.transform.parent.GetComponent<CardContainer>().placed[1] = true;
                card.placed = true;
            }
            else if (card.transform.parent.GetComponent<CardContainer>().placed[5] == false)
            {
                card.transform.position = card.transform.parent.GetComponent<CardContainer>().placedPos[5];
                card.transform.parent.GetComponent<CardContainer>().placed[2] = true;
                card.placed = true;
            }
        }

        public static void AttackPlayer()
        {
            int attack = card.data.attack;
            playerCard.data.hp -= attack;
        }
    }
}