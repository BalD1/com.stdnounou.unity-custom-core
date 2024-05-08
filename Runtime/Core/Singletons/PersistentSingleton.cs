using UnityEngine;
using UnityEngine.SceneManagement;

namespace StdNounou.Core
{
    public abstract class PersistentSingleton<T> : Singleton<T>
                                        where T : Component
    {
        protected override void Awake()
        {
            if (instance != null)
            {
                Destroy(this.gameObject);
                return;
            }
            base.Awake();
            this.gameObject.transform.SetParent(null);
            DontDestroyOnLoad(this.gameObject);

        }

        protected override void EventsSubscriber()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.sceneUnloaded += OnSceneUnloaded;
        }

        protected override void EventsUnSubscriber()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            SceneManager.sceneUnloaded -= OnSceneUnloaded;
        }

        protected abstract void OnSceneLoaded(Scene scene, LoadSceneMode mode);

        protected abstract void OnSceneUnloaded(Scene scene);
    } 
}