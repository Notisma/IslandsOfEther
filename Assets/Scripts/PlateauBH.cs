using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void PlaceCardOnPlate(CardClick card)
    {
        print("blabla");
        card.transform.position = transform.position;
        if (EnemyBehaviour.GetI().data.getNbPlacedCards() == 0)
        {
            card.transform.parent = GameObject.FindGameObjectWithTag("Plateau").GetComponent<SpriteRenderer>().transform;
            card.placed = true;
            transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (EnemyBehaviour.GetI().data.getNbPlacedCards() == 1)
        {
            card.transform.parent = GameObject.FindGameObjectWithTag("Plateau").GetComponent<SpriteRenderer>().transform;
            card.placed = true;
            transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (EnemyBehaviour.GetI().data.getNbPlacedCards() == 2)
        {
            card.transform.parent = GameObject.FindGameObjectWithTag("Plateau").GetComponent<SpriteRenderer>().transform;
            card.placed = true;
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
