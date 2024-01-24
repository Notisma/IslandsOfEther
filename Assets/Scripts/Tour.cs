
using System.Linq;
using Data;
using UnityEngine;

public static class Tour
{
    public static PlayerData player;
    public static EnemyData enemy;

    public static void StartBattle(EnemyData enemyData)
    {
        player = PlayerBehaviour.P.data;
        enemy = enemyData;
        Battle();
    }

    public static void Battle()
    {
        int i = 0;
        while (player.cards.Count > 0 || enemy.cards.Count > 0)
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
            i++;
        }
        EndBattle();
    }
    
    public static void EndBattle()
    {
        SceneLoader.Load(SceneLoader.previousScene);
        PlayerBehaviour.P.isEnabled = true;
        PlayerBehaviour.P.data.AddCard(CardsManager.GetRandomCard());
    }
}