
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
    }
    
    public static void EndBattle()
    {
        SceneLoader.Load(SceneLoader.previousScene);
        PlayerBehaviour.P.isEnabled = true;
        PlayerBehaviour.P.data.AddCard(CardsManager.GetRandomCard());
    }
}