using System.Collections.Generic;
using UnityEngine;

namespace StdNounou
{
    public interface IDependency
    {
        public bool InstanceExists();
        public GameObject GetInstance();
        public List<GameObject> GetInstances();
    } 
}