using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class TestModelPanel : MonoBehaviour {
	private ModelPanel modelPanel;

	private UnityAction myYesAction;
	private UnityAction myNoAction;
	private UnityAction myCancelAction;

	void Awake(){
		modelPanel = ModelPanel.Instance ();

		myYesAction = new UnityAction (TestYesFunction);
		myNoAction = new UnityAction (TestNoFunction);
		myCancelAction = new UnityAction (TestCancelFunction);


	}

	public void TestYNC(){
		Debug.Log ("shouldntshow up");
		modelPanel.Choice ("Would you like to do somthing?\n How about whatever?", myYesAction, myNoAction, myCancelAction);
	}

	void TestYesFunction(){
		Debug.Log ("whatever works");
	}

	void TestNoFunction(){
		Debug.Log ("no way jose");
	}

	void TestCancelFunction(){
		Debug.Log ("Igive up");
	}

}

