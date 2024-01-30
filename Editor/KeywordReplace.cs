using UnityEngine;
using UnityEditor;

namespace StdNounou.Core.Editor
{
    public class KeywordReplace : AssetModificationProcessor
    {
        public static void OnWillCreateAsset(string path)
        {
            if (path == "") return;
            path = path.Replace(".meta", "");
            int index = path.LastIndexOf(".");
            if (index == -1) return;
            if (index >= path.Length) return;
            string fileExtension = path.Substring(index);
            if (fileExtension != ".cs" && fileExtension != ".js" && fileExtension != ".boo") return;
            index = Application.dataPath.LastIndexOf("Assets");
            path = Application.dataPath.Substring(0, index) + path;
            fileExtension = System.IO.File.ReadAllText(path);

            int fileNameIdx = path.LastIndexOf('/');
            string fileName = path.Substring(fileNameIdx + 1);
            fileName = fileName.Replace(".cs", "");

            fileExtension = fileExtension.Replace("#EDITORSCRIPTNAME#", fileName.Replace("ED_", ""));

            System.IO.File.WriteAllText(path, fileExtension);
            AssetDatabase.Refresh();
        }
    }
}
