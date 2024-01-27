using System.Collections;
using System.Collections.Generic;
using Combat;
using Data;
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
                   GetComponent<CircleCollider2D>().bounds.Contains(PlayerBehaviour.I.transform.position);
        }

        /** Starts the battle */
        public void Activate()
        {
            WielderData en = CreateEnemyFromCardsList();
            BigManager.I.CallBattleScene(en);
        }

        private WielderData CreateEnemyFromCardsList()
        {
            WielderData enemy = new WielderData(enemyName);
            EnemyBehaviour.I().data = enemy;
            foreach (string s in enemyCards)
            {
                EnemyBehaviour.I().GetNewCard(s);
            }

            return enemy;
        }
    }
}