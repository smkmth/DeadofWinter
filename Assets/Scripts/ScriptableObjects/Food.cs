using System;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu( menuName = "Assets/Item/Food", order =3)]//creates a new editor assets/create menu called character data 
public class Food : Item 
{
	public float Nutrition = 0;

	public string specialEffect = "NewEffect";



}