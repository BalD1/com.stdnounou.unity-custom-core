using System;

namespace StdNounou
{
	public static class EnumExtensions
	{
        public static int ToInt<T>(T enumValue) where T : Enum
        {
            return Convert.ToInt32(enumValue);
        }

        public static T FromInt<T>(int intValue) where T : Enum
        {
            return (T)Enum.ToObject(typeof(T), intValue);
        }
    } 
}
