using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// DONT DESTROY ON LOAD
/// attaches to the preload scene and simply stops any obeject this script is attached to 
/// and any of its children from being destroyed on a load of a new scene. 
/// </summary>
public class DDOL : MonoBehaviour {

	public void  Awake(){
		DontDestroyOnLoad (gameObject);
		SceneManager.LoadScene ("Game");

	}

//	public void Start(){
//		SceneManager.LoadScene ("Game");
//	}

}
