using UnityEngine;
using UnityEngine.SceneManagement;
using static Manager.SceneLoader.Scene;

namespace Manager
{
    
public static class SceneLoader
{
    public enum Scene {
        DemoScene, CardScene, Titlescreen
    }

    public static PlayerBehaviour player;

    public static Scene previousScene;
    public static Scene currentScene = DemoScene;

    public static void Load(Scene newScene) {
        previousScene = currentScene;
        currentScene = newScene;

        SceneManager.LoadScene(newScene.ToString());
    }
}
}