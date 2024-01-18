using UnityEngine;

namespace StdNounou.Core
{
	[CreateAssetMenu(fileName = "New KeyContainer", menuName = "StdNounou/Scriptables/KeyContainer")]
	public class SO_KeyContainer : ScriptableObject
	{
		[field: SerializeField] public string Key { get; private set; }
	}  
}