using System;
using UnityEngine.SceneManagement;

namespace StdNounou.Core
{
	public static class ScenesHandlerEvents
    {
		public static event Action<Scene[]> OnStartedLoadScene;
		public static void StartedLoadScene(this ScenesHandler scenesHandler, Scene[] scenes)
			=> OnStartedLoadScene?.Invoke(scenes);

        public static event Action<Scene[]> OnFinishedLoadScene;
        public static void FinishedLoadScene(this ScenesHandler scenesHandler, Scene[] scenes)
            => OnFinishedLoadScene?.Invoke(scenes);

        public static event Action<Scene[]> OnStartedUnloadScene;
        public static void StartedUnloadScene(this ScenesHandler scenesHandler, Scene[] scenes)
            => OnStartedUnloadScene?.Invoke(scenes);

        public static event Action<Scene[]> OnFinishedUnloadScene;
        public static void FinishedUnloadScene(this ScenesHandler scenesHandler, Scene[] scenes)
            => OnFinishedUnloadScene?.Invoke(scenes);
    } 
}