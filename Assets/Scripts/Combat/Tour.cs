﻿using System.Linq;
using Data;
using Manager;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

namespace Combat
{
    public static class Tour
    {
        public static PlayerData player;
        public static EnemyData enemy;

        public static bool inATurn = false;

        public static void StartBattle(EnemyData enemyData)
        {
            player = PlayerBehaviour.P.data;
            PlayerBehaviour.P.playerCards.OrderDeck();
            enemy = enemyData;
            EnemyBehaviour.GetI().data = enemy;
            BigManager.GetI().StartCombat();
        }

        public static void Battle(int i)
        {
            inATurn = true;
            TourJoueur();
            TourIA();
            inATurn = false;
        }

        private static void TourJoueur()
        {
            MonoBehaviour.print("Tour du joueur");
            if (PlayerBehaviour.P.data.cards.Count < 1 && PlayerBehaviour.P.data.getNbPlacedCards() < 1)
            {
                EndBattle();
                return;
            }

            if (PlayerBehaviour.P.data.cards.Count > 0 && PlayerBehaviour.P.data.getNbPlacedCards() < 3)
            {
                PlayerTurn.PlaceCard();
            }

            if (PlayerBehaviour.P.data.getNbPlacedCards() > 0)
            {
                CardClick cardPlayer = PlayerTurn.ChooseAtkCard();
                CardClick cardEnemy = PlayerTurn.ChooseOppoCard();
                PlayerTurn.AttackEnemy(cardPlayer, cardEnemy);
            }
        }

        private static void TourIA()
        {
            MonoBehaviour.print("Tour de l'adversaire");
            if (EnemyBehaviour.GetI().data.cards.Count < 1 && EnemyBehaviour.GetI().data.getNbPlacedCards() < 1)
            {
                EndBattle();
                return;
            }

            if (EnemyBehaviour.GetI().data.cards.Count > 0 && EnemyBehaviour.GetI().data.getNbPlacedCards() < 3)
            {
                EnemyTurn.PlaceCard();
            }

            if (EnemyBehaviour.GetI().data.getNbPlacedCards() > 0)
            {
                CardClick cardEnemy = EnemyTurn.ChooseAtkCard();
                CardClick cardPlayer = EnemyTurn.ChooseOppoCard();
                EnemyTurn.AttackPlayer(cardEnemy, cardPlayer);
            }
        }

        public static void EndBattle()
        {
            Debug.Log("fini combat");
            BigManager.combatMode = false;
            SceneLoader.Load(SceneLoader.previousScene);
            PlayerBehaviour.P.isEnabled = true;
            PlayerBehaviour.P.GetNewCard(CardsManager.GetRandomCard().id);
        }
    }
}