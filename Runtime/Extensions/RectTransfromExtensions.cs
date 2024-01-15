using UnityEngine;

namespace StdNounou
{
    public static class RectTransformExtensions
    {
        public static void SetOffset(this RectTransform rt, float left, float right, float top, float bottom)
        {
            SetOffset(rt, new Vector2(left, bottom), new Vector2(-right, -top));
        }
        public static void SetOffset(this RectTransform rt, Vector2 min, Vector2 max)
        {
            rt.offsetMin = min;
            rt.offsetMax = max;
        }

        public static void SetAnchors(this RectTransform rt, Vector2 min, Vector2 max)
        {
            rt.anchorMin = min;
            rt.anchorMax = max;
        }

        public static void SetAnchorsAndOffset(this RectTransform rt, Vector2 offsetMin, Vector2 offsetMax, Vector2 anchorsMin, Vector2 anchorsMax)
        {
            SetAnchors(rt, anchorsMin, anchorsMax);
            SetOffset(rt, offsetMin, offsetMax);
        }

        public static void SetLeft(this RectTransform rt, float left)
        {
            rt.offsetMin = new Vector2(left, rt.offsetMin.y);
        }

        public static void SetRight(this RectTransform rt, float right)
        {
            rt.offsetMax = new Vector2(-right, rt.offsetMax.y);
        }

        public static void SetTop(this RectTransform rt, float top)
        {
            rt.offsetMax = new Vector2(rt.offsetMax.x, -top);
        }

        public static void SetBottom(this RectTransform rt, float bottom)
        {
            rt.offsetMin = new Vector2(rt.offsetMin.x, bottom);
        }
    } 
}