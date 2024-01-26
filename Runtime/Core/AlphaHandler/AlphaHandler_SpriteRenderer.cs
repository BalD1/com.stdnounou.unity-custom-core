using UnityEngine;

namespace StdNounou.Core
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class AlphaHandler_SpriteRenderer : AlphaHandler
    {
        [field: SerializeField] public SpriteRenderer Target { get; private set; }

        private void Reset()
        {
            Target = this.GetComponent<SpriteRenderer>();
        }

        public override float GetAlpha()
            => Target.color.a;

        public override LTDescr LeanAlpha(float alpha, float time)
            => Target.LeanAlpha(alpha, time);

        public override void SetAlpha(float alpha)
            => Target.SetAlpha(alpha);
    } 
}