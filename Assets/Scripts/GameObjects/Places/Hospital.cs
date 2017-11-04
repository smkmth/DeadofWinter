using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
/// controls the hospital, methods are peopleInHospital, which returns with the amount of people in the hospital
/// a public list of zombie tiles, where zombies can spawn, a list of these coords, and another list which 
/// tracks the used coords. in general, with the zombies class, this script puts zombies at a random one of many 
/// possible coords attached to the tile objects. for convieninence i have labled these after cardinal directions.
/// need to make this more effiecient some time soon.
/// on top of this, it is attached to a collider, which updates the piece telling it what location it is currently 
/// in.
/// </summary>
public class Hospital : MonoBehaviour {

	//Add more zombie tiles by adding on the game object

	public int peopleInHospital;
	public List<GameObject> peopleInLocation = new List<GameObject>();

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
	public GameObject zombieTileS4;
	public GameObject zombieTileS5;
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
	public Vector3 zTileS4Coords;
	public Vector3 zTileS5Coords;
	public List<Vector3> HospitalCoords = new List<Vector3>();
	public List<Vector3> UsedHospitalCoords = new List<Vector3> ();


	//ZombieTileW1
	void Start(){

		//ZombieTileW1
		HospitalCoords.Add(zTileW1Coords = new Vector3 (zombieTileW1.GetComponent<Collider>().gameObject.transform.position.x, 2, zombieTileW1.GetComponent<Collider>().gameObject.transform.position.z));
		HospitalCoords.Add(zTileW2Coords = new Vector3 (zombieTileW2.GetComponent<Collider>().gameObject.transform.position.x, 2, zombieTileW2.GetComponent<Collider>().gameObject.transform.position.z));
		HospitalCoords.Add(zTileW3Coords = new Vector3 (zombieTileW3.GetComponent<Collider>().gameObject.transform.position.x, 2, zombieTileW3.GetComponent<Collider>().gameObject.transform.position.z));
		HospitalCoords.Add(zTileW4Coords = new Vector3 (zombieTileW4.GetComponent<Collider>().gameObject.transform.position.x, 2, zombieTileW4.GetComponent<Collider>().gameObject.transform.position.z));
		HospitalCoords.Add(zTileE1Coords = new Vector3 (zombieTileE1.GetComponent<Collider>().gameObject.transform.position.x, 2, zombieTileE1.GetComponent<Collider>().gameObject.transform.position.z));
		HospitalCoords.Add(zTileE2Coords = new Vector3 (zombieTileE2.GetComponent<Collider>().gameObject.transform.position.x, 2, zombieTileE2.GetComponent<Collider>().gameObject.transform.position.z));
		HospitalCoords.Add(zTileE3Coords = new Vector3 (zombieTileE3.GetComponent<Collider>().gameObject.transform.position.x, 2, zombieTileE3.GetComponent<Collider>().gameObject.transform.position.z));
		HospitalCoords.Add(zTileE4Coords = new Vector3 (zombieTileE4.GetComponent<Collider>().gameObject.transform.position.x, 2, zombieTileE4.GetComponent<Collider>().gameObject.transform.position.z));
		HospitalCoords.Add(zTileS1Coords = new Vector3 (zombieTileS1.GetComponent<Collider>().gameObject.transform.position.x, 2, zombieTileS1.GetComponent<Collider>().gameObject.transform.position.z));
		HospitalCoords.Add(zTileS2Coords = new Vector3 (zombieTileS2.GetComponent<Collider>().gameObject.transform.position.x, 2, zombieTileS2.GetComponent<Collider>().gameObject.transform.position.z));
		HospitalCoords.Add(zTileS3Coords = new Vector3 (zombieTileS3.GetComponent<Collider>().gameObject.transform.position.x, 2, zombieTileS3.GetComponent<Collider>().gameObject.transform.position.z));
		HospitalCoords.Add(zTileS3Coords = new Vector3 (zombieTileS4.GetComponent<Collider>().gameObject.transform.position.x, 2, zombieTileS4.GetComponent<Collider>().gameObject.transform.position.z));
		HospitalCoords.Add(zTileS3Coords = new Vector3 (zombieTileS5.GetComponent<Collider>().gameObject.transform.position.x, 2, zombieTileS5.GetComponent<Collider>().gameObject.transform.position.z));
	
	}
	//no logic in here, all this does is identify the tag of 
	//whatever game object touches it and sends the info along.
	void OnTriggerEnter(Collider target){
		if (target.tag == "Player") {
			peopleInHospital += 1;
			peopleInLocation.Add (target.gameObject);
			target.GetComponent<Piece> ().currentLocation = "Hospital";
			Debug.Log ("People in hospital = " + peopleInHospital + " " + target.name);



		}
	}
	void OnTriggerExit(Collider target){
		if (target.tag == "Player") {
			peopleInHospital -= 1;
			peopleInLocation.Remove (target.gameObject);
			Debug.Log ("People in Hospital =" + peopleInHospital);
		}
	}

	
}
