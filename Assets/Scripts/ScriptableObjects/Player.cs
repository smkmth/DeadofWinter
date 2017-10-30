using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
[CreateAssetMenu( menuName = "Assets/Players")]
class Player : ScriptableObject {

	public ItemList PlayerInv;
	public CharacterList PlayerCharacters;
	public string Name;

}
