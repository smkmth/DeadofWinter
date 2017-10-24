using System;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu( menuName = "Assets/Item/Equipment", order =3)]//creates a new editor assets/create menu called character data 
public class Equipment : Item {
	
	public bool head;
	public bool body;
	public bool legs;
	public bool feet;

	public int ArmourValue = 0;
	public string SpecialEffect = "newEfffect";



}