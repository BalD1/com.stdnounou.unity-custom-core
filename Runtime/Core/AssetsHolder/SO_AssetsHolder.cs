using AYellowpaper.SerializedCollections;
using UnityEngine;

namespace StdNounou.Core
{
    public abstract class SO_AssetsHolder<T> : ScriptableObject
    {
        [SerializeField] protected SerializedDictionary<string, T> assetsDictionnary;

        public T GetAsset(string id)
        {
            if (assetsDictionnary == null || assetsDictionnary.Count == 0)
            {
                this.LogError("Dictionnary was not initialized or is empty.");
                return default(T);
            }
            if (assetsDictionnary.TryGetValue(id, out T asset)) return asset;
            this.LogError($"Could not fint asset \"{id}\" in dictionnary.");
            return default(T);
        }
    } 
}