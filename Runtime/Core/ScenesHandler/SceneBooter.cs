using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StdNounou.Core
{
    public class SceneBooter : MonoBehaviour
    {
        [SerializeField] private List<string> scenesToBoot;

        protected virtual void Start()
        {
            if (scenesToBoot == null || scenesToBoot.Count == 0) 
            {
                this.LogError("Not scenes to load where given in list.");
                return;
            }
            ScenesHandler.Instance.LoadSceneAsync(scenesToBoot, false, false);
        }
    }
}
