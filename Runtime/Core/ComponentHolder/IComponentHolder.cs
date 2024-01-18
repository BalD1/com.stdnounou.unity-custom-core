using System;
using UnityEngine;

namespace StdNounou.Core.ComponentsHolder
{
    public interface IComponentHolder_Core<CompKey>
    {
        public ExpectedType HolderGetComponent<ExpectedType>(CompKey component)
                                         where ExpectedType : Component;

        public E_HolderResult HolderTryGetComponent<ExpectedType>(CompKey component, out ExpectedType result)
                                              where ExpectedType : Component;

        public void HolderChangeComponent<ExpectedType>(CompKey componentType, ExpectedType component)
                                    where ExpectedType : Component;

        public event Action<ComponentChangeEventArgs<CompKey>> OnComponentModified;
    }

    public enum E_HolderResult
    {
        Success,
        ComponentNotFound,
        TypeUnmatch
    }

    public class ComponentChangeEventArgs<CompKey> : EventArgs
    {
        public CompKey ComponentType { get; private set; }
        public Component NewComponent { get; private set; }

        public ComponentChangeEventArgs(CompKey componentType, Component newComponent)
        {
            ComponentType = componentType;
            NewComponent = newComponent;
        }
    }
}