using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This is the class which handles any action relating to items.
///  
/// it should have references to all the item lists in the world
/// methods
/// CheckToSearchItems() checks what deck the player is trying to search and adds items from the item 
/// deck to a list called display items, which in the future will hopefully let a player choose which items
/// they want to pick up.
/// SetUpItem(Item) is called by the inventorygui class, tells the game that an item is being used and what that item is
/// useItem() uses an item set up by setupitem
/// weaponMeleeAttack(Item item being used, GameObject object item used against) the only set up method for items at 
/// the moment, this method makes an item attack another player. later thier will be loads of methods, for each item 
/// that could be used.
/// </summary>
public class ItemActions : MonoBehaviour{


	private GameState _GameState; 								//a reference to the gamestate script - set up later
	private Movement _Movement;									//a reference to the movement script - set up laster
	private PlayerControl _PlayerControl;						//a reference to the player control script - set up later


	[Tooltip("Put PlaceItems list here!")]														//Item lists are a custom scriptable object which can be created like any other asset
																								//they are a list of items. You drag and drop into place in the inspector.
	public ItemList GroceryStoreItems;															//the list of items in the grocery store
	public ItemList HospitalItems;																//the list of items in the hospital
	public ItemList GasStationItems;															//the list of items in the gas station

	[Tooltip("Put Display Items List here!")]
	public ItemList DisplayItems; 									//this passes the items to be shown to the player when they perform a search on a deck.

	private UnityAction selectedPieceListener; 					//a listener waiting for a call from player control when the player chooses an item to select (see Unity Actions)
	private Item ItemBeingUsed;									//a reference to a item, a custom scriptable object i have made for each item in the game 
	private Piece _TargetPerson;								//a reference to the piece script of a gameobject we are targeting with an item.
	private string deckName;									//a string which pulls the name of the deck the player might be searching



	void Awake(){
																				//these next few lines of code are simply setting up the listener in player control which tells this
																				//game object when a target for an item is selected. 
		selectedPieceListener = new UnityAction (useItem);
	}

	void OnEnable(){
		EventManager.StartListening ("PieceSelected", selectedPieceListener);
	}

	void OnDisable(){
		EventManager.StopListening ("PieceSelected", selectedPieceListener);
	}

	public void Start(){
																				//here we are telling this object where to find the pieces we established refrences to earlier

		_Movement = gameObject.GetComponent<Movement>();						//as the itemActions script is actually located on the same gameobject as the movement component 
		_GameState = gameObject.GetComponent<GameState> ();						//and the gamestate component, we can just pull those components and tie the references. if we need
		_PlayerControl = gameObject.GetComponent<PlayerControl> ();				//to access these components for methods or data, we can just use the reference name eg _PlayerControl
		DisplayItems.itemList.Clear ();								//this empties the 'display items list', as it should always be empty unless the character is actually searching
	}


	public void CheckToSearchItems(GameObject deck, string lastpiecelocation, string lastpiecename){
		///<summary>
		/// Checks to see if player can search items (GameObject (a deck), string (a location), string (a name))
		/// </summary>
	

																						//the player control script passes this script the piece location, and the deck itself passes the 
																						//deck location, which is set to the name of the place, so this script can just compare the two
																						//to find out if the player can search the deck. 

																						//when this happens, some of the items from the full deck are passed to the DisplayItems function
																						//and more happen later on.
		
		deckName = deck.GetComponent<ItemDeck>().deckLocation;							//tell the game object where to get the name of the deck
		if (deckName == lastpiecelocation) {											//lastpiecelocation is given in the parameters of the method, when the method is called, this
																						//parameter is set
																														
			Debug.Log (lastpiecename +" is searching the "+ deckName +" they are at the "+ lastpiecelocation);	//debug logs to tell us it worked
			if (deckName == "GroceryStore") {
				if (GroceryStoreItems.itemList.Count >= 1) {													//check if their actually is anything in that item deck

					DisplayItems.itemList.Add (GroceryStoreItems.itemList [0]);
					Debug.Log ("Item"+DisplayItems.itemList.Count + DisplayItems.itemList [0].itemName);		//this is currently actually functionally useless - to be implemented
																												//later, it just prints the displayed items to a debug window, before
					DisplayItems.itemList.Clear ();																//clearing the deck. Later i want a certain amount of items to apear
																												//and the player to select which ones he wants to take.
				} else {
					Debug.Log ("Grocery Store is empty");
				}


			} else if (deckName == "Hospital") {
				if (HospitalItems.itemList.Count >= 1) {
					
					DisplayItems.itemList.Add (HospitalItems.itemList [0]);
					Debug.Log (DisplayItems.itemList.Count + DisplayItems.itemList [0].itemName);
					DisplayItems.itemList.Clear ();
				}
				else {
					Debug.Log ("Hospital is empty");
					}
			} else if (deckName == "GasStation") {
				if (GasStationItems.itemList.Count >= 1) {
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
		///<summary>
		/// this method is called in the inventorygui code,
		/// where the item the player clicked on is the itemBeingUsed.
		/// this method makes that items name avaliable to this whole script, 
		/// before running the select a piece code in player control.
		///</summary>
	



		_GameState.gamestate = 2;					//a unique game state explicitly for handling items.
		ItemBeingUsed = itemBeingUsed;				//change local variable itemBeingUsed passed from method into acessable 
													//variable instantiated earler ItemBeingUsed
		_PlayerControl.selectAPiece = true;			//run the select a piece code. 



	}

	void useItem(){
		///<summary>
		/// Find out what item is being used and run that particular method
		/// not the most elegant code but works for now
		/// </summary>


		Debug.Log (_PlayerControl.selectedItemPiece + ItemBeingUsed.itemName);
		if (ItemBeingUsed.itemType == "Weapon") {
			
			weaponMeleeAttack (ItemBeingUsed, _PlayerControl.selectedItemPiece);

		} else if (ItemBeingUsed.itemType == "Equipment") {
			Debug.Log ("test");
			//equipmentEquip (ItemBeingUsed, _PlayerControl.selectedItemPiece);
		}else if(ItemBeingUsed.itemType == "Food"){
			Debug.Log ("test");
		} else {

			Debug.LogError ("Item Type not set");

		}

	}

	public void weaponMeleeAttack(Item _Item, GameObject _TargetPiece){
		Weapon _Weapon = _Item as Weapon;
		if (_TargetPiece.GetComponent<Piece> () != null) {
			_TargetPerson = _TargetPiece.GetComponent<Piece> ();
			_TargetPerson.TakeDamage (_Weapon.damage);
		} else {
			Debug.Log ("Not valid target");
		}





	}



}
