using UnityEngine;

namespace StdNounou.Core
{
    [CreateAssetMenu(fileName = "New TextPopupData", menuName = "StdNounou/Scriptables/FX/TextData", order = 110)]
    public class SO_TextPopupData : ScriptableObject
    {
        [field: SerializeField] public float TravelSpeed { get; private set; } = 5;
        [field: SerializeField] public float FadeSpeed { get; private set; } = 5;
        [field: SerializeField] public float Lifetime { get; private set; } = 1;
        [field: SerializeField] public Vector3 TargetPosition { get; private set; }
        [field: SerializeField] public Color TextColor { get; private set; }
        [field: SerializeField] public Vector3 Scale { get; private set; } = new Vector3(1, 1, 1);

        [field: SerializeField, Range(0, 100)] public float AlphaFadeLifetimeStart { get; private set; } = 50;

        [field: SerializeField] public SO_TextPopupPrefab TMPPrefab { get; private set; }
    }
}