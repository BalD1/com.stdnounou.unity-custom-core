using TMPro;
using UnityEngine;

namespace StdNounou.Core
{
    [CreateAssetMenu(fileName = "New TextPopupData", menuName = "StdNounou/Scriptables/TMP/Data")]
	public class SO_TMPData : ScriptableObject
    {
        [field: SerializeField] public TMP_FontAsset Font { get; private set; }
        [field: SerializeField] public FontStyles FontStyles { get; private set; } = FontStyles.Normal;
        [field: SerializeField] public float FontSize { get; private set; } = 5;
        [field: SerializeField] public bool UseColorGradiant { get; private set; } = false;
        [field: SerializeField] public TMP_ColorGradient Gradiant { get; private set; }
        [field: SerializeField] public float CharacterSpacing { get; private set; } = -10;
        [field: SerializeField] public float LineSpacing { get; private set; }
        [field: SerializeField] public float WordSpacing { get; private set; }
        [field: SerializeField] public float ParagraphSpacing { get; private set; }
        [field: SerializeField] public HorizontalAlignmentOptions HorizontalAlignmentOptions { get; private set; } = HorizontalAlignmentOptions.Center;
        [field: SerializeField] public VerticalAlignmentOptions VerticalAlignmentOptions { get; private set; } = VerticalAlignmentOptions.Middle;
    } 
}