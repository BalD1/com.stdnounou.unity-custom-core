using StdNounou.Core;
using UnityEngine;

namespace StdNounou.Samples.HolderComponent
{
	public class Creature : MonoBehaviour
	{
		[SerializeField] private SimpleComponentHolder componentHolder;
        [SerializeField] private AudioClip[] audiosToPlay;

        public void TryChangeRendererColor()
        {
            E_HolderResult res = componentHolder.HolderTryGetComponent(E_ComponentTypes.Renderer, out SpriteRenderer renderer);

            if (res != E_HolderResult.Success) return;
            if (renderer.color == Color.white)
                renderer.color = Color.red;
            else
                renderer.color = Color.white;
        }

        public void TryAddForce()
        {
            E_HolderResult res = componentHolder.HolderTryGetComponent(E_ComponentTypes.Rigibody, out Rigidbody2D body);

            if (res != E_HolderResult.Success) return;
            body.AddForce(Vector2.up * 10);
        }

        public void TryPlayAudio()
        {
            E_HolderResult res = componentHolder.HolderTryGetComponent(E_ComponentTypes.AudioPlayer, out AudioSource source);

            if (res != E_HolderResult.Success) return;
            source.PlayOneShot(audiosToPlay.RandomElement());
        }
    } 
}
