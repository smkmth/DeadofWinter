using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
/// controls the grocerystroe, variables are peopleInGroceryStore, which returns with the amount of people in the grocerystore
/// a public list of zombie tiles, where zombies can spawn, a list of these coords, and another list which 
/// tracks the used coords. in general, with the zombies class, this script puts zombies at a random one of many 
/// possible coords attached to the tile objects. for convieninence i have labled these after cardinal directions.
/// need to make this more effiecient some time soon.
/// on top of this, it is attached to a collider, which updates the piece telling it what location it is currently 
/// in.
/// </summary>
public class GroceryStore : MonoBehaviour {


	public int peopleInGroceryStore;
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
	public List<Vector3> GroceryCoords = new List<Vector3>();
	public List<Vector3> UsedGroceryCoords = new List<Vector3> ();
	public string deckName = "GroceryStore";
	//private GameObject _Piece;

	//ZombieTileW1
	void Start(){
		
		//ZombieTileW1
		GroceryCoords.Add(zTileW1Coords = new Vector3 (zombieTileW1.GetComponent<Collider>().gameObject.transform.position.x, 2, zombieTileW1.GetComponent<Collider>().gameObject.transform.position.z));
		GroceryCoords.Add(zTileW2Coords = new Vector3 (zombieTileW2.GetComponent<Collider>().gameObject.transform.position.x, 2, zombieTileW2.GetComponent<Collider>().gameObject.transform.position.z));
		GroceryCoords.Add(zTileW3Coords = new Vector3 (zombieTileW3.GetComponent<Collider>().gameObject.transform.position.x, 2, zombieTileW3.GetComponent<Collider>().gameObject.transform.position.z));
		GroceryCoords.Add(zTileW4Coords = new Vector3 (zombieTileW4.GetComponent<Collider>().gameObject.transform.position.x, 2, zombieTileW4.GetComponent<Collider>().gameObject.transform.position.z));
		GroceryCoords.Add(zTileE1Coords = new Vector3 (zombieTileE1.GetComponent<Collider>().gameObject.transform.position.x, 2, zombieTileE1.GetComponent<Collider>().gameObject.transform.position.z));
		GroceryCoords.Add(zTileE2Coords = new Vector3 (zombieTileE2.GetComponent<Collider>().gameObject.transform.position.x, 2, zombieTileE2.GetComponent<Collider>().gameObject.transform.position.z));
		GroceryCoords.Add(zTileE3Coords = new Vector3 (zombieTileE3.GetComponent<Collider>().gameObject.transform.position.x, 2, zombieTileE3.GetComponent<Collider>().gameObject.transform.position.z));
		GroceryCoords.Add(zTileE4Coords = new Vector3 (zombieTileE4.GetComponent<Collider>().gameObject.transform.position.x, 2, zombieTileE4.GetComponent<Collider>().gameObject.transform.position.z));
		GroceryCoords.Add(zTileS1Coords = new Vector3 (zombieTileS1.GetComponent<Collider>().gameObject.transform.position.x, 2, zombieTileS1.GetComponent<Collider>().gameObject.transform.position.z));
		GroceryCoords.Add(zTileS2Coords = new Vector3 (zombieTileS2.GetComponent<Collider>().gameObject.transform.position.x, 2, zombieTileS2.GetComponent<Collider>().gameObject.transform.position.z));
		GroceryCoords.Add(zTileS3Coords = new Vector3 (zombieTileS3.GetComponent<Collider>().gameObject.transform.position.x, 2, zombieTileS3.GetComponent<Collider>().gameObject.transform.position.z));
		//_Piece = GameObject.FindGameObjectWithTag ("Player");

	}
	//no logic in here, all this does is identify the tag of 
	//whatever game object touches it and sends the info along.
	void OnTriggerEnter(Collider target){
		if (target.tag == "Player") {
			peopleInGroceryStore += 1;
			target.GetComponent<Piece> ().currentLocation = "GroceryStore";
			peopleInLocation.Add (target.gameObject);

		
			Debug.Log ("People in grocerystore = " + peopleInGroceryStore + " " + target.name);



		}
	}
	void OnTriggerExit(Collider target){
		if (target.tag == "Player") {
			peopleInGroceryStore -= 1;
			peopleInLocation.Remove (target.gameObject);
			Debug.Log ("People in grocery store =" + peopleInGroceryStore);
		}
	}
}
