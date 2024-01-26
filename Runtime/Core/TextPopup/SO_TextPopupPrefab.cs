using UnityEngine;

namespace StdNounou.Core
{
	[CreateAssetMenu(fileName = "New TextPopup Prefab", menuName = "StdNounou/Scriptables/FX/Text Prefab Data", order = 110)]
	public class SO_TextPopupPrefab : ScriptableObject
	{
		[field: SerializeField] public string ID { get; private set; }
		[field: SerializeField] public TextPopup PopupPrefab { get; private set; }
	} 
}