using AYellowpaper.SerializedCollections;
using StdNounou.Core.ComponentsHolder;
using System;
using UnityEngine;

namespace StdNounou.Core.Samples
{
    public class ComponentHolder_String : MonoBehaviour, IComponentHolder_Core<string>
    {
        [field: SerializeField] public SerializedDictionary<string, Component> Components {  get; private set; }

        public event Action<ComponentChangeEventArgs<string>> OnComponentModified;

        public ExpectedType HolderGetComponent<ExpectedType>(string component) where ExpectedType : Component
        {
            return this.HolderGetComponent<string, ExpectedType>(Components, component);
        }

        public E_HolderResult HolderTryGetComponent<ExpectedType>(string component, out ExpectedType result) where ExpectedType : Component
        {
            return this.HolderTryGetComponent(component, Components, out result);
        }

        public void HolderChangeComponent<ExpectedType>(string componentType, ExpectedType component) where ExpectedType : Component
        {
            this.HolderChangeComponent(Components, componentType, component, OnComponentModified);
        }
    }
}