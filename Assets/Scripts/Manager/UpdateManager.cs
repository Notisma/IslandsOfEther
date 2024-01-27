using System;
using Combat;
using UnityEngine;
using static Manager.SceneLoader;

namespace Manager
{
    public class UpdateManager : MonoBehaviour
    {
        private void Start()
        {
            DontDestroyOnLoad(this);
        }

        private void Update()
        {
            if (!isLoaded) return;
            
            if (SceneIs(Scene.Titlescreen))
            {
                // main menu
                if (Input.GetButtonDown("Confirm"))
                {
                    StartCoroutine(Load(Scene.Overworld));
                }
                //
            }
            else if (SceneIs(Scene.Overworld))
            {
                // player
                PlayerBehaviour.P.HandleWalking();
                //

                // battle starter
                if (Input.GetButtonDown("Confirm"))
                {
                    foreach (BattleStarter ev in BigManager.I.gameEvents)
                    {
                        ev.TestActivate();
                    }
                }
                //

                // player sprite
                PlayerBehaviour.P.childSprite.HandleKeyInput();
                //
            }
            else if (SceneIs(Scene.Battle))
            {
                // big manager
                BattleManager.Battle();
                //
            }
        }
    }
}