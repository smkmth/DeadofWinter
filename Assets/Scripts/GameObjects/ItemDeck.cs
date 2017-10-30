using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// just tells the world what location the deck is in
/// variables
/// string deckLocation returns a string of the location the deck is in
/// </summary>
public class ItemDeck : MonoBehaviour {

	public GameObject deckLocationObject;
	public string deckLocation;
	public ItemList GroceryStore;


	// Use this for initialization
	void Start () {
		deckLocation = deckLocationObject.name;
	}
		
}
