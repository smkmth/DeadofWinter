using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringToFront : MonoBehaviour {
//draw this obeject last to bring element to the front of screen

void OnEnable () {

		transform.SetAsLastSibling ();
	}

}