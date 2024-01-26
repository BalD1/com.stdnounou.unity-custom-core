using UnityEngine;

namespace StdNounou.Core
{
	public static class ResourcesObjectLoader
	{
        public const string PREFABS_HOLDER_PATH = "Assets/";
		public const string PREFABS_UI_HOLDER = "UIPrefabs";
		public const string PREFABS_AUDIO_HOLDER = "AudioPrefabs";

		private static SO_PrefabsHolder uiPrefabsHolder;
		
        public static SO_PrefabsHolder GetUIPrefabsHolder()
			=> SetOrGetHolder(PREFABS_UI_HOLDER, ref uiPrefabsHolder);

		public static T SetOrGetHolder<T>(string holderID, ref T holder)
			where T : UnityEngine.Object
		{
			if (holder != null) return holder;
			holder = Resources.Load<T>(PREFABS_HOLDER_PATH + holderID);
			return holder;
        }
	} 
}
