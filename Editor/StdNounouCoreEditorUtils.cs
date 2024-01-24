using System.Text;
using UnityEditor;

namespace StdNounou.Core.Editor
{
    public static class StdNounouCoreEditorUtils
    {
        [MenuItem("StdNounou/CreateFile/ComponentEnum")]
        private static void CreateComponentEnum()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("namespace StdNounou.Core \n");
            sb.Append("{\n");
            sb.Append("    public enum E_ComponentsKeys\n");
            sb.Append("    {\n");
            sb.Append("        Rigidbody,\n");
            sb.Append("        AudioPlayer,\n");
            sb.Append("        Renderer,\n");
            sb.Append("        HealthSystem\n");
            sb.Append("    }\n");
            sb.Append("}");

            EditorCreates.TryCreateFolder("StdNounou", "Assets");
            EditorCreates.TryCreateFolder("Keys", "Assets/StdNounou");
            EditorCreates.TryCreateFolder("Components", "Assets/StdNounou/Keys");
            EditorCreates.CreateFile("ComponentsKeys", "Assets/StdNounou/Keys/Components/", ".cs", sb.ToString(), false);

            //create assembly def with stdnounou.core.runtime
            EditorCreates.CreateAssemblyDefinition("StdNounou.core.runtime_ref", "Assets/StdNounou/Keys/Components/", true, "GUID:07390520b8bc5a54cb973a134834aabf");
        }
    }
}