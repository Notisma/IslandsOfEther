using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;
using Manager;

namespace Combat
{

    public class BattleStarter : MonoBehaviour
    {
        public string enemyName;
        public List<string> enemyCards;

        public void TestActivate()
        {
            if (GetComponent<CircleCollider2D>().bounds.Contains(PlayerBehaviour.P.transform.position))
            {
                StartCoroutine(SceneLoader.Load(SceneLoader.Scene.Battle));

                PlayerBehaviour.P.CesseTotalementDExister();
                EnemyData en = CreateEnemyFromCardsList();
                
                BattleManager.StartBattle(en);
            }
        }

        private EnemyData CreateEnemyFromCardsList()
        {
            EnemyData enemy = new EnemyData(enemyName);
            EnemyBehaviour.GetI().data = enemy;
            foreach (string s in enemyCards)
            {
                EnemyBehaviour.GetI().GetNewCard(s);
            }

            return enemy;
        }
    }
}