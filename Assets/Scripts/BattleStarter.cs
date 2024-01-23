using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStarter : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (GetComponent<CircleCollider2D>().bounds.Contains(PlayerBehaviour.P.transform.position) && Input.GetButtonDown("Confirm"))
        {
            PlayerBehaviour.P.isEnabled = false;
            print("COMBAT MODE !!!");
            SceneLoader.Load(SceneLoader.Scene.CardScene);
        }
    }
}
