using System;
using Combat;
using Events;
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
                PlayerBehaviour.I.HandleWalking();
                PlayerBehaviour.I.childSprite.HandleKeyInput();
                //

                // events
                foreach (IEvent ev in BigManager.I.gameEvents)
                {
                    if (ev.IsActivable()) ev.Activate();
                }
                //
            }
            else if (SceneIs(Scene.Battle))
            {
                // big manager
                //StartCoroutine(BattleManager.BattleLoop());
                //
            }
        }
    }
}