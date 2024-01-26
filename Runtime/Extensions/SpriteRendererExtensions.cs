using UnityEngine;

namespace StdNounou.Core
{
    public static class SpriteRendererExtensions
    {
        public static void SetAlpha(this SpriteRenderer spriteRenderer, float alpha)
        {
            Color c = spriteRenderer.color;
            c.a = alpha;
            spriteRenderer.color = c;
        }

        public static LTDescr LeanAlpha(this SpriteRenderer spriteRenderer, float alphaGoal, float time)
        {
            return LeanTween.alpha(spriteRenderer.gameObject, alphaGoal, time);
        }

        public static LTDescr LeanColor(this SpriteRenderer spriteRenderer, Color colorGoal, float time)
        {
            return LeanTween.color(spriteRenderer.gameObject, colorGoal, time);
        }
    } 
}
