using UnityEngine;
using UnityEngine.SceneManagement;

namespace StdNounou.Core
{
    public class LoadingScreen : MonoBehaviourEventsHandler
    {
        [SerializeField] private RectTransform loadingPrompt;
        [SerializeField] private RectTransform loadingCompletedScreen;

        protected override void EventsSubscriber()
        {
            ScenesHandlerEvents.OnFinishedLoadScene += OnLoadingCompleted;
            ScenesHandlerEvents.OnFinishedUnloadScene += OnLoadingCompleted;
        }

        protected override void EventsUnSubscriber()
        {
            ScenesHandlerEvents.OnFinishedLoadScene -= OnLoadingCompleted;
            ScenesHandlerEvents.OnFinishedUnloadScene -= OnLoadingCompleted;
        }

        protected override void Awake()
        {
            base.Awake();
            SetScreensState(true);
        }

        public void OnLoadingCompleted(Scene[] scenes)
        {
            SetScreensState(false);
        }

        private void SetScreensState(bool state)
        {
            loadingPrompt.gameObject.SetActive(state);
            loadingCompletedScreen.gameObject.SetActive(!state);
        }
    } 
}
