using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	//Changes the Color of a player when we click it, and then actually moves the player to
	//a new position.

	public GameObject SelectedPiece; //The piece selected in player controls
	public string selectedPieceCurrentLocation; //where that piece is


	public void SelectPiece(GameObject _PieceToSelect){
		if (SelectedPiece) {
			SelectedPiece.GetComponent<Renderer> ().material.color = Color.gray;
		}
		SelectedPiece = _PieceToSelect;
		SelectedPiece.GetComponent<Renderer> ().material.color = Color.red;

	

	}
		
	public void MovePiece(Vector3 _coordToMove)
	{
		SelectedPiece.transform.position = _coordToMove;
		SelectedPiece.GetComponent<Renderer> ().material.color = Color.gray;
		SelectedPiece = null;
	}
	public void DeSelectPiece(GameObject _PieceToDeSelect){
		SelectedPiece.GetComponent<Renderer> ().material.color = Color.gray;
	}



}
