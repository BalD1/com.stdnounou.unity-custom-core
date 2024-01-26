using UnityEngine;
using UnityEditor;

namespace StdNounou.Core.Editor
{
    public class KeywordReplace : AssetModificationProcessor
    {
        public static void OnWillCreateAsset(string path)
        {
            path = path.Replace(".meta", "");
            int index = path.LastIndexOf(".");
            string file = path.Substring(index);
            if (file != ".cs" && file != ".js" && file != ".boo") return;
            index = Application.dataPath.LastIndexOf("Assets");
            path = Application.dataPath.Substring(0, index) + path;
            file = System.IO.File.ReadAllText(path);

            file = file.Replace("#EDITORSCRIPTNAME#", path.Replace("ED_", ""));

            System.IO.File.WriteAllText(path, file);
            AssetDatabase.Refresh();
        }
    }
}
