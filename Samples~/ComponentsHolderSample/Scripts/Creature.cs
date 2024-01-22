using StdNounou.Core.ComponentsHolder;
using UnityEngine;

namespace StdNounou.Core.Samples
{
    [RequireComponent(typeof(ComponentHolder_String), typeof(ComponentHolder_Key), typeof(ComponentHolder_Enum))]
	public class Creature : MonoBehaviour
	{
		[SerializeField] private ComponentHolder_String simpleComponentHolder;
        [SerializeField] private ComponentHolder_Key keyComponentHolder;
		[SerializeField] private ComponentHolder_Enum enumComponentHolder;
        [SerializeField] private AudioClip[] audiosToPlay;

        private void Reset()
        {
            simpleComponentHolder = this.GetComponent<ComponentHolder_String>();
            keyComponentHolder = this.GetComponent<ComponentHolder_Key>();
            enumComponentHolder = this.GetComponent<ComponentHolder_Enum>();
        }

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
            E_HolderResult res = keyComponentHolder.HolderTryGetComponent(KeysHolder.GetRigidBody, out Rigidbody2D body);

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
