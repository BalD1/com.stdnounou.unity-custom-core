using System.Dynamic;
using UnityEngine;

namespace StdNounou.Core
{
    public abstract class ScriptableSingleton<T> : ScriptableObject where T : ScriptableSingleton<T>
    {
        protected static T instance;
        public static T Instance
        {
            get
            {
                if (instance != null) return instance;
                SetInstance();
                return instance;
            }
        }

        protected static T SetInstance()
        {
            T[] instances = Resources.LoadAll<T>("");
            if (instances.Length == 0)
            {
                CustomLogger.LogError(typeof(ScriptableSingleton<T>), "No instances exist.");
            }
            else
            {
                if (instances.Length > 1)
                    CustomLogger.LogError(typeof(ScriptableSingleton<T>), "Multiple instances exist. Choosing the first one.");
                instance = instances[0];
            }
            return instance;
        }
    }
}