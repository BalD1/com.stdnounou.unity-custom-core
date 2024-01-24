using StdNounou.Core.ComponentsHolder;
using UnityEngine;

namespace StdNounou.Core.Samples
{
    [RequireComponent(typeof(BaseComponentHolder))]
	public class Creature : MonoBehaviour
	{
        [SerializeField] private AudioClip[] audiosToPlay;
        [SerializeField] private BaseComponentHolder baseComponentHolder;

        private void Reset()
        {
            baseComponentHolder = this.GetComponent<BaseComponentHolder>();
        }

        public void TryChangeRendererColor()
        {
            // Using a static keys holder
            E_HolderResult res = baseComponentHolder.HolderTryGetComponent(E_ComponentsKeys.Renderer, out SpriteRenderer renderer);

            if (res != E_HolderResult.Success) return;
            if (renderer.color == Color.white)
                renderer.color = Color.red;
            else
                renderer.color = Color.white;
        }

        public void TryAddForce()
        {
            E_HolderResult res = baseComponentHolder.HolderTryGetComponent(E_ComponentsKeys.Rigidbody, out Rigidbody2D body);

            if (res != E_HolderResult.Success) return;
            body.AddForce(Vector2.up * 10);
        }

        public void TryPlayAudio()
        {
            E_HolderResult res = baseComponentHolder.HolderTryGetComponent(E_ComponentsKeys.AudioPlayer, out AudioSource source);

            if (res != E_HolderResult.Success) return;
            source.PlayOneShot(audiosToPlay.RandomElement());
        }
    }
}
