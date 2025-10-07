using UnityEngine;
using UnityEngine.SceneManagement;

namespace Generalisk.LoadingScreen
{
    public class LoadingInfo : MonoBehaviour
    {
        internal bool deleteObject = false;

        public Scene Scene { get; internal set; }

        public float Progress { get; internal set; } = 0;
    }
}
