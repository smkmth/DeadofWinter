using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EndTurnButton : MonoBehaviour {

	private GameState _GameState;

	void Awake(){
		_GameState = GameObject.Find ("GameFlow").GetComponent<GameState>();

	}

	public void NextTurnButton(){
		if (_GameState.gamestate == 0) {
			
			Debug.Log ("ClickedNextTurn");
			_GameState.EndTurn ();
		} else {
			Debug.Log ("Please finish moving");
		}

	}
}
