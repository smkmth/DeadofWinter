using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Actually moves a player when asked to.
/// Methods
/// SelectPiece(gameobject piece you want to select) what happens when you click on a piece. the inventory is displayed 
/// and the color of the piece turns red
/// MovePiece(vector3 place you want to go) changes pieces location to the coords passed in the vector3
/// DeSelectPiece(gameobject piece you want to deselect) Deselcts a piece, setting selected piece to null and changing
/// colour to grey.
/// </summary>
public class Movement : MonoBehaviour {

	//Changes the Color of a player when we click it, and then actually moves the player to
	//a new position.

	public GameObject SelectedPiece; //The piece selected in player controls
	public GameObject DeSelectedPiece;
	public string selectedPieceCurrentLocation; //where that piece is


	public void SelectPiece(GameObject _PieceToSelect){

		SelectedPiece = _PieceToSelect;
		SelectedPiece.GetComponent<Renderer> ().material.color = Color.red;
		SelectedPiece.GetComponent<Piece> ().CheckInventory ();


	

	}
		
	public void MovePiece(Vector3 _coordToMove)
	{
		if (SelectedPiece.GetComponent<Piece> ().hasMoved == false) {
			SelectedPiece.transform.position = _coordToMove;
			SelectedPiece.GetComponent<Renderer> ().material.color = Color.white;
			SelectedPiece.GetComponent<Piece> ().hasMoved = true;
			SelectedPiece = null;
		} else {
			Debug.Log (SelectedPiece.name + "has already moved this turn!");
		}

	}


	public void DeSelectPiece(GameObject _PieceToDeSelect){

		DeSelectedPiece = _PieceToDeSelect;
		DeSelectedPiece.GetComponent<Renderer> ().material.color = Color.white;
		DeSelectedPiece.GetComponent<Piece> ().ClearInventory ();

	}



}
