using UnityEngine;
using UnityEngine.SceneManagement;

namespace Generalisk.LoadingScreen
{
    public class LoadingInfo : MonoBehaviour
    {
        internal bool deleteObject = false;

        public float Progress { get; internal set; } = 0;

        [System.Obsolete] public Scene Scene { get; internal set; }
        public string SceneName { get; internal set; } = string.Empty;
        public int SceneIndex { get; internal set; } = -1;
    }
}
