using AYellowpaper.SerializedCollections;
using StdNounou.Core.ComponentsHolder;
using System;
using UnityEngine;

namespace StdNounou.Core.Samples
{
    public class ComponentHolder_Enum : MonoBehaviour, IComponentHolder_Core<E_ComponentsKeys>
    {
        [field: SerializeField] public SerializedDictionary<E_ComponentsKeys, Component> Components { get; private set; }

        public event Action<ComponentChangeEventArgs<E_ComponentsKeys>> OnComponentModified;

        public ExpectedType HolderGetComponent<ExpectedType>(E_ComponentsKeys component) where ExpectedType : Component
        {
            return this.HolderGetComponent<E_ComponentsKeys, ExpectedType>(Components, component);
        }

        public E_HolderResult HolderTryGetComponent<ExpectedType>(E_ComponentsKeys component, out ExpectedType result) where ExpectedType : Component
        {
            return this.HolderTryGetComponent(component, Components, out result);
        }

        public void HolderChangeComponent<ExpectedType>(E_ComponentsKeys componentType, ExpectedType component) where ExpectedType : Component
        {
            this.HolderChangeComponent(Components, componentType, component, OnComponentModified);
        }
    }

    public enum E_ComponentsKeys
    {
        AudioPlayer
    } 
}