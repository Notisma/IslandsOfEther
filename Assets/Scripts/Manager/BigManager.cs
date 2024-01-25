using System;
using System.Collections.Generic;
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

        private void Update()
        {
            if (!combatMode) return;
        
            Tour.Battle();
            combatMode = false;
        }

        public static BigManager GetI()
        {
            return INST;
        }

        public void StartCombat()
        {
            combatMode = true;
        }
    }
}