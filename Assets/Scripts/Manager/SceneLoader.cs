using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Manager.SceneLoader.Scene;

namespace Manager
{
    public static class SceneLoader
    {
        public enum Scene
        {
            Overworld,
            Battle,
            Titlescreen
        }

        public static PlayerBehaviour player;

        public static Scene previousScene;
        public static Scene currentScene = Titlescreen;

        public static bool isLoaded = true;

        public static IEnumerator Load(Scene newScene)
        {
            previousScene = currentScene;
            currentScene = newScene;

            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(newScene.ToString());

            isLoaded = false;
            while (!asyncLoad.isDone)
            {
                Debug.Log("loading.......");
                yield return null;
            }

            isLoaded = true;

            Debug.Log("Loaded !!");
            BigManager.I.LoadAssets();
        }

        public static bool SceneIs(Scene test)
        {
            return currentScene == test;
        }
    }
}