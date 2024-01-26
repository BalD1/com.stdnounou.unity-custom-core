using UnityEditor;
using UnityEngine;

namespace StdNounou.Core
{
    [CreateAssetMenu(fileName = "New Prefabs Holder", menuName = "Scriptable/Assets Holders/Prefabs")]
    public class SO_PrefabsHolder : SO_AssetsHolder<GameObject>
    {
        public GameObject CreateNewGameObject(string id, bool asPrefab = false)
            => PerformCreateGameObject(id, null, Vector2.zero, Quaternion.identity, asPrefab);
        public GameObject CreateNewGameObject(string id, Transform parent, bool asPrefab = false)
            => PerformCreateGameObject(id, parent, Vector2.zero, Quaternion.identity, asPrefab);
        public GameObject CreateNewGameObject(string id, Vector2 position, bool asPrefab = false)
            => PerformCreateGameObject(id, null, position, Quaternion.identity, asPrefab);
        public GameObject CreateNewGameObject(string id, Vector2 position, Quaternion rotation, bool asPrefab = false)
            => PerformCreateGameObject(id, null, position, rotation, asPrefab);
        public GameObject CreateNewGameObject(string id, Transform parent, Vector2 position, Quaternion rotation, bool asPrefab = false)
            => PerformCreateGameObject(id, parent, position, rotation, asPrefab);

        private GameObject PerformCreateGameObject(string id, Transform parent, Vector2 position, Quaternion rotation, bool asPrefab)
        {
            GameObject pf = GetAsset(id);
            if (pf == null) return null;
#if UNITY_EDITOR
            GameObject instance = asPrefab ? PrefabUtility.InstantiatePrefab(pf) as GameObject :
                                     pf.Create();
#else
        GameObject instance = pf.Create();
#endif

            instance.transform.SetParent(parent);
            instance.transform.SetLocalPositionAndRotation(position, rotation);
            return instance;
        }
    } 
}