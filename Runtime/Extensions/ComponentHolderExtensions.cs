using AYellowpaper.SerializedCollections;
using System;
using UnityEngine;

namespace StdNounou.Core.ComponentsHolder
{
	public static class ComponentHolderExtensions
	{
		public static void LogError<CompKey>(this IComponentHolder_Core<CompKey> holder, E_HolderResult result, CompKey compType)
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

        public static E_HolderResult HolderTryGetComponent<ComponentsKeys, ExpectedType>(this IComponentHolder_Core<ComponentsKeys> holder, ComponentsKeys component, SerializedDictionary<ComponentsKeys, Component> holderDictionnary, out ExpectedType result)
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
                holder.LogError(E_HolderResult.TypeUnmatch, component);
                return E_HolderResult.TypeUnmatch;
            }

            result = brutResult as ExpectedType;
            return E_HolderResult.Success;
        }

        public static ExpectedType HolderGetComponent<ComponentsKeys, ExpectedType>(this IComponentHolder_Core<ComponentsKeys> holder, SerializedDictionary<ComponentsKeys, Component> holderDictionnary, ComponentsKeys component) 
                                                                where ExpectedType : Component
        {
            return holderDictionnary[component] as ExpectedType;
        }

        public static void HolderChangeComponent<ComponentsKeys, ExpectedType>(this IComponentHolder_Core<ComponentsKeys> holder, SerializedDictionary<ComponentsKeys, Component> holderDictionnary, ComponentsKeys componentType, ExpectedType component, Action<ComponentChangeEventArgs<ComponentsKeys>> onChangeAction) 
                                                           where ExpectedType : Component
        {
            if (!holderDictionnary.ContainsKey(componentType))
                holderDictionnary.Add(componentType, component);
            else
                holderDictionnary[componentType] = component;

            onChangeAction?.Invoke(new ComponentChangeEventArgs<ComponentsKeys>(componentType, component));
        }
    }
}
