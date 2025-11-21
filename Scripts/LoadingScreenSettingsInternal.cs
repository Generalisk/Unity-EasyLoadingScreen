using System.Linq;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace Generalisk.LoadingScreen
{
    internal class LoadingScreenSettingsInternal : ScriptableObject
    {
        public Canvas defaultCanvas;

        /// <summary>
        /// (Runtime only! Use the Get() function for editor scripts)
        /// </summary>
        public static LoadingScreenSettingsInternal Instance { get; private set; } = null;

#if UNITY_EDITOR
        internal const string ID = SceneLoader.PACKAGE_ID + ".internal";
        internal const string DEFAULT_PATH = "Packages/" + SceneLoader.PACKAGE_ID + "/Settings.asset";

        /// <summary>
        /// Gets the settings instance, or generates a new one if it could not be found
        /// 
        /// (Editor only! Use the Instance property for runtime scripts)
        /// </summary>
        /// <returns>The settings instance</returns>
        [InitializeOnLoadMethod]
        public static LoadingScreenSettingsInternal Get()
        {
            LoadingScreenSettingsInternal settings = null;
            if (!EditorBuildSettings.TryGetConfigObject(ID, out settings))
            {
                if (AssetDatabase.AssetPathExists(DEFAULT_PATH) &&
                    AssetDatabase.GetMainAssetTypeAtPath(DEFAULT_PATH) == typeof(LoadingScreenSettingsInternal))
                {
                    settings = AssetDatabase.LoadAssetAtPath<LoadingScreenSettingsInternal>(DEFAULT_PATH);
                }
                else
                {
                    settings = CreateInstance<LoadingScreenSettingsInternal>();
                    AssetDatabase.CreateAsset(settings, DEFAULT_PATH);
                }
                EditorBuildSettings.AddConfigObject(ID, settings, true);
            }

            var preload = PlayerSettings.GetPreloadedAssets().ToList();
            if (!preload.Contains(settings))
            {
                preload.Add(settings);
                PlayerSettings.SetPreloadedAssets(preload.ToArray());
            }

            return settings;
        }
#endif

        void OnEnable()
        {
            if (Instance == null)
            { Instance = this; }
        }
    }
}
