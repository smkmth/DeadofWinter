using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
[CreateAssetMenu( menuName = "Assets/Item/Generic", order =2)]//creates a new editor assets/create menu called character data 
public class Item : ScriptableObject
{
	public Sprite sprite;
	public string itemName = "NewItem";
	public string itemDescription = "NewDescription";
	public string itemType = "NewType"; //Weapon, Equipment, Food, Tool,   
	public string itemAction = "NewAction";
	public bool isStackable = false;
	public bool destroyOnUse = false;
	public float weight = 0;
	public Texture2D itemIcon = null;
	public Rigidbody itemObject = null;
	public bool itemUsed = false;

	

}
