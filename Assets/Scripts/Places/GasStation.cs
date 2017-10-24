using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasStation : MonoBehaviour {


	public int peopleInGasStation;

	public GameObject zombieTileW1;
	public GameObject zombieTileW2;
	public GameObject zombieTileW3;
	public GameObject zombieTileW4;
	public GameObject zombieTileE1;
	public GameObject zombieTileE2;
	public GameObject zombieTileE3;
	public GameObject zombieTileE4;
	public GameObject zombieTileS1;
	public GameObject zombieTileS2;
	public GameObject zombieTileS3;
	public Vector3 zTileW1Coords;
	public Vector3 zTileW2Coords;
	public Vector3 zTileW3Coords;
	public Vector3 zTileW4Coords;
	public Vector3 zTileW5Coords;
	public Vector3 zTileE1Coords;
	public Vector3 zTileE2Coords;
	public Vector3 zTileE3Coords;
	public Vector3 zTileE4Coords;
	public Vector3 zTileS1Coords;
	public Vector3 zTileS2Coords;
	public Vector3 zTileS3Coords;
	public List<Vector3> GasStationCoords = new List<Vector3>();
	public List<Vector3> UsedGasStationCoords = new List<Vector3> ();
	public string deckName = "GasStation";
	private GameObject _Piece;

	//ZombieTileW1
	void Start(){

		//ZombieTileW1
		GasStationCoords.Add(zTileW1Coords = new Vector3 (zombieTileW1.GetComponent<Collider>().gameObject.transform.position.x, 2, zombieTileW1.GetComponent<Collider>().gameObject.transform.position.z));
		GasStationCoords.Add(zTileW2Coords = new Vector3 (zombieTileW2.GetComponent<Collider>().gameObject.transform.position.x, 2, zombieTileW2.GetComponent<Collider>().gameObject.transform.position.z));
		GasStationCoords.Add(zTileW3Coords = new Vector3 (zombieTileW3.GetComponent<Collider>().gameObject.transform.position.x, 2, zombieTileW3.GetComponent<Collider>().gameObject.transform.position.z));
		GasStationCoords.Add(zTileW4Coords = new Vector3 (zombieTileW4.GetComponent<Collider>().gameObject.transform.position.x, 2, zombieTileW4.GetComponent<Collider>().gameObject.transform.position.z));
		GasStationCoords.Add(zTileE1Coords = new Vector3 (zombieTileE1.GetComponent<Collider>().gameObject.transform.position.x, 2, zombieTileE1.GetComponent<Collider>().gameObject.transform.position.z));
		GasStationCoords.Add(zTileE2Coords = new Vector3 (zombieTileE2.GetComponent<Collider>().gameObject.transform.position.x, 2, zombieTileE2.GetComponent<Collider>().gameObject.transform.position.z));
		GasStationCoords.Add(zTileE3Coords = new Vector3 (zombieTileE3.GetComponent<Collider>().gameObject.transform.position.x, 2, zombieTileE3.GetComponent<Collider>().gameObject.transform.position.z));
		GasStationCoords.Add(zTileE4Coords = new Vector3 (zombieTileE4.GetComponent<Collider>().gameObject.transform.position.x, 2, zombieTileE4.GetComponent<Collider>().gameObject.transform.position.z));
		GasStationCoords.Add(zTileS1Coords = new Vector3 (zombieTileS1.GetComponent<Collider>().gameObject.transform.position.x, 2, zombieTileS1.GetComponent<Collider>().gameObject.transform.position.z));
		GasStationCoords.Add(zTileS2Coords = new Vector3 (zombieTileS2.GetComponent<Collider>().gameObject.transform.position.x, 2, zombieTileS2.GetComponent<Collider>().gameObject.transform.position.z));
		GasStationCoords.Add(zTileS3Coords = new Vector3 (zombieTileS3.GetComponent<Collider>().gameObject.transform.position.x, 2, zombieTileS3.GetComponent<Collider>().gameObject.transform.position.z));
		_Piece = GameObject.FindGameObjectWithTag ("Player");

	}
	//no logic in here, all this does is identify the tag of 
	//whatever game object touches it and sends the info along.
	void OnTriggerEnter(Collider target){
		if (target.tag == "Player") {
			peopleInGasStation += 1;
			target.GetComponent<Piece> ().currentLocation = "GasStation";


			Debug.Log ("People in GasStation = " + peopleInGasStation + " " + target.name);



		}
	}
	void OnTriggerExit(Collider target){
		if (target.tag == "Player") {
			peopleInGasStation -= 1;
			Debug.Log ("People in gas station" + peopleInGasStation);
		}
	}
}
