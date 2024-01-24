
using System.Linq;
using Data;
using Manager;
using UnityEngine;

namespace Combat
{

    public static class Tour
    {
        public static PlayerData player;
        public static EnemyData enemy;

        public static void StartBattle(EnemyData enemyData)
        {
            player = PlayerBehaviour.P.data;
            enemy = enemyData;
            EnemyBehaviour.GetI().data = enemy;
            BigManager.GetI().StartCombat();
        }

        public static bool Battle(int i)
        {
            if (player.cards.Count > 0 || enemy.cards.Count > 0)
            {
                if (i % 2 == 0)
                {
                    player.canPlay = true;
                    enemy.canPlay = false;
                }
                else
                {
                    player.canPlay = false;
                    enemy.canPlay = true;
                }

                return true;
            }

            return false;
        }

        public static void EndBattle()
        {
            BigManager.combatMode = false;
            SceneLoader.Load(SceneLoader.previousScene);
            PlayerBehaviour.P.isEnabled = true;
            PlayerBehaviour.P.GetNewCard(CardsManager.GetRandomCard().id);
        }
    }
}