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
        private static void Init()
        {
            LoadingScreenSettingsInternal dictionary = null;
            if (!EditorBuildSettings.TryGetConfigObject(ID, out dictionary))
            {
                if (AssetDatabase.AssetPathExists(DEFAULT_PATH) &&
                    AssetDatabase.GetMainAssetTypeAtPath(DEFAULT_PATH) == typeof(LoadingScreenSettingsInternal))
                {
                    dictionary = AssetDatabase.LoadAssetAtPath<LoadingScreenSettingsInternal>(DEFAULT_PATH);
                }
                else
                {
                    dictionary = CreateInstance<LoadingScreenSettingsInternal>();
                    AssetDatabase.CreateAsset(dictionary, DEFAULT_PATH);
                }
                EditorBuildSettings.AddConfigObject(ID, dictionary, true);
            }

            var preload = PlayerSettings.GetPreloadedAssets().ToList();
            if (!preload.Contains(dictionary))
            {
                preload.Add(dictionary);
                PlayerSettings.SetPreloadedAssets(preload.ToArray());
            }
        }
#endif

        void OnEnable()
        {
            if (Instance == null)
            { Instance = this; }
        }
    }
}
