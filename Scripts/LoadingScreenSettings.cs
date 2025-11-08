using System.IO;
using System.Linq;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace Generalisk.LoadingScreen
{
    public class LoadingScreenSettings : ScriptableObject
    {
        public Canvas canvas;

        public static LoadingScreenSettings Instance { get; private set; } = null;

#if UNITY_EDITOR
        internal const string ID = SceneLoader.PACKAGE_ID;
        internal const string DEFAULT_PATH = "Assets/Settings/LoadingScreen.asset";

        [InitializeOnLoadMethod]
        public static LoadingScreenSettings Get()
        {
            LoadingScreenSettings settings = null;
            if (!EditorBuildSettings.TryGetConfigObject(ID, out settings))
            {
                if (AssetDatabase.AssetPathExists(DEFAULT_PATH) &&
                    AssetDatabase.GetMainAssetTypeAtPath(DEFAULT_PATH) == typeof(LoadingScreenSettings))
                {
                    settings = AssetDatabase.LoadAssetAtPath<LoadingScreenSettings>(DEFAULT_PATH);
                }
                else
                {
                    settings = CreateInstance<LoadingScreenSettings>();

                    if (!Directory.Exists(DEFAULT_PATH + "/../"))
                    { Directory.CreateDirectory(DEFAULT_PATH + "/../"); }

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
