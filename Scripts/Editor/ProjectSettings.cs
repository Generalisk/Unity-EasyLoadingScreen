using UnityEditor;
using UnityEngine.UIElements;

namespace Generalisk.LoadingScreen.Editor
{
    class ProjectSettings : SettingsProvider
    {
        internal const string PATH = "Project/Loading Screen";

        private SerializedObject settings;

        ProjectSettings() : base(PATH, SettingsScope.Project) { }

        [SettingsProvider]
        private static SettingsProvider Init()
        {
            var provider = new ProjectSettings();
            provider.keywords = GetSearchKeywordsFromGUIContentProperties<SettingStyles>();
            return provider;
        }

        public override void OnActivate(string searchContext, VisualElement rootElement)
            => settings = new SerializedObject(LoadingScreenSettings.Get());

        public override void OnGUI(string searchContext)
        {
            EditorGUILayout.Space(5);
            SettingProperties.Draw(settings);
        }
    }
}
