using System.Collections;
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
	
	public void DisplayStats(Character _Character){
		StatPanel.SetActive (true);
		Name.text = _Character.Name;
		Description.text = _Character.CharacterDescription;
		Health.text = _Character.Health.ToString ();

	}

	public void ClearStats(){
		StatPanel.SetActive (false);
	}
}
