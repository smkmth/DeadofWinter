<<<<<<< HEAD
﻿using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CharStatsGui : MonoBehaviour{

	public GameObject _Name;
	public Text _NameText;
	public GameObject _Health;
	public Text _HealthText;
	public GameObject _CharacterDescription;
	public Text _DescriptionText;
	public GameObject _Panel;

	//public PlayerControl _PlayerControl;

	public void DisplayStats(Character _Character){


		_Panel.SetActive (true);
		_NameText.text = _Character.Name;
	
		_DescriptionText.text = _Character.CharacterDescription;
		_HealthText.text = _Character.Health.ToString();
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This sits on the game object CharStats. The StatPanel gameobject is the 
/// first child panel of CharStats called StatPanel, the name, description and health
/// are all child objects of the stat panel. To get everything hooked up like this, you 
/// simply have to drag and drop the game objects and text elements in the preload 
/// scene to the respective slots on this scripts component on the CharStats game object.
/// the method itself is called in the Piece script, which calls it for each respective ]
/// character when asked by movement when a piece is selected. 
/// </summary>
public class CharStatsGui : MonoBehaviour {

	public GameObject StatPanel;
	public Text Name;
	public Text Description;
	public Text Health;
	
	public void DisplayStats(Character _Character, GameObject _Piece){
		StatPanel.SetActive (true);
		Name.text = _Character.Name;
		Description.text = _Character.CharacterDescription;
<<<<<<< HEAD
		Health.text = _Character.Health.ToString ();
>>>>>>> master
=======
		Health.text = "Health: " + _Piece.GetComponent<Piece> ().Health.ToString();
>>>>>>> GameOver

	}

	public void ClearStats(){
<<<<<<< HEAD
		_Panel.SetActive (false);

	}

}
=======
		StatPanel.SetActive (false);
	}
}
>>>>>>> master
