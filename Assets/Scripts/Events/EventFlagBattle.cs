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
            BigManager.I.CallBattleScene(this);
        }

        public static WielderData CreateEnemyData(string name, List<string> cardsNames)
        {
            WielderData enemy = new WielderData(name);
            EnemyBehaviour.I().data = enemy;
            foreach (string s in cardsNames)
            {
                EnemyBehaviour.I().GetNewCard(s);
            }

            return enemy;
        }
    }
}