using UnityEngine;
using UnityEngine.SceneManagement;

namespace Generalisk.LoadingScreen
{
    public static class SceneLoader
    {
        internal const string PACKAGE_ID = "com.generalisk.loadingscreen";

        /// <summary>
        /// Loads A scene and displays A loading screen
        /// </summary>
        /// <param name="scene">The scene instance to load</param>
        public static void Load(Scene scene)
        {
            // Create Loading Info Object
            var obj = new GameObject("Loading Info");
            Object.DontDestroyOnLoad(obj);

            var info = obj.AddComponent<LoadingInfo>();
            info.deleteObject = true;
            info.Scene = scene;

            // Generate & Open Loading Screen Scene
            var currentScene = SceneManager.GetActiveScene();
            var loadingScreen = GenerateLoadingScene();
            SceneManager.SetActiveScene(loadingScreen);
            SceneManager.UnloadSceneAsync(currentScene);

            // Run Load
            Object.FindFirstObjectByType<LoadingScreenManager>().Load();
        }

        /// <summary>
        /// Loads A scene and displays A loading screen
        /// </summary>
        /// <param name="sceneIndex">The build index of the scene you want the load</param>
        public static void Load(int sceneIndex) =>
            Load(SceneManager.GetSceneByBuildIndex(sceneIndex));

        /// <summary>
        /// Loads A scene and displays A loading screen
        /// </summary>
        /// <param name="sceneName">The name of the scene you want to load</param>
        public static void Load(string sceneName) =>
            Load(SceneManager.GetSceneByName(sceneName));

        /// <summary>
        /// Generates the loading screen scene
        /// </summary>
        /// <returns>The generated scene instance</returns>
        private static Scene GenerateLoadingScene()
        {
            Scene currentScene = SceneManager.GetActiveScene();
            var settings = LoadingScreenSettings.Instance;
            var settingsInternal = LoadingScreenSettingsInternal.Instance;

            // Create Scene
            var scene = SceneManager.CreateScene("LoadingScreen");
            SceneManager.SetActiveScene(scene);

            // Create Camera
            // this is to fix the screen not refreshing properly
            var cameraObj = new GameObject("Main Camera");
            var camera = cameraObj.AddComponent<Camera>();
            camera.clearFlags = CameraClearFlags.SolidColor;
            camera.backgroundColor = Color.black;

            // Create Manager Object
            var obj = new GameObject("Manager");
            obj.AddComponent<LoadingScreenManager>();

            // Load Canvas
            if (settings.canvas != null) { Object.Instantiate(settings.canvas); }
            else { Object.Instantiate(settingsInternal.defaultCanvas); }

            // Finish up
            SceneManager.SetActiveScene(currentScene);

            return scene;
        }
    }
}
