using System.Collections.Generic;
using Combat;
using Manager;
using UnityEngine;

namespace Events
{
    public class EventFlagBattle : MonoBehaviour, IEvent
    {
        public string enemyName;
        public List<string> enemyCards;

        /** Tests if player is in bounds */
        public bool IsActivable()
        {
            return Input.GetButtonDown("Confirm")
                   &&
                   GetComponent<CircleCollider2D>().bounds.Contains(PlayerBehaviour.P.transform.position);
        }

        /** Starts the battle */
        public void Activate()
        {
            StartCoroutine(SceneLoader.Load(SceneLoader.Scene.Battle));

            PlayerBehaviour.P.CesseTotalementDExister();

            EnemyData en = CreateEnemyFromCardsList();

            BattleManager.StartBattle(en);
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