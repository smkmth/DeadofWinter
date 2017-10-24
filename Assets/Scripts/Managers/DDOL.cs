using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//The object which holds all the logic of the game is here so it remains constant from scene to 
//scene.

public class DDOL : MonoBehaviour {

	public void  Awake(){
		DontDestroyOnLoad (gameObject);
		SceneManager.LoadScene ("Game");

	}

//	public void Start(){
//		SceneManager.LoadScene ("Game");
//	}

}
