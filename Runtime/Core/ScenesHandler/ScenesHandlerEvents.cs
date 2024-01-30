using System;
using UnityEngine.SceneManagement;

namespace StdNounou.Core
{
	public static class ScenesHandlerEvents
	{
		public static event Action<Scene> OnStartedLoadScene;
		public static void StartedLoadScene(this ScenesHandler scenesHandler, Scene scene)
			=> OnStartedLoadScene?.Invoke(scene);

        public static event Action<Scene> OnFinishedLoadScene;
        public static void FinishedLoadScene(this ScenesHandler scenesHandler, Scene scene)
            => OnFinishedLoadScene?.Invoke(scene);
    } 
}