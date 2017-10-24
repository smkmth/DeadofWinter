using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
