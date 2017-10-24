using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour {

	//the piece class handles the actual physical presence of the character, a character object
	//handles its stats. 

	public string currentLocation; //the current location is passed to the player piece from the 
									//places he visits not set here
	public string characterName;	//this is set by the pieces character object
								
	//private PlayerControl _PlayerControl;

	public Character _Character;	//this is a generic reference to whatever character is set to 
									//this object. 
	public InventoryGui _InventoryGui;

	public int Noise;

	public void Start(){
		
		//_PlayerControl = GameObject.Find("GameFlow").GetComponent<PlayerControl>();
		_InventoryGui = GameObject.Find ("CharInventory").GetComponent<InventoryGui>();
		Debug.Log (this.gameObject.name); 

			
		characterName = _Character.Name;
		Debug.Log ("Itesm number" + _Character.Inv.itemList.Count);
		Noise = _Character.BaseNoise + _Character.Inv.itemList.Count;

		if (_Character.bodyEquip == true) {
			int tempvalue = _Character.bodyEquip.ArmourValue;
			_Character.Health += tempvalue;
		
		}
	}

	public string MyCurrentLocation(){
		return currentLocation;
	}

	public string MyName(){
		return characterName;
	}

	public void CheckInventory(){
		if (_Character.Inv.itemList.Count > 0) {
			Debug.Log (_Character.Inv.itemList.Count);
			_InventoryGui.DisplayItems (_Character);
		} else { 
			Debug.Log("no Items");
		}
	
	}




	
	


}
