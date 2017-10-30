using UnityEngine;
using System.Collections;
using UnityEditor;

public class CreateCharacterList {
	[MenuItem("Assets/Create/CreateCharacterList")]
	public static CharacterList Create()
	{
		CharacterList asset = ScriptableObject.CreateInstance<CharacterList>();

		AssetDatabase.CreateAsset (asset, "Assets/ItemList.asset");
		AssetDatabase.SaveAssets ();
		return asset;


	}
}