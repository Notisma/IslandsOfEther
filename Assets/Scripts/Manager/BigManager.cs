using System;
using System.Collections;
using System.Collections.Generic;
using Combat;
using Combat.Layout;
using Data;
using Events;
using UnityEngine;
using static Manager.SceneLoader;
using Object = UnityEngine.Object;

namespace Manager
{
    public class BigManager : MonoBehaviour
    {
        public static BigManager I;
        
        [Header("Loadable Assets")]
        public Object prefabCardExample;
        public List<EventFlagBattle> gameEvents;
        public CardsContainer alliedCardsContainer;
        public CardsContainer opponentCardsContainer;

        private void Awake()
        {
            if (I == null) I = this;
            DontDestroyOnLoad(this);
        }

        public void LoadAssets()
        {
            if (SceneIs(Scene.Overworld))
            {
                GameObject eventBox = GameObject.Find("Events");
                foreach (Transform ev in eventBox.transform)
                {
                    gameEvents.Add(ev.GetComponent<EventFlagBattle>());
                }
            }
            else if (SceneIs(Scene.Battle))
            {
                alliedCardsContainer = GameObject.Find("PlayerCards").GetComponent<CardsContainer>();
                opponentCardsContainer = GameObject.Find("OpponentCards").GetComponent<CardsContainer>();
            }
        }

        public void CallBattleScene(EventFlagBattle e)
        {
            StartCoroutine(CallBattleSceneAux(e.enemyName, e.enemyCards));
        }

        private IEnumerator CallBattleSceneAux(string enemyName, List<string> enemyCards)
        {
            yield return Load(Scene.Battle);

            PlayerBehaviour.I.CesseTotalementDExister();
            WielderData enemyData = EventFlagBattle.CreateEnemyData(enemyName, enemyCards);
            
            StartCoroutine(BattleManager.BattleLoop(enemyData));
        }
    }
}