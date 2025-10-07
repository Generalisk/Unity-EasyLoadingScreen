using TMPro;
using UnityEngine;

namespace Generalisk.LoadingScreen
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    class LoadingPercentage : MonoBehaviour
    {
        private TextMeshProUGUI text;
        private LoadingInfo info;

        void Awake() => text = GetComponent<TextMeshProUGUI>();

        void Start() => info = FindFirstObjectByType<LoadingInfo>();

        void Update() => text.text = (info.Progress * 100) + "%";
    }
}
