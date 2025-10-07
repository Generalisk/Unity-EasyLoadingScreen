using UnityEditor;
using UnityEngine;

namespace Generalisk.LoadingScreen.Editor
{
    internal static class SettingProperties
    {
        public static void Draw(SerializedObject obj)
        {
            // Canvas
            var canvas = obj.FindProperty("canvas");
            DrawProperty(canvas, SettingStyles.canvas);

            if (canvas.objectReferenceValue == null)
            {
                EditorGUILayout.HelpBox("No canvas provided! Easy Loading Screen will default to it's built-in canvas.", MessageType.Info);
            }

            // Save Modified Properties
            obj.ApplyModifiedProperties();
        }

        private static void DrawProperty(string property, GUIContent content, SerializedObject obj)
            => DrawProperty(obj.FindProperty(property), content);

        private static void DrawProperty(SerializedProperty property, GUIContent content)
            => EditorGUILayout.PropertyField(property, content);
    }
}
