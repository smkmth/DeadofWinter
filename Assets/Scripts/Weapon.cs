using System;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu( menuName = "Assets/Item/Weapon", order =3)]//creates a new editor assets/create menu called character data 
public class Weapon : Item 
{
	public float range = 0;
	public int damage = 0;
	public string specialEffect = "NewEffect";



}

