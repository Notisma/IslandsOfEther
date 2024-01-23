using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;

public class BattleStarter : MonoBehaviour
{
    public string enemyName;
    
    public List<string> enemyCards; 
    // Update is called once per frame
    void Update()
    {
        if (GetComponent<CircleCollider2D>().bounds.Contains(PlayerBehaviour.P.transform.position) && Input.GetButtonDown("Confirm"))
        {
            PlayerBehaviour.P.isEnabled = false;
            print("COMBAT MODE !!!");
            SceneLoader.Load(SceneLoader.Scene.CardScene);
            Tour.StartBattle(CreateEnemyFromCardsList());
        }
    }

    private EnemyData CreateEnemyFromCardsList()
    {
        EnemyData enemy = new EnemyData(enemyName);
        foreach(string s in enemyCards)
        {
            enemy.AddCard(CardsManager.cards[s]);
        }

        return enemy;
    }
}
