using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryGui : MonoBehaviour{

	public const int numItemSlots = 5;
	public Image[] _ItemImages = new Image[numItemSlots];
	public GameObject[] _ItemText = new GameObject[numItemSlots];
	public GameObject[] _ItemSlots = new GameObject[numItemSlots];
	public Button[] _ItemButtons = new Button[numItemSlots];
	private Item itemToAdd;
	public Item[] Inv = new Item[numItemSlots];
	public Item SelectedUI;
	public int itemInt;
	public EventSystem eventSystem;
	public ItemActions _ItemActions;
	public GameState _GameState;
	public PlayerControl _PlayerControl;	

	public void Start(){

		_ItemActions = GameObject.Find ("GameFlow").GetComponent<ItemActions> ();
		_GameState = GameObject.Find ("GameFlow").GetComponent<GameState> ();
		_PlayerControl = GameObject.Find ("GameFlow").GetComponent<PlayerControl> ();



	}


	public void DisplayItems(Character _Character)
	{
		ClearItems ();
		for (int i = 0; i < _Character.Inv.itemList.Count; i++)
		{
			if (_Character.Inv.itemList[i] != null){
				itemToAdd = _Character.Inv.itemList[i];
				Inv [i] = _Character.Inv.itemList [i];
				_ItemImages[i].sprite = itemToAdd.sprite;
				_ItemText [i].GetComponentInChildren<Text>().text = itemToAdd.itemName + " " + itemToAdd.itemDescription;
				_ItemText[i].SetActive(true);
				//_ItemButtons [i].enabled = true;
				//_ItemButtons[i].onClick.AddListener ();
				_ItemImages[i].enabled = true;
			}else  
			{
				_ItemText [i].SetActive (false);
				//_ItemButtons [i].enabled = false;

			}


		}
	}

	public void ClearItems()
	{
		
		for (int i = 0; i < _ItemSlots.Length; i++)
		{
			

			_ItemSlots[i] = null;
			_ItemImages[i].sprite = null;
			//_ItemText [i].GetComponent<Text> ().text = null;
			_ItemText [i].SetActive(false);
			_ItemImages[i].enabled = false;

				
			}
	}

	public void SelectItem(){
		//item is being used
		Debug.Log ("Click");
		Debug.Log (EventSystem.current.currentSelectedGameObject.name);
		Debug.Log ("Click");
		itemInt = Convert.ToInt32 (EventSystem.current.currentSelectedGameObject.name);
		SelectedUI = Inv [itemInt];
		Debug.Log (SelectedUI);
		if (SelectedUI != null) {
			

			_ItemActions.SetUpItem (SelectedUI);
		}




	}





}
