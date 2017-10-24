using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemActions : MonoBehaviour{

	/// <summary>
	/// This is the class which handles any action relating to items.
	///  
	/// it should have references to all the item decks in the game
	/// 
	/// at this point, its only function is CheckToSearchItems, which needs
	/// a reference to a deck, (attached on the inspector in each case), the 
	/// location of the piece wanting to search, and for fun and reference, 
	/// the name of that piece. 
	/// </summary>

	private Movement _Movement;
	private string deckName;
	private PlayerControl _PlayerControl;
	[Tooltip("Put PlaceItems list here!")]
	public ItemList GroceryStoreItems;	//the list of items in the grocery store
	public ItemList HospitalItems;
	public ItemList GasStationItems;
	[Tooltip("Put Display Items List here!")]
	public ItemList DisplayItems; //this passes the items to be shown to the player
										// when they perform a search on a deck.
	public GameState _GameState;
	public GameObject objectUsedAgainst;
	public Weapon weaponBeingUsed;
	private UnityAction selectedPieceListener;
	public bool itemNotified;
	public Item ItemBeingUsed;


	void Awake(){
		selectedPieceListener = new UnityAction (useItem);
	}

	void OnEnable(){
		EventManager.StartListening ("PieceSelected", selectedPieceListener);
	}

	void OnDisable(){
		EventManager.StopListening ("PieceSelected", selectedPieceListener);
	}

	public void Start(){
		_Movement = gameObject.GetComponent<Movement>();
		_GameState = gameObject.GetComponent<GameState> ();
		_PlayerControl = gameObject.GetComponent<PlayerControl> ();
		DisplayItems.itemList.Clear ();
															//this just empties the display items list, as 
																		//it should always be empty unless the character is 
																		//actually searching

	}


	public void CheckToSearchItems(GameObject deck, string lastpiecelocation, string lastpiecename){
		///<summary>>
		/// Checks to see if player can search items (GameObject (a deck), string (a location), string (a name))
		/// </summary>
	

		//the player control script passes this script the piece location, and the deck itself passes the 
		//deck location, which is set to the name of the place, so this script can just compare the two
		//to find out if the player can search the deck. 

		//when this happens, some of the items from the full deck are passed to the DisplayItems function
		//and more happen later on.

		deckName = deck.GetComponent<ItemDeck>().deckLocation;
		if (deckName == lastpiecelocation) {
			Debug.Log (lastpiecename +" is searching the "+ deckName +" they are at the "+ lastpiecelocation);
			if (deckName == "GroceryStore") {
				if (GroceryStoreItems.itemList.Count > 1) {

					DisplayItems.itemList.Add (GroceryStoreItems.itemList [0]);
					Debug.Log (DisplayItems.itemList.Count + DisplayItems.itemList [0].itemName);

					
					DisplayItems.itemList.Clear ();
				} else {
					Debug.Log ("Grocery Store is empty");
				}


			} else if (deckName == "Hospital") {
				if (HospitalItems.itemList.Count > 1) {
					
					DisplayItems.itemList.Add (HospitalItems.itemList [0]);
					Debug.Log (DisplayItems.itemList.Count + DisplayItems.itemList [0].itemName);
					DisplayItems.itemList.Clear ();
				}
				else {
					Debug.Log ("Hospital is empty");
					}
			} else if (deckName == "GasStation") {
				if (GasStationItems.itemList.Count > 1) {
					DisplayItems.itemList.Add (GasStationItems.itemList [0]);
					Debug.Log (DisplayItems.itemList.Count + DisplayItems.itemList [0].itemName);
					DisplayItems.itemList.Clear ();
				} else {
					Debug.Log ("GasStation is empty");
				}
			}


		}

		
	}
	public void SetUpItem (Item itemBeingUsed){
		
		Debug.Log ("Item is being used" + itemBeingUsed.itemName);
		_GameState.gamestate = 2;
		Debug.Log (_GameState.gamestate);
		ItemBeingUsed = itemBeingUsed;
		_PlayerControl.selectAPiece = true;



	}

	void useItem(){
		
		Debug.Log (_PlayerControl.selectedItemPiece + ItemBeingUsed.itemName);
	}
}
