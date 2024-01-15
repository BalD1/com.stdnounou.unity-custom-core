using System;

namespace StdNounou.Core
{
	public static class ComponentHolderExtensions
	{
		public static void LogError<EnumType, ComponentType>(this IComponentHolderBase<EnumType> holder, E_HolderResult result, ComponentType compType)
							  where EnumType : Enum
							  where ComponentType : Enum
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
	} 
}
