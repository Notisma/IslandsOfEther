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

        void Update()
        {
            if (GetComponent<CircleCollider2D>().bounds.Contains(PlayerBehaviour.P.transform.position) &&
                Input.GetButtonDown("Confirm"))
            {
                print("COMBAT MODE !!!");
                SceneLoader.Load(SceneLoader.Scene.CardScene);

                PlayerBehaviour.P.CesseTotalementDExister();
                EnemyData en = CreateEnemyFromCardsList();
                
                Tour.StartBattle(en);
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