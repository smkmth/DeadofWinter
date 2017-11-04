using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class WarningPopup : MonoBehaviour {

	private ModelPanel modelPanel;

	//	private UnityAction myYesAction;
	//	private UnityAction myNoAction;
	//	private UnityAction myCancelAction;

	private GameState _GameState;

	public string warningText;

	void Awake(){


		_GameState = GameObject.Find ("GameFlow").GetComponent<GameState> ();


		modelPanel = ModelPanel.Instance ();

		//		myYesAction = new UnityAction (ZombieYesFunction);
		//		myNoAction = new UnityAction (ZombieNoFunction);
		//		myCancelAction = new UnityAction (ZombieCancelFunction);



	}


	public void WarningPanel(){
		Debug.Log ("Attempting test");
		_GameState.ChangeState (4);
		modelPanel.Choice (warningText, GameoverCancelFunction);
	}
	void GameoverCancelFunction(){

		_GameState.ChangeState (0);



	}




}




