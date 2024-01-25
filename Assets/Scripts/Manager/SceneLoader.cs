using UnityEngine;
using UnityEngine.SceneManagement;
using static Manager.SceneLoader.Scene;

namespace Manager
{
    
public static class SceneLoader
{
    public enum Scene {
        Overworld, CardScene, Titlescreen
    }

    public static PlayerBehaviour player;

    public static Scene previousScene;
    public static Scene currentScene = Titlescreen;

    public static void Load(Scene newScene) {
        previousScene = currentScene;
        currentScene = newScene;

        SceneManager.LoadScene(newScene.ToString());
    }
}
}