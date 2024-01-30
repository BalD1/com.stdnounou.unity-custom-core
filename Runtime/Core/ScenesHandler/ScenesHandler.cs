using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace StdNounou.Core
{
    public class ScenesHandler : PersistentSingleton<ScenesHandler>
    {
        [SerializeField] private string loadingScreenName = "LoadingScene";

        [SerializeField] private string currentMainScene;
        [SerializeField] private List<string> currentSubScenes = new List<string>();

        private Coroutine loadingCor;

        private bool isLoading;
        private bool waitForInput;

        protected override void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
        }

        protected override void OnSceneUnloaded(Scene scene)
        {
        }

        public void LoadSceneAsync(string sceneName, bool waitForInput, bool showLoadingScreen = true)
        {
            if (loadingCor != null) return;
            this.waitForInput = waitForInput;
            isLoading = true;

            loadingCor = StartCoroutine(LoadScene(sceneName));
        }

        private IEnumerator LoadScene(string sceneName, bool showLoadingScreen = true)
        {
            yield return new WaitForSeconds(.05f);

            AsyncOperation op = SceneManager.LoadSceneAsync(loadingScreenName);
            while (op.progress < .9f) yield return null;

            Scene scene = SceneManager.GetSceneByName(sceneName);

            op = SceneManager.LoadSceneAsync(sceneName);
            op.allowSceneActivation = false;
            this.StartedLoadScene(scene);

            while(!op.isDone)
            {
                if (op.progress >= .9f)
                {
                    op.allowSceneActivation = (!waitForInput) || (waitForInput && Input.anyKeyDown);
                    if (isLoading)
                    {
                        currentMainScene = sceneName;

                        isLoading = false;
                        this.FinishedLoadScene(scene);
                    }
                }

                yield return null;
            }
        }
    }
}