using System;
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

	}

	public void ClearStats(){
		_Panel.SetActive (false);

	}

}