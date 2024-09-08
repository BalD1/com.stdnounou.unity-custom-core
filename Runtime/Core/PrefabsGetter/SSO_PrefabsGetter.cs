using System.Collections.Generic;
using UnityEngine;

namespace StdNounou.Core
{
    [CreateAssetMenu(fileName = "New SSO_PrefabsGetter", menuName = "StdNounou/Scriptables/Prefabs Getter Instance")]
    public class SSO_PrefabsGetter : ScriptableSingleton<SSO_PrefabsGetter>
    {
        public struct S_PrefabByKey
        {
            [field: SerializeField] public SO_KeyContainer Key { get; private set; }
            [field: SerializeField] public GameObject Prefab { get; private set; }
        }

        [SerializeField] private S_PrefabByKey[] prefabsByKey;

        private Dictionary<string, GameObject> hashedPrefabsByKey;

        public GameObject GetPrefab(SO_KeyContainer key)
        {
            if (hashedPrefabsByKey == null)
            {
                hashedPrefabsByKey = new();
                foreach (var item in prefabsByKey)
                {
                    hashedPrefabsByKey.Add(item.Key.Key, item.Prefab);
                }
            }

            return hashedPrefabsByKey[key.Key];
        }
        public GameObject GetPrefab(string key)
        {
            if (hashedPrefabsByKey == null)
            {
                hashedPrefabsByKey = new();
                foreach (var item in prefabsByKey)
                {
                    hashedPrefabsByKey.Add(item.Key.Key, item.Prefab);
                }
            }

            return hashedPrefabsByKey[key];
        }
    }
}
