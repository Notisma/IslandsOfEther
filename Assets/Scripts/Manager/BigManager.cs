using System;
using Combat;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Manager
{
    public class BigManager : MonoBehaviour
    {
        private static BigManager INST;
        
        public Object prefabCardExample;
        
        
        public static bool combatMode = false;
        public static bool canDragAndDrop;
        
        private void Awake()
        {
            if (INST == null) INST = this;
            DontDestroyOnLoad(this);
        }

        public int i;
        private void Update()
        {
            if (!combatMode) return;
            if (Tour.inATurn) return;

            Tour.Battle(i);
        }

        public static BigManager GetI()
        {
            return INST;
        }

        public void StartCombat()
        {
            combatMode = true;
            i = 0;
        }
    }
}