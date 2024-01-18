using UnityEngine;

namespace StdNounou.Core.ComponentsHolder
{
    public static class KeysHolderExtensions
    {
        public const string KEYS_ASSET_FOLDER_PATH = "StdNounou/Keys/";

        public static void Load(this SO_KeyContainer keyContainer, string keyContainerAssetName)
        {
            keyContainer = Resources.Load<SO_KeyContainer>(KEYS_ASSET_FOLDER_PATH + keyContainerAssetName + ".asset");
        }
        public static void Load(this SO_KeyContainer keyContainer, string keyContainerAssetName, string path)
        {
            keyContainer = Resources.Load<SO_KeyContainer>(path + nameof(keyContainer) + ".asset");
        }
    } 
}
