using StdNounou.Core.Editor;
using System;
using TMPro;
using UnityEngine.AddressableAssets;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace StdNounou.Core
{
    [RequireComponent(typeof(TextMeshPro))]
    public class TextPopup : MonoBehaviour
    {
        [SerializeField] private TextMeshPro textMesh;

        [SerializeField, ReadOnly] private float currentLifetime;
        [SerializeField, ReadOnly] private SO_TextPopupData textPopupData;

        public event Action<TextPopup> OnEnd;

        private Vector3 targetPosition;
        private int listIndex = 1;

        private static int layerIndex = 0;

        private static ObjectPool<TextPopup> pool;
        private static TextPopup TextPopup_PF;

        private void Reset()
        {
            textMesh = this.GetComponent<TextMeshPro>();
        }

        public static TextPopup Create(string text, Vector2 pos, SO_TextPopupData textPopupData, Transform parent = null)
        {
            if (pool == null)
            {
                if (TextPopup_PF == null)
                {
                    CustomLogger.LogError(typeof(TextPopup), "TextPopupPF was null. Please ensure the prefab was set by calling \"SetPrefab\" before trying to create a new TextPopup.");
                    return null;
                }
                pool = new ObjectPool<TextPopup>(
                        _createAction: () => TextPopup_PF.Create(pos),
                        _parentContainer: parent
                        );
            }

            TextPopup next = pool.GetNext(pos);
            next.Setup(text, textPopupData, parent);
            return next;
        }

        public static void SetPrefab(TextPopup popupPF)
        {
            TextPopup_PF = popupPF;
        }
        public static void SetPrefab(GameObject popupPF)
        {
            TextPopup tp = popupPF.GetComponent<TextPopup>();
            if (tp == null)
            {
                CustomLogger.LogError(typeof(TextPopup), "No TextPopup script was found on the given prefab.");
                return;
            }
            TextPopup_PF = tp;
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
            TrySetTMPOptions(textPopupData);

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

        private void TrySetTMPOptions(SO_TextPopupData data)
        {
            if (this.textPopupData == data) return;
            this.textMesh.SetData(data.TMPData);
        }

        public void SetListIndex(int index)
            => this.listIndex = index;

        public void Kill()
        {
            layerIndex--;
            OnEnd?.Invoke(this);
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