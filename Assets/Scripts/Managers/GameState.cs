using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
/// Handles the current game state, which changes to allow specific things to happen all over 
/// the code. the gamestates are 0 for nothing selected, which changes to 1 when a piece is selected
/// 2 when an item has been selectedd then 3 when a turn changes (colany phase) and 4 for a model dialgue 
/// window to pause the game. 
/// *Added* turnCount - a int which adds up 1 every time a turn passes. 
/// for loop which iterates through all the characters every turn.  
/// </summary>
public class GameState : MonoBehaviour {

	//GameStates 0 normal, 1 piece is seleceted, 2 item select, 3 change turn, 4 model dialoge

	public int gamestate = 0;
	
	public int turnCount;
	private Zombies _Zombies;
	private GameObject[] Characters;
	public GameOverPopup _GameOverPopup;

	//private GroceryStore _GroceryStore;

	void Awake(){
		
		_Zombies = gameObject.GetComponent<Zombies> ();


		//_GroceryStore = GameObject.Find ("GroceryStore").GetComponent<GroceryStore>();

	}

	void Start(){
		turnCount = 0;
		_GameOverPopup = GameObject.Find ("Popup Canvas").GetComponent<GameOverPopup> ();

		
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
			foreach (GameObject piece in Characters) {						//This is a cool bit of code, every turn, this code goes through a loop of all the characters a
																			//and does somthing. Whatever i want to happen, like we can check the food - damage people all sorts
																			//of fun stuff. at the moment it just sets hasMoved to false
				piece.GetComponent<Piece> ().hasMoved = false;
			}
			turnCount += 1;
			gamestate = 0;
			Debug.Log ("Ended turn " + turnCount);
			Debug.Log ("Gamestate =" + gamestate);
		
																			//You can lose now!
			if (turnCount > 10) {

				LoseTheGame ("You just ran out of time! You couldnt find the cure, and all became flesh eating undead. Game Over. Restart?");


			}
			
		}

	}
	public void LoseTheGame(string message){
		_GameOverPopup.gameOverText = message;
		_GameOverPopup.GameOverPanel();
		

	}

	public void Quit(){
		Application.Quit ();
	}

	public void Restart(){
		Application.LoadLevel (Application.loadedLevel);
	}


	
}
