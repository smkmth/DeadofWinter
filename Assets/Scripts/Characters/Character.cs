using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( menuName = "Assets/CharacterData", order =1)]//creates a new editor assets/create menu called character data 
public class Character : ScriptableObject {

	public string Name;

	public string CharacterDescription;

	public int Health;


	public int AttackValue;

	public int ColdResist;

	public int BaseNoise;

	public ItemList Inv;

	public bool headEquiped;
	public Equipment headEquip;
	public Equipment bodyEquip;
	public Equipment legsEquip;
	public Equipment feetEquip;

	public void takeDamage(int amountDamage){

		Health -= amountDamage;
		Debug.Log ("taken a hit, health now " + Health);
	}




}

