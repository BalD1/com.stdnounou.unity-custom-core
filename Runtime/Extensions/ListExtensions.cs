using System.Collections.Generic;
using UnityEngine;

namespace StdNounou
{
    public static class ListExtensions
    {
        public static int RandomIndex<T>(this List<T> list) => Random.Range(0, list.Count);

        public static T RandomElement<T>(this List<T> list)
        {
            if (list.Count <= 0) return default(T);
            return list[Random.Range(0, list.Count)];
        }

        public static T LastElement<T>(this List<T> list)
            => list[list.Count - 1];
        public static int LastIndex<T>(this List<T> list)
            => list.Count - 1;
    }

}