using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
/// Handles the current game state, which changes to allow specific things to happen all over 
/// the code. the gamestates are 0 for nothing selected, which changes to 1 when a piece is selected
/// 2 when an item has been selectedd then 3 when a turn changes (colany phase) and 4 for a model dialgue 
/// window to pause the game
/// </summary>
public class GameState : MonoBehaviour {

	//GameStates 0 normal, 1 piece is seleceted, 2 item select, 3 change turn, 4 model dialoge

	public int gamestate = 0;

	private Zombies _Zombies;
	private GameObject[] Characters;

	//private GroceryStore _GroceryStore;

	void Awake(){
		
		_Zombies = gameObject.GetComponent<Zombies> ();

		//_GroceryStore = GameObject.Find ("GroceryStore").GetComponent<GroceryStore>();

	}


	public void ChangeState(int _newState)
	{
		gamestate = _newState;
		Debug.Log ("Gamestate =" + _newState);
	}
	public void EndTurn(){
		if (gamestate != 4){
			
			gamestate = 3;
			Debug.Log ("Gamestate =" + gamestate);
			_Zombies.AddingZombies ();
			Characters = GameObject.FindGameObjectsWithTag ("Player");
			foreach (GameObject piece in Characters) {
				piece.GetComponent<Piece> ().hasMoved = false;
			}
			gamestate = 0;
			Debug.Log ("EndTurn");
			Debug.Log ("Gamestate =" + gamestate);
		}

	}
	
}
