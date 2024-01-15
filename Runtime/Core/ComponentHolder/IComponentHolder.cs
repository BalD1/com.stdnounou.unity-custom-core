using System;
using UnityEngine;

namespace StdNounou.Core
{
    public interface IComponentHolderBase<EnumType>
                        where EnumType : Enum
    {
        public ExpectedType HolderGetComponent<ExpectedType>(EnumType component)
                                         where ExpectedType : Component;

        public E_HolderResult HolderTryGetComponent<ExpectedType>(EnumType component, out ExpectedType result)
                                              where ExpectedType : Component;

        public void HolderChangeComponent<ExpectedType>(EnumType componentType, ExpectedType component)
                                    where ExpectedType : Component;

        public event Action<ComponentChangeEventArgs<EnumType>> OnComponentModified;
    }

    public enum E_HolderResult
    {
        Success,
        ComponentNotFound,
        TypeUnmatch
    }

    public class ComponentChangeEventArgs<EnumType> : EventArgs
                                    where EnumType : Enum
    {
        public EnumType ComponentType { get; private set; }
        public Component NewComponent { get; private set; }

        public ComponentChangeEventArgs(EnumType componentType, Component newComponent)
        {
            ComponentType = componentType;
            NewComponent = newComponent;
        }
    } 
}