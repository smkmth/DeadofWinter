using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This class is the physical game piece, it is attached to every game piece, and it has no 
/// specific data. instead it pulls the data from a scriptable object called character, and 
/// handles what happens to that data. Piece has the following methods 
/// MyCurrentLocation() which returns the pieces current location
/// MyName() which returns the pieces name
/// CheckInventory() which gives the inventoryGUI class a character scriptable object, whih has an inv 
/// ClearInventory() which runs the clear items code good for de-selecting 
/// TakeDamage(damage) which accepts an int, and removes that from Health
/// 
/// </summary>
public class Piece : MonoBehaviour {


	public string currentLocation; 							//the current location is passed to the player piece from the 
															//places he visits not set here
	public string characterName;							//this is set by the pieces character scriptable object
	public int Health;										//also set by character scriptalbe object

	//private PlayerControl _PlayerControl;

	public Character _Character;	//this is a generic reference to whatever character is set to 
									//this object. 
	public InventoryGui _InventoryGui;
<<<<<<< HEAD
	public CharStatsGui _CharStatsGui;
=======
	public CharStatsGui _CharStatsGUI;
>>>>>>> master

	public int Noise;

	public bool hasMoved;

	public void Start(){
		
		//_PlayerControl = GameObject.Find("GameFlow").GetComponent<PlayerControl>();
		_InventoryGui = GameObject.Find ("CharInventory").GetComponent<InventoryGui>();
<<<<<<< HEAD
		_CharStatsGui = GameObject.Find ("CharStats").GetComponent<CharStatsGui> ();

=======
		_CharStatsGUI = GameObject.Find ("CharStats").GetComponent<CharStatsGui>();
>>>>>>> master
		//Debug.Log (this.gameObject.name); 
		hasMoved = false;
		Health = _Character.Health;	
		characterName = _Character.Name;
		//Debug.Log ("Itesm number" + _Character.Inv.itemList.Count);
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
			_InventoryGui.DisplayItems (_Character);
		} else { 
			Debug.Log("no Items");
		}
			
	}

	public void ClearInventory(){
		_InventoryGui.ClearItems ();
	}

	public void CheckStats(){
<<<<<<< HEAD
		
		_CharStatsGui.DisplayStats (_Character);

=======
		_CharStatsGUI.DisplayStats (_Character);
	}

	public void ClearStats(){
		_CharStatsGUI.ClearStats ();
>>>>>>> master
	}

	public void TakeDamage(int damage){

		Health -= damage;
		Debug.Log (characterName + " has taken " + damage + " damage, his health is now  " + Health);
	}

	void Update(){

		if (Health <= 0) {

			Destroy (gameObject);


		}

	}


	


}
