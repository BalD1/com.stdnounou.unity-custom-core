using UnityEngine;

namespace StdNounou
{
    public static class ArrayExtensions
    {
        public static int RandomIndex<T>(this T[] array) => Random.Range(0, array.Length);

        public static T RandomElement<T>(this T[] array)
        {
            if (array.Length <= 0) return default(T);
            return array[Random.Range(0, array.Length)];
        }

        public static bool NotNullOrEmpty<T>(this T[] array)
            => array != null && array.Length != 0;

    } 
}