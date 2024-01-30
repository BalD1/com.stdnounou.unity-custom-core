using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace StdNounou.Core
{
    public class ScenesHandler : PersistentSingleton<ScenesHandler>
    {
        [SerializeField] private string loadingScreenName = "LoadingScene";

        [SerializeField] private List<string> loadedScenes = new List<string>();

        private Coroutine currentCor;

        private bool isLoading;

        protected override void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
        }

        protected override void OnSceneUnloaded(Scene scene)
        {
        }

        public void LoadSceneAsync(string sceneName, bool showLoadingScreen = true, bool waitForInput = true)
        {
            LoadSceneAsync(new List<string>() { sceneName }, showLoadingScreen, waitForInput);
        }
        public void LoadSceneAsync(List<string> subScenes, bool showLoadingScreen = true, bool waitForInput = true)
        {
            if (currentCor != null) return;
            isLoading = true;

            currentCor = StartCoroutine(LoadScene(subScenes, showLoadingScreen, waitForInput));
        }

        public void AddSceneAsync(string sceneName, bool showLoadingScreen = true, bool waitForInput = true)
        {
            AddSceneAsync(new List<string> { sceneName }, showLoadingScreen, waitForInput);
        }
        public void AddSceneAsync(List<string> scenesNames, bool showLoadingScreen = true, bool waitForInput = true)
        {
            if (currentCor != null) return;
            isLoading = true;

            currentCor = StartCoroutine(LoadScene(scenesNames, showLoadingScreen, waitForInput, LoadSceneMode.Additive, LoadSceneMode.Additive));
        }

        private IEnumerator LoadScene(List<string> scenesNames, bool showLoadingScreen = true, bool waitForInput = true, LoadSceneMode firstSceneLoadMode = LoadSceneMode.Single, LoadSceneMode loadingSceneLoadMode = LoadSceneMode.Single)
        {
            yield return new WaitForSeconds(.05f);

            AsyncOperation[] ops = new AsyncOperation[scenesNames.Count];
            if (showLoadingScreen)
            {
                AsyncOperation loadingOP = SceneManager.LoadSceneAsync(loadingScreenName, loadingSceneLoadMode);
                while (loadingOP.progress < .9f) yield return null;
            }

            Scene[] scenes = new Scene[scenesNames.Count];

            for (int i = 0; i < scenesNames.Count; i++)
            {
                string sceneName = scenesNames[i];
                if (loadedScenes.Contains(sceneName)) continue;

                loadedScenes.Add(sceneName);
                scenes[i] = SceneManager.GetSceneByName(sceneName);
                ops[i] = SceneManager.LoadSceneAsync(sceneName, i == 0 ? firstSceneLoadMode : LoadSceneMode.Additive);
                ops[i].allowSceneActivation = false;
            }

            this.StartedLoadScene(scenes);

            foreach (var item in ops)
            {
                if (item == null) continue;
                if (!item.isDone) yield return null;
            }

            isLoading = false;
            this.FinishedLoadScene(scenes);

            if (waitForInput)
            {
                while (!Input.anyKeyDown) yield return null;
            }

            foreach (var item in ops)
            {
                if (item == null) continue;
                item.allowSceneActivation = true;
            }

            if (loadingSceneLoadMode == LoadSceneMode.Additive)
                SceneManager.UnloadSceneAsync(loadingScreenName);
            currentCor = null;
        }

        public void RemoveSceneAsync(string sceneName, bool showLoadingScreen = true, bool waitForInput = true)
        {
            RemoveSceneAsync(new List<string> { sceneName} , showLoadingScreen, waitForInput);
        }
        public void RemoveSceneAsync(List<string> scenesNames, bool showLoadingScreen = true, bool waitForInput = true)
        {
            if (currentCor != null) return;

            currentCor = StartCoroutine(UnloadScene(scenesNames, showLoadingScreen, waitForInput));
        }

        private IEnumerator UnloadScene(List<string> scenesNames, bool showLoadingScreen = true, bool waitForInput = true)
        {
            yield return new WaitForSeconds(.05f);

            AsyncOperation[] ops = new AsyncOperation[scenesNames.Count];
            if (showLoadingScreen)
            {
                AsyncOperation loadingOP = SceneManager.LoadSceneAsync(loadingScreenName, LoadSceneMode.Additive);
                while (loadingOP.progress < .9f) yield return null;
            }

            Scene[] scenes = new Scene[scenesNames.Count];

            for (int i = 0; i < scenesNames.Count; i++)
            {
                string sceneName = scenesNames[i];
                if (!loadedScenes.Contains(sceneName)) continue;
                loadedScenes.Remove(sceneName);
                scenes[i] = SceneManager.GetSceneByName(sceneName);

                ops[i] = SceneManager.UnloadSceneAsync(sceneName);
                ops[i].allowSceneActivation = false;
            }

            this.StartedUnloadScene(scenes);

            foreach (var item in ops)
            {
                Debug.Log(item.progress);
                if (item == null) continue;
                if (!item.isDone) yield return null;
            }

            isLoading = false;
            this.FinishedUnloadScene(scenes);

            if (waitForInput)
            {
                while (!Input.anyKeyDown) yield return null;
            }

            SceneManager.UnloadSceneAsync(loadingScreenName);
            currentCor = null;
        }
    }
}