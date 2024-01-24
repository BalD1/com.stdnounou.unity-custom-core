using System;
using UnityEngine;

namespace StdNounou.Core.ComponentsHolder
{
    public interface IComponentHolder
    {
        public ExpectedType HolderGetComponent<ExpectedType>(E_ComponentsKeys component)
                                         where ExpectedType : Component;

        public E_HolderResult HolderTryGetComponent<ExpectedType>(E_ComponentsKeys component, out ExpectedType result)
                                              where ExpectedType : Component;

        public void HolderChangeComponent<ExpectedType>(E_ComponentsKeys componentType, ExpectedType component)
                                    where ExpectedType : Component;

        public event Action<ComponentChangeEventArgs> OnComponentModified;
    }

    public enum E_HolderResult
    {
        Success,
        ComponentNotFound,
        TypeUnmatch
    }

    public class ComponentChangeEventArgs : EventArgs
    {
        public E_ComponentsKeys ComponentType { get; private set; }
        public Component NewComponent { get; private set; }

        public ComponentChangeEventArgs(E_ComponentsKeys componentType, Component newComponent)
        {
            ComponentType = componentType;
            NewComponent = newComponent;
        }
    }
}