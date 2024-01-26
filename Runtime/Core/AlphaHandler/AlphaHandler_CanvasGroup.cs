using UnityEngine;

namespace StdNounou.Core
{
    [RequireComponent(typeof(CanvasGroup))]
    public class AlphaHandler_CanvasGroup : AlphaHandler
    {
        [field: SerializeField] public CanvasGroup Target { get; private set; }

        [System.Serializable]
        private struct S_GroupState
        {
            public S_GroupState(bool interactable, bool raycastTarget, bool ignoreParentGroup)
            {
                this.Interactable = interactable;
                this.RaycastTarget = raycastTarget;
                this.IgnoreParentGroups = ignoreParentGroup;
            }
            [field: SerializeField] public bool Interactable { get; private set; }
            [field: SerializeField] public bool RaycastTarget { get; private set; }
            [field: SerializeField] public bool IgnoreParentGroups { get; private set; }
        }

        [SerializeField] private S_GroupState stateWhenVisible = new S_GroupState(true, true, false);
        [SerializeField] private S_GroupState stateWhenInvisible = new S_GroupState(false, false, false);

        private void Reset()
        {
            Target = this.GetComponent<CanvasGroup>();
        }

        public override float GetAlpha()
            => Target.alpha;

        public override LTDescr LeanAlpha(float alpha, float time)
        {
            LTDescr tween = Target.LeanAlpha(alpha, time).setOnComplete(SetCanvasState);
            return tween;
        }

        public override void SetAlpha(float alpha)
        {
            Target.alpha = alpha;
            SetCanvasState();
        }

        /// <summary>
        /// <br> Sets the canvas group Interactable, RaycastTarget and IgnoreParentsGroup depending on it's current alpha. </br>
        /// <br> if alpha is at 0, sets at "<see cref="stateWhenInvisible"/>". Else, sets at "<see cref="stateWhenVisible"/>". </br>
        /// </summary>
        private void SetCanvasState()
            => SetCanvasState(Target.alpha == 0 ? stateWhenInvisible : stateWhenVisible);
        private void SetCanvasState(S_GroupState groupState)
        {
            Target.interactable = groupState.Interactable;
            Target.blocksRaycasts = groupState.RaycastTarget;
            Target.ignoreParentGroups = groupState.IgnoreParentGroups;
        }
    } 
}
