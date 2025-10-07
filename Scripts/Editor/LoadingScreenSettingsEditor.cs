using UnityEditor;
using UnityEngine;

namespace Generalisk.LoadingScreen.Editor
{
    [CustomEditor(typeof(LoadingScreenSettings))]
    class LoadingScreenSettingsEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            // Draw Project Setting Button
            if (GUILayout.Button(new GUIContent("Open in Project Settings")))
            { SettingsService.OpenProjectSettings(ProjectSettings.PATH); }

            // Draw Project Settings
            EditorGUILayout.Space(15);
            SettingProperties.Draw(serializedObject);

            // Draw Internal Properties
            EditorGUILayout.Space(5);
            EditorGUILayout.LabelField(new GUIContent("Internal Properties"), EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("defaultCanvas"), new GUIContent("Default Canvas"));

            // Save Modified Properties
            serializedObject.ApplyModifiedProperties();
        }
    }
}
