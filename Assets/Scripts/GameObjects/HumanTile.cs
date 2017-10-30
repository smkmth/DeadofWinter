using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// this class attaches to the human tiles i have in each location, and simply tells 
/// anyone who wants to know what location it is in, and if the current tile is occupied
/// variables
/// bool occupiedTile returns true if tile is occupied by a Player
/// string tileLocation returns a string of with the location of a tile
/// </summary>
public class HumanTile : MonoBehaviour {
	public bool occupiedTile;

	public GameObject tileLocationObject;

	public string tileLocation;

	public void Start(){

		tileLocation = tileLocationObject.name;

	}

	void OnTriggerEnter(Collider target){
		if (target.tag == "Player") {
			occupiedTile = true;

		}
	
	}
	void OnTriggerExit(Collider target){
		if (target.tag == "Player") {
			occupiedTile = false;

		}
	}


}
