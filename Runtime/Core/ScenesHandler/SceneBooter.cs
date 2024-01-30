using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StdNounou.Core
{
    public class SceneBooter : MonoBehaviour
    {
        public List<string> scenes;

        private void Awake()
        {
            //ScenesHandler.Instance.LoadSceneAsync(scenes, true);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space)) 
            {
                ScenesHandler.Instance.AddSceneAsync("Sub1", true, true);
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ScenesHandler.Instance.RemoveSceneAsync("Sub1", true, true);
            }

        }
    }
}
