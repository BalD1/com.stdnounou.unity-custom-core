using System;
using System.Collections.Generic;
using UnityEngine;

namespace StdNounou.Core
{
    public abstract class Singleton<T> : MonoBehaviourEventsHandler, IDependency
                              where T : Component
    {
        protected static T instance;
        public static T Instance
        {
            get
            {
                if (instance) return instance;

                T[] objs = FindObjectOfType(typeof(T)) as T[];
                if (objs == null)
                {
                    CustomLogger.LogError(typeof(T), "There is none " + typeof(T) + " singleton found. Will create one now.");
                    return CreateInstance();
                }
                if (objs.Length > 0) instance = objs[0];
                if (objs.Length > 1) CustomLogger.LogError(typeof(T), "There is more than one " + typeof(T) + " object.");

                return instance;
            }
        }

        [SerializeField] private GameObject[] dependecies;

        private void Reset()
        {
            this.gameObject.name = typeof(T).Name;
        }

        protected virtual void Awake()
        {
            if (instance != null)
            {
                Destroy(this.gameObject);
                return;
            }
            instance = this as T;
        }

        protected virtual void Start()
        {
            CheckDependencies();
        }

        private void CheckDependencies()
        {
            if (dependecies == null) return;
            foreach (var item in dependecies)
            {
                if (!(item.GetComponent<IDependency>()).InstanceExists())
                {
                    this.Log("No instance dependecy " + item.name + " of " + typeof(T) + " was found. Trying to create one...");
                    GameObject res = item.Create();
                    if (res) this.Log("Creation of " + item.name + " Succeeded.");
                    else this.Log("Creation of " + item.name + " Failed.");
                }
            }
        }

        public static bool ST_InstanceExists()
        {
            return instance != null;
        }
        public bool InstanceExists()
        {
            return instance != null;
        }

        public GameObject GetInstance()
        {
            return Instance.gameObject;
        }

        [Obsolete("Should use GetInstance instead, as there should not exist more than one Singleton Instance at once.")]
        public List<GameObject> GetInstances()
        {
            this.Log("Should not be using GetInstances on Singleton. Use GetInstance instead.", CustomLogger.E_LogType.Warning);
            return new List<GameObject>(GetInstances());
        }

        public static T CreateInstance()
        {
            GameObject singletonPrefab = SSO_PrefabsGetter.Instance.GetPrefab(typeof(T).Name);
            T newInstance = singletonPrefab.Create<T>();
            return newInstance;
        }

        protected virtual void OnDestroy()
        {
            if (instance == this) instance = null;
        }
    } 
}