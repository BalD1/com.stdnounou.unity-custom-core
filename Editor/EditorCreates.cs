using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace StdNounou.Core.Editor
{
	public static class EditorCreates
	{
        public static void CreateFile(string fileName, string fileDest, string fileExtension, string fileContent, bool refresh = true)
        {
            Debug.Log($"Started creating file {fileName}{fileExtension} at {fileDest}");
            // make sure script has a name
            if (fileName.Length == 0)
            {
                Debug.LogError("Script name length cannot be zero!");
                return;
            }

            // remove spaces
            fileName = fileName.Replace(" ", "");
            Debug.Log("Final file name : " + fileName);

            string assetPath = fileDest + fileName + fileExtension;
            Debug.Log("Final file path : " + assetPath);
            // make sure this script doesn't already exist
            if (File.Exists(assetPath))
            {
                Debug.LogError("A file of that name already exists!");
                return;
            }

            // create the script
            using StreamWriter outfile = new StreamWriter(assetPath);
            outfile.WriteLine(fileContent);
            Debug.Log("Sucessfuly created file");
            if (refresh) AssetDatabase.Refresh();
        }

        public static void TryCreateFolder(string folderName, string folderPath)
        {
            if (AssetDatabase.IsValidFolder(folderPath + "/" + folderName)) return;
            AssetDatabase.CreateFolder(folderPath, folderName);
        }

        public static void CreateAssemblyDefinition(string defName, string defDest, bool refresh, params string[] assembliesGUIDs)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{\n");
            foreach (var item in assembliesGUIDs)
                sb.Append($"    \"reference\": \"{item}\"\n");
            sb.Append("}");
            CreateFile(defName, defDest, ".asmref", sb.ToString(), refresh);
        }
    }
}
