using UnityEngine;
using UnityEngine.UI;

namespace StdNounou.Core
{
    public static class ImageExtensions
    {
        public static void SetAlpha(this Image image, float alpha)
        {
            if (image == null) return;

            Color c = image.color;
            c.a = alpha;
            image.color = c;
        }
        public static void SetAlpha(this RawImage image, float alpha)
        {
            if (image == null) return;

            Color c = image.color;
            c.a = alpha;
            image.color = c;
        }

        public static LTDescr LeanAlpha(this Image image, float alphaGoal, float time)
        {
            return LeanTween.alpha(image.rectTransform, alphaGoal, time);
        }
        public static LTDescr LeanAlpha(this RawImage image, float alphaGoal, float time)
        {
            return LeanTween.alpha(image.rectTransform, alphaGoal, time);
        }
    } 
}