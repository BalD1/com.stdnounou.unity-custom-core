using AYellowpaper.SerializedCollections;
using System;
using UnityEngine;

namespace StdNounou.Core.ComponentsHolder
{
    public class ComponentHolder_Key : MonoBehaviour, IComponentHolder_Core<SO_KeyContainer>
    {
        [field: SerializeField] public SerializedDictionary<SO_KeyContainer, Component> Components {  get; private set; }

        public event Action<ComponentChangeEventArgs<SO_KeyContainer>> OnComponentModified;

        public ExpectedType HolderGetComponent<ExpectedType>(SO_KeyContainer component) where ExpectedType : Component
        {
            return this.HolderGetComponent<SO_KeyContainer, ExpectedType>(Components, component);
        }

        public E_HolderResult HolderTryGetComponent<ExpectedType>(SO_KeyContainer component, out ExpectedType result) where ExpectedType : Component
        {
            return this.HolderTryGetComponent(component, Components, out result);
        }

        public void HolderChangeComponent<ExpectedType>(SO_KeyContainer componentType, ExpectedType component) where ExpectedType : Component
        {
            this.HolderChangeComponent(Components, componentType, component, OnComponentModified);
        }
    }
}