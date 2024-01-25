#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace StdNounou.Core.Editor
{
    public static class SimpleDraws
    {
        public static void HorizontalLine()
        {
            GUIStyle horizontalLine;
            horizontalLine = new GUIStyle();
            horizontalLine.normal.background = EditorGUIUtility.whiteTexture;
            horizontalLine.margin = new RectOffset(0, 0, 4, 4);
            horizontalLine.fixedHeight = 1;

            var c = GUI.color;
            GUI.color = Color.grey;
            GUILayout.Box(GUIContent.none, horizontalLine);
            GUI.color = c;
        }

        public static void HorizontalLine(Color color)
        {
            GUIStyle horizontalLine;
            horizontalLine = new GUIStyle();
            horizontalLine.normal.background = EditorGUIUtility.whiteTexture;
            horizontalLine.margin = new RectOffset(0, 0, 4, 4);
            horizontalLine.fixedHeight = 1;

            var c = GUI.color;
            GUI.color = color;
            GUILayout.Box(GUIContent.none, horizontalLine);
            GUI.color = c;
        }

        public static void HorizontalLine(Color color, GUIStyle horizontalLine)
        {
            var c = GUI.color;
            GUI.color = color;
            GUILayout.Box(GUIContent.none, horizontalLine);
            GUI.color = c;
        }

        public static int DelayedIntWithLabel(string label, int value)
        {
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.LabelField(label);
            value = EditorGUILayout.DelayedIntField(value);

            EditorGUILayout.EndHorizontal();

            return value;
        }
        public static void DelayedIntWithLabel(string label, ref int value)
        {
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.LabelField(label);
            value = EditorGUILayout.DelayedIntField(value);

            EditorGUILayout.EndHorizontal();
        }

        public static float DelayedFloatWithLabel(string label, float value)
        {
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.LabelField(label);
            value = EditorGUILayout.DelayedFloatField(value);

            EditorGUILayout.EndHorizontal();

            return value;
        }
        public static void DelayedFloatWithLabel(string label, ref float value)
        {
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.LabelField(label);
            value = EditorGUILayout.DelayedFloatField(value);

            EditorGUILayout.EndHorizontal();
        }

        public static void GameObjectField(string label, ref GameObject gO, bool allowSceneObjects = true)
        {
            gO = (GameObject)EditorGUILayout.ObjectField(label, gO, typeof(GameObject), allowSceneObjects);
        }
    }

    public static class ReadOnlyDraws
    {
        public static void GameObjectDraw(GameObject go, string label = "Object", bool allowSceneObject = true)
        {
            GUI.enabled = false;
            go = (GameObject)EditorGUILayout.ObjectField(label, go, typeof(GameObject), allowSceneObject);
            GUI.enabled = true;
        }

        public static void ScriptDraw(Type scriptType, MonoBehaviour mono, bool allowSceneObject = false)
        {
            GUI.enabled = false;
            EditorGUILayout.ObjectField("Script", MonoScript.FromMonoBehaviour(mono), scriptType, false);
            GUI.enabled = true;
        }
        public static void ScriptDraw(Type scriptType, ScriptableObject so, bool allowSceneObject = false)
        {
            GUI.enabled = false;
            EditorGUILayout.ObjectField("Script", MonoScript.FromScriptableObject(so), scriptType, false);
            GUI.enabled = true;
        }

        public static void EditorScriptDraw(Type scriptType, ScriptableObject sO, bool allowSceneObject = false)
        {
            GUI.enabled = false;
            EditorGUILayout.ObjectField("Editor Script", MonoScript.FromScriptableObject(sO), scriptType, allowSceneObject);
            GUI.enabled = true;
        }
    }

    public static class MixedDraws
    {
        public static void ListFoldoutWithSize<T>(ref bool toggle, string label, List<T> list)
        {
            FoldoutWithSize(ref toggle, label, list.Count);
        }
        public static bool ListFoldoutWithEditableSize<T>(ref bool toggle, string label, List<T> list)
        {
            EditorGUILayout.BeginHorizontal();

            bool sizeChanged = false;

            toggle = EditorGUILayout.Foldout(toggle, label);
            int currentSize = list.Count;
            int newSize = currentSize;

            if ((newSize = EditorGUILayout.DelayedIntField(newSize, GUILayout.MaxWidth(50))) != currentSize)
            {
                ChangeListSize<T>(list, newSize);
                sizeChanged = true;
            }

            EditorGUILayout.EndHorizontal();

            return sizeChanged;
        }

        public static void ArrayFoldoutWithSize<T>(ref bool toggle, string label, T[] array)
        {
            FoldoutWithSize(ref toggle, label, array.Length);
        }

        public static bool ArrayFoldoutWithEditableSize<T>(ref bool toggle, string label, ref T[] array)
        {
            EditorGUILayout.BeginHorizontal();

            bool sizeChanged = false;

            toggle = EditorGUILayout.Foldout(toggle, label);
            int currentSize = array.Length;
            int newSize = currentSize;

            if ((newSize = EditorGUILayout.DelayedIntField(newSize, GUILayout.MaxWidth(50))) != currentSize)
            {
                ChangeArraySize<T>(ref array, newSize);
                sizeChanged = true;
            }

            EditorGUILayout.EndHorizontal();

            return sizeChanged;
        }

        private static void FoldoutWithSize(ref bool toggle, string label, int size)
        {
            EditorGUILayout.BeginHorizontal();

            toggle = EditorGUILayout.Foldout(toggle, label);

            GUI.enabled = false;
            EditorGUILayout.IntField(size, GUILayout.MaxWidth(50));
            GUI.enabled = true;

            EditorGUILayout.EndHorizontal();
        }

        public static void ChangeListSize<T>(List<T> list, int newSize)
        {
            if (newSize != 0)
            {
                int currentSize = list.Count;

                // Add i new items
                if (newSize > list.Count)
                {
                    for (int i = 0; i < newSize - currentSize; i++)
                    {
                        list.Insert(list.Count, default(T));
                    }
                }
                // Remove i items
                else
                {
                    for (int i = currentSize - 1; i >= newSize; i--)
                    {
                        list.RemoveAt(i);
                    }
                }
            }
            else
                list.Clear();
        }

        public static void ChangeArraySize<T>(ref T[] array, int newSize)
        {
            Array.Resize(ref array, newSize);
        }
    }

    public static class OpenWindow
    {
        private const string _inspectorWindowTypeName = "UnityEditor.InspectorWindow";
        private const string _browserWindowTypeName = "UnityEditor.ProjectBrowser";
        private const string _hierarchyWindowTypeName = "UnityEditor.SceneHierarchyWindow";
        private const string _gameViewWindowTypeName = "UnityEditor.GameView";
        private const string _consoleViewWindowTypeName = "UnityEditor.ConsoleWindow";
        private const string _sceneWindowTypeName = "UnityEditor.SceneWindow";

        public static void OpenCurrentInspectorInNewWindow(bool locked) => OpenInNewWindow(_inspectorWindowTypeName, locked);
        public static void OpenCurrentBrowserInNewWindow(bool locked) => OpenInNewWindow(_browserWindowTypeName, locked);
        public static void OpenCurrentHierarchyInNewWindow(bool locked) => OpenInNewWindow(_hierarchyWindowTypeName, locked);
        public static void OpenCurrentGameViewInNewWindow() => OpenInNewWindow(_gameViewWindowTypeName);
        public static void OpenCurrentConsoleInNewWindow() => OpenInNewWindow(_consoleViewWindowTypeName);
        public static void OpenCurrentSceneInNewWindow() => OpenInNewWindow(_sceneWindowTypeName);

        public static void OpenInNewWindow(string windowTypeName)
        {
            var inspectorWindowType = typeof(UnityEditor.Editor).Assembly.GetType(windowTypeName);

            System.Reflection.MethodInfo method = typeof(EditorWindow).GetMethod(nameof(EditorWindow.CreateWindow), new[] { typeof(Type[]) });
            System.Reflection.MethodInfo generic = method.MakeGenericMethod(inspectorWindowType);

            generic.Invoke(null, new object[] { new Type[] { } });
        }
        public static void OpenInNewWindow(string windowTypeName, bool locked)
        {
            OpenInNewWindow(windowTypeName);
            ActiveEditorTracker.sharedTracker.isLocked = locked;
        }
    }

    public static class GUIDraw
    {
        public static void DrawStringGUI(string text, Vector3 worldPosition, Color textColor, Vector2 anchor, float textSize = 15f)
        {
            var view = SceneView.currentDrawingSceneView;
            if (!view)
                return;
            Vector3 screenPosition = view.camera.WorldToScreenPoint(worldPosition);
            if (screenPosition.y < 0 || screenPosition.y > view.camera.pixelHeight || screenPosition.x < 0 || screenPosition.x > view.camera.pixelWidth || screenPosition.z < 0)
                return;
            var pixelRatio = HandleUtility.GUIPointToScreenPixelCoordinate(Vector2.right).x - HandleUtility.GUIPointToScreenPixelCoordinate(Vector2.zero).x;
            Handles.BeginGUI();
            var style = new GUIStyle(GUI.skin.label)
            {
                fontSize = (int)textSize,
                normal = new GUIStyleState() { textColor = textColor }
            };
            Vector2 size = style.CalcSize(new GUIContent(text)) * pixelRatio;
            var alignedPosition =
                ((Vector2)screenPosition +
                size * ((anchor + Vector2.left + Vector2.up) / 2f)) * (Vector2.right + Vector2.down) +
                Vector2.up * view.camera.pixelHeight;
            GUI.Label(new Rect(alignedPosition / pixelRatio, size / pixelRatio), text, style);
            Handles.EndGUI();
        }
    }
} 
#endif