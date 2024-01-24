using UnityEngine;
using System.Linq;
using Data;
using Random = System.Random;

public class EnemyTurn : MonoBehaviour
{ 
    public CardData card;
    public CardData player;

    void Start()
    {
        card = CardsManager.GetRandomCard();
        if (EnemyBehaviour.E.data.canPlay)
        {
            if (EnemyBehaviour.E.data.getNbPlacedCards() == 0)
            {
                PlaceCard();
            }
            else if (EnemyBehaviour.E.data.cards.Count() - EnemyBehaviour.E.data.getNbPlacedCards() == 0)
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
    }

    void PlaceCard()
    {
        if (transform.parent.GetComponent<CardContainer>().placed[3] == false)
        {
            transform.position = transform.parent.GetComponent<CardContainer>().placedPos[3];
            transform.parent.GetComponent<CardContainer>().placed[0] = true;
            card.placed = true;
        }
        else if (transform.parent.GetComponent<CardContainer>().placed[4] == false)
        {
            transform.position = transform.parent.GetComponent<CardContainer>().placedPos[4];
            transform.parent.GetComponent<CardContainer>().placed[1] = true;
            card.placed = true;
        }
        else if (transform.parent.GetComponent<CardContainer>().placed[5] == false)
        {
            transform.position = transform.parent.GetComponent<CardContainer>().placedPos[5];
            transform.parent.GetComponent<CardContainer>().placed[2] = true;
            card.placed = true;
        }
    }

    void AttackPlayer()
    {
        int attack = card.attack;
        player.hp -= attack;
    }
}