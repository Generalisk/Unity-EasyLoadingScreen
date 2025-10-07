using UnityEngine;
using UnityEngine.UI;

namespace Generalisk.LoadingScreen
{
    [RequireComponent(typeof(Slider))]
    class LoadingBar : MonoBehaviour
    {
        private Slider loadingBar;
        private LoadingInfo info;

        void Awake() => loadingBar = GetComponent<Slider>();

        void Start() => info = FindFirstObjectByType<LoadingInfo>();

        void Update() => loadingBar.value = info.Progress;
    }
}
