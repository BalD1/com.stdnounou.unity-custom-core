using System;
using TMPro;
using UnityEngine;
using System.Collections.Generic;

namespace StdNounou.Core
{
    [RequireComponent(typeof(TextMeshPro))]
    public class TextPopup : MonoBehaviour
    {
        [SerializeField] private TextMeshPro textMesh;

        private float currentLifetime;
        private SO_TextPopupData textPopupData;

        public event Action<TextPopup> OnEnd;

        private Vector3 targetPosition;
        private int listIndex = 1;

        private SO_TextPopupPrefab pf;

        private static int layerIndex = 0;

        private static Dictionary<string, ObjectPool<TextPopup>> pools;

        private void Reset()
        {
            textMesh = this.GetComponent<TextMeshPro>();
        }

        public static TextPopup Create(string text, Vector2 pos, SO_TextPopupData textPopupData, Transform parent = null)
        {
            if (pools == null) pools = new Dictionary<string, ObjectPool<TextPopup>>();
            if (!pools.TryGetValue(textPopupData.TMPPrefab.ID, out ObjectPool<TextPopup> pool))
            {
                pool = new ObjectPool<TextPopup>(_createAction: () => textPopupData.TMPPrefab.PopupPrefab.Create(),
                                                 _parentContainer: null);
                pools.Add(textPopupData.TMPPrefab.ID, pool);
            }

            TextPopup next = pool.GetNext(pos);
            next.Setup(text, textPopupData, parent);
            return next;
        }

        private void Update()
        {
            ProcessLifetime();
            ProcessMovements();
            ProcessFade();
        }

        private void ProcessLifetime()
        {
            if (currentLifetime > 0)
            {
                currentLifetime -= Time.deltaTime * listIndex;
                return;
            }
            Kill();
        }

        private void ProcessMovements()
        {
            if (VectorUtils.Vector2ApproximatlyEquals(this.transform.position, targetPosition)) return;
            this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, Time.deltaTime * textPopupData.TravelSpeed);
        }

        private void ProcessFade()
        {
            float currentLifetimePercentage = currentLifetime / textPopupData.Lifetime * 100;
            if (currentLifetimePercentage >= textPopupData.AlphaFadeLifetimeStart) return;

            this.textMesh.alpha = Mathf.Lerp(textMesh.alpha, 0, Time.deltaTime * textPopupData.FadeSpeed * listIndex);
        }

        public void Setup(string text, SO_TextPopupData textPopupData, Transform parent, int listIndex = 1)
        {
            this.pf = textPopupData.TMPPrefab;

            this.listIndex = listIndex;
            textMesh.alpha = 1;
            textMesh.SetText(text);

            this.textPopupData = textPopupData;

            currentLifetime = textPopupData.Lifetime;
            targetPosition = textPopupData.TargetPosition + this.transform.position;

            this.textMesh.sortingOrder = ++layerIndex;
            this.textMesh.color = textPopupData.TextColor;
            this.transform.localScale = textPopupData.Scale;
        }

        public void SetListIndex(int index)
            => this.listIndex = index;

        public void Kill()
        {
            layerIndex--;
            OnEnd?.Invoke(this);
            pools.TryGetValue(pf.ID, out ObjectPool<TextPopup> pool);
            pool.Enqueue(this);
        }

        public void AddToTargetPosition(Vector3 pos)
        {
            targetPosition += pos;
        }

        private void OnDestroy()
        {
            OnEnd?.Invoke(this);
        }
    } 
}