using UnityEngine;

namespace StdNounou.Core
{
    public abstract class AlphaHandler : MonoBehaviour
    {
        public abstract void SetAlpha(float alpha);
        public abstract float GetAlpha();
        public abstract LTDescr LeanAlpha(float alpha, float time);
    } 
}
