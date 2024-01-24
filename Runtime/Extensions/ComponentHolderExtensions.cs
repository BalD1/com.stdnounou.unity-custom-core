using AYellowpaper.SerializedCollections;
using System;
using UnityEngine;

namespace StdNounou.Core.ComponentsHolder
{
	public static class ComponentHolderExtensions
	{
		public static void LogError(this IComponentHolder holder, E_HolderResult result, E_ComponentsKeys compType)
        {
			switch (result)
			{
                case E_HolderResult.ComponentNotFound:
					holder.LogError($"Component \"{compType}\" was not found in holder \"{holder}\".");
					break;

                case E_HolderResult.TypeUnmatch:
					holder.LogError($"Component \"{compType}\" mismatch in holder \"{holder}\".");
					break;
            }
		}

        public static E_HolderResult HolderTryGetComponent<ExpectedType>(this IComponentHolder holder, SerializedDictionary<E_ComponentsKeys, Component> holderDictionnary, E_ComponentsKeys component, out ExpectedType result)
                                                                     where ExpectedType : Component
        {
            result = null;
            if (!holderDictionnary.TryGetValue(component, out Component brutResult))
            {
                holder.LogError(E_HolderResult.ComponentNotFound, component);
                return E_HolderResult.ComponentNotFound;
            }
            if (brutResult.GetType() != typeof(ExpectedType))
            {
                if (brutResult.TryGetComponent(out result))
                {
                    holder.LogError($"Component of type {component} was found in {brutResult}, but {brutResult} was not the direct result. Ensure that the object set in holder is the component, not the GameObject.");
                    return E_HolderResult.Success;
                }
                holder.LogError(E_HolderResult.TypeUnmatch, component);
                return E_HolderResult.TypeUnmatch;
            }

            result = brutResult as ExpectedType;
            return E_HolderResult.Success;
        }

        public static ExpectedType HolderGetComponent<ExpectedType>(this IComponentHolder holder, SerializedDictionary<E_ComponentsKeys, Component> holderDictionnary, E_ComponentsKeys component) 
                                                                where ExpectedType : Component
        {
            return holderDictionnary[component] as ExpectedType;
        }

        public static void HolderChangeComponent<ExpectedType>(this IComponentHolder holder, SerializedDictionary<E_ComponentsKeys, Component> holderDictionnary, E_ComponentsKeys componentType, ExpectedType component, Action<ComponentChangeEventArgs> onChangeAction) 
                                                           where ExpectedType : Component
        {
            if (!holderDictionnary.ContainsKey(componentType))
                holderDictionnary.Add(componentType, component);
            else
                holderDictionnary[componentType] = component;

            onChangeAction?.Invoke(new ComponentChangeEventArgs(componentType, component));
        }
    }
}
