using System;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Data
{
    [Serializable] public class CardData
    {
        // attributs et fonctions
        public string id;
        public string name; 
        public int attack;
        public int hp;
        public string description;
        public bool placed;
        

        public CardData(string id,string name, int attack, int hp, string description = "")
        {
            this.id = id;
            this.name = name;
            this.attack = attack;
            this.hp = hp;
            this.description = description;
        }

        void UpdateInfos()
        {
            
        }
    }
}