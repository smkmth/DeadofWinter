using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class GameOverPopup : MonoBehaviour {

	private ModelPanel modelPanel;

	//	private UnityAction myYesAction;
	//	private UnityAction myNoAction;
	//	private UnityAction myCancelAction;

	private GameState _GameState;
	public Sprite gameOverIcon;

	public string gameOverText = "Too long has passed, and the colany has fallen to dust.";
	void Awake(){


		_GameState = GameObject.Find ("GameFlow").GetComponent<GameState> ();


		modelPanel = ModelPanel.Instance ();

		//		myYesAction = new UnityAction (ZombieYesFunction);
		//		myNoAction = new UnityAction (ZombieNoFunction);
		//		myCancelAction = new UnityAction (ZombieCancelFunction);



	}


	public void GameOverPanel(){
		Debug.Log ("Attempting test");
		_GameState.ChangeState (4);
		modelPanel.Choice (gameOverText, gameOverIcon, GameoverYesFunction, GameoverNoFunction);
	}
	void GameoverYesFunction(){
		
		_GameState.ChangeState (0);
		_GameState.Restart();


	}

	void GameoverNoFunction(){
		_GameState.ChangeState (0);
		_GameState.Quit ();


	}



}




