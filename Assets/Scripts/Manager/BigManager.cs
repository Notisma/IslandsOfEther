using System;
using System.Collections;
using System.Collections.Generic;
using Combat;
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
        
        public bool canDragAndDrop;
 
        [Header("Loadable Assets")]
        public Object prefabCardExample;
        public List<EventFlagBattle> gameEvents;
        
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
        }

        public void CallBattleScene(WielderData en)
        {
            StartCoroutine(CallBattleSceneAux(en));
        }

        private IEnumerator CallBattleSceneAux(WielderData en)
        {
            yield return Load(Scene.Battle);

            PlayerBehaviour.I.CesseTotalementDExister();
            
            StartCoroutine(BattleManager.BattleLoop(en));
        }
    }
}