using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StdNounou.Core
{
    public class SceneBooter : MonoBehaviour
    {
        [SerializeField] private string firstSceneName = "MainMenu";

        private void Awake()
        {
            ScenesHandler.Instance.LoadSceneAsync(firstSceneName, true);
        }
    }
}
