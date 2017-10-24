using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class ZombiePopup : MonoBehaviour {

	private ModelPanel modelPanel;

//	private UnityAction myYesAction;
//	private UnityAction myNoAction;
//	private UnityAction myCancelAction;
	private Zombies _Zombies;
	private GameState _GameState;
	public Sprite zombieIcon;
	void Awake(){

		_Zombies = GameObject.Find ("GameFlow").GetComponent<Zombies> ();
		_GameState = GameObject.Find ("GameFlow").GetComponent<GameState> ();


		modelPanel = ModelPanel.Instance ();

//		myYesAction = new UnityAction (ZombieYesFunction);
//		myNoAction = new UnityAction (ZombieNoFunction);
//		myCancelAction = new UnityAction (ZombieCancelFunction);
			


	}
	

	public void ZombieAttackPanel(){
		Debug.Log ("Attempting test");
		_GameState.ChangeState (4);
		modelPanel.Choice ("Would you like to attack this zombie?", zombieIcon, ZombieYesFunction, ZombieNoFunction, ZombieCancelFunction);
	}
	void ZombieYesFunction(){
		_Zombies.ZombieFightRes ();
		_GameState.ChangeState (0);


	}

	void ZombieNoFunction(){
		Debug.Log ("no way jose");
		_GameState.ChangeState (0);

	
	}

	void ZombieCancelFunction(){
		Debug.Log ("Cancel");
		_GameState.ChangeState (0);

	}


}







