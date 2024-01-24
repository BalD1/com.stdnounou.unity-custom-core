using StdNounou.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New TextPopup Prefab", menuName = "StdNounou/Scriptables/FX/Text Prefab Data")]
public class SO_TextPopupPrefab : ScriptableObject
{
    [field: SerializeField] public string ID { get; private set; }
    [field: SerializeField] public TextPopup PopupPrefab { get; private set; }
}