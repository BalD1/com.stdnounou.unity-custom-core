using AYellowpaper.SerializedCollections;
using StdNounou.Core;
using System;
using UnityEngine;

namespace StdNounou.Core
{
    public class SimpleComponentHolder : MonoBehaviour, IComponentHolderBase<E_ComponentTypes>
    {
        [field: SerializeField] public SerializedDictionary<E_ComponentTypes, Component> CreatureComponents {  get; private set; }

        public event Action<ComponentChangeEventArgs<E_ComponentTypes>> OnComponentModified;

        public ExpectedType HolderGetComponent<ExpectedType>(E_ComponentTypes component) where ExpectedType : Component
        {
            return CreatureComponents[component] as ExpectedType;
        }

        public E_HolderResult HolderTryGetComponent<ExpectedType>(E_ComponentTypes component, out ExpectedType result) where ExpectedType : Component
        {
            result = null;
            if (!CreatureComponents.TryGetValue(component, out Component brutResult))
            {
                this.LogError(E_HolderResult.ComponentNotFound, component);
                return E_HolderResult.ComponentNotFound;
            }
            if (brutResult.GetType() != typeof(ExpectedType))
            {
                this.LogError(E_HolderResult.TypeUnmatch, component);
                return E_HolderResult.TypeUnmatch;
            }

            result = brutResult as ExpectedType;
            return E_HolderResult.Success;
        }

        public void HolderChangeComponent<ExpectedType>(E_ComponentTypes componentType, ExpectedType component) where ExpectedType : Component
        {
            if (!CreatureComponents.ContainsKey(componentType))
                CreatureComponents.Add(componentType, component);
            else
                CreatureComponents[componentType] = component;

            OnComponentModified?.Invoke(new ComponentChangeEventArgs<E_ComponentTypes>(componentType, component));
        }
    }
}