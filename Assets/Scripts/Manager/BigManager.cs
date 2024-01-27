using System;
using System.Collections.Generic;
using Combat;
using Events;
using UnityEngine;
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
            GameObject eventBox = GameObject.Find("Events");
            foreach (Transform ev in eventBox.transform)
            {
                gameEvents.Add(ev.GetComponent<EventFlagBattle>());
            }
        }
    }
}