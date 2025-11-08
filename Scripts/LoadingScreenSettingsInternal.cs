using System.Linq;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace Generalisk.LoadingScreen
{
    public class LoadingScreenSettingsInternal : ScriptableObject
    {
        public Canvas defaultCanvas;

        public static LoadingScreenSettingsInternal Instance { get; private set; } = null;

#if UNITY_EDITOR
        internal const string ID = SceneLoader.PACKAGE_ID + ".internal";
        internal const string DEFAULT_PATH = "Packages/" + SceneLoader.PACKAGE_ID + "/Settings.asset";

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
