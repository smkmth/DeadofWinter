using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {

	//GameStates 0 normal, 1 piece is seleceted, 2 item select, 3 change turn, 4 model dialoge

	public int gamestate = 0;

	private Zombies _Zombies;

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
			gamestate = 0;
			Debug.Log ("EndTurn");
			Debug.Log ("Gamestate =" + gamestate);
		}

	}
	
}
