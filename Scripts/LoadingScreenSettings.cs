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

        [SerializeField] internal Canvas defaultCanvas;

        public static LoadingScreenSettings Instance { get; private set; } = null;

#if UNITY_EDITOR
        internal const string ID = SceneLoader.PACKAGE_ID;
        internal const string DEFAULT_PATH = "Assets/Settings/LoadingScreen.asset";

        [InitializeOnLoadMethod]
        private static void Init()
        {
            LoadingScreenSettings dictionary = null;
            if (!EditorBuildSettings.TryGetConfigObject(ID, out dictionary))
            {
                dictionary = CreateInstance<LoadingScreenSettings>();

                AssetDatabase.CreateAsset(dictionary, DEFAULT_PATH);
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
