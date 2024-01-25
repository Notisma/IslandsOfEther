using System.Collections;
using System.Collections.Generic;
using Manager;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("Confirm"))
        {
            Manager.SceneLoader.Load(Manager.SceneLoader.Scene.Overworld);
        }
        
    }
}
