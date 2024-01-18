using StdNounou.Core;
using StdNounou.Core.ComponentsHolder;
using UnityEngine;

namespace StdNounou.Samples.HolderComponent
{
	public class Creature : MonoBehaviour
	{
		[SerializeField] private SimpleComponentHolder simpleComponentHolder;
		[SerializeField] private EnumComponentsHolder enumComponentHolder;
        [SerializeField] private AudioClip[] audiosToPlay;

        public void TryChangeRendererColor()
        {
            // Using a static keys holder
            E_HolderResult res = simpleComponentHolder.HolderTryGetComponent(ComponentsKeys.Renderer, out SpriteRenderer renderer);

            if (res != E_HolderResult.Success) return;
            if (renderer.color == Color.white)
                renderer.color = Color.red;
            else
                renderer.color = Color.white;
        }

        public void TryAddForce()
        {
            E_HolderResult res = simpleComponentHolder.HolderTryGetComponent(ComponentsKeys.Rigidbody, out Rigidbody2D body);

            if (res != E_HolderResult.Success) return;
            body.AddForce(Vector2.up * 10);
        }

        public void TryPlayAudio()
        {
            E_HolderResult res = enumComponentHolder.HolderTryGetComponent(E_ComponentsKeys.AudioPlayer, out AudioSource source);

            if (res != E_HolderResult.Success) return;
            source.PlayOneShot(audiosToPlay.RandomElement());
        }
    }
}
