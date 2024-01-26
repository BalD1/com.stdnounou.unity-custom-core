using UnityEngine.UI;
using UnityEngine;

namespace StdNounou.Core
{
    [RequireComponent(typeof(Image))]
    public class AlphaHandler_Image : AlphaHandler
    {
        [field: SerializeField] public Image Target {  get; private set; }

        private void Reset()
        {
            Target = this.GetComponent<Image>();
        }

        public override float GetAlpha()
            => Target.color.a;

        public override LTDescr LeanAlpha(float alpha, float time)
            => Target.LeanAlpha(alpha, time);

        public override void SetAlpha(float alpha)
            => Target.SetAlpha(alpha);
    } 
}
