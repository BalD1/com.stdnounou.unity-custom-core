using UnityEditor;

namespace StdNounou
{
    public static class EditorExtensions
    {
        public static SerializedProperty FindPropertyByAutoPropertyName(this SerializedObject obj, string propName)
        {
            return obj.FindProperty(string.Format("<{0}>k__BackingField", propName));
        }
    } 
}
