using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// Zombies handles how the zombies are spawned, and the behavor the zombies follow.
/// AddingZombies() adds zombies at the end of a turn.
/// ZombieFight() runs the zombie attack panel.
/// </summary>
public class Zombies : MonoBehaviour {

	//refrence to grocery store 
	private GroceryStore _GroceryStore;
	private Hospital _Hospital;
	private Colany _Colany;

	private GasStation _GasStation;
	private GameObject GroceryZombie;
	private GameObject HospitalZombie;
	private GameObject GasStationZombie;
	private GameObject ColanyZombie;

	public ZombiePopup _ZombiePopup;


	//refrence to zombie prefab
	public GameObject Zombie;
	public Vector3 location;
	public GameObject targetZombie;
	public string targetZombieLocation;

	private int numZombiesGroceryStore;
	private int numZombiesHospital;


	public void Start(){
		_GroceryStore = GameObject.Find ("GroceryStore").GetComponent<GroceryStore>();
		_Hospital = GameObject.Find ("Hospital").GetComponent<Hospital>();
		_Colany = GameObject.Find ("Colany").GetComponent<Colany> ();
		_GasStation = GameObject.Find ("GasStation").GetComponent<GasStation> ();
		_ZombiePopup = GameObject.Find ("Popup Canvas").GetComponent<ZombiePopup> ();
	}


	public void AddingZombies() {

		for (int i = _Colany.peopleInColany; i > 0; i--){ 
		//if (_Colany.peopleInColany > 0) {
			

			if (_Colany.ColanyCoords.Count > 0) {
				
				location = _Colany.ColanyCoords [UnityEngine.Random.Range (0, _Colany.ColanyCoords.Count)];
				ColanyZombie = Instantiate (Zombie, location, Quaternion.identity);
				ColanyZombie.GetComponent<Zombie>().ZombieLocation = "Colany";
				_Colany.UsedColanyCoords.Add (location);
				_Colany.ColanyCoords.Remove (location);
				Debug.Log ("Zombie placed here" + location);
			} else {

				LocationOverrun ("Colany");

			}

		}

		for (int i = _GroceryStore.peopleInGroceryStore; i> 0; i--){
		//if (_GroceryStore.peopleInGroceryStore > 0) {
			
				if (_GroceryStore.GroceryCoords.Count > 0) {
					location = _GroceryStore.GroceryCoords [UnityEngine.Random.Range (0, _GroceryStore.GroceryCoords.Count)];
					GroceryZombie = Instantiate (Zombie, location, Quaternion.identity);
				GroceryZombie.GetComponent<Zombie>().ZombieLocation = "GroceryStore";
					_GroceryStore.UsedGroceryCoords.Add (location);
					_GroceryStore.GroceryCoords.Remove (location);
					Debug.Log ("Zombie placed here" + location);
				} else {

					LocationOverrun ("GroceryStore");
				
				}
			}
		for (int i = _Hospital.peopleInHospital; i> 0; i--) {	
		//if (_Hospital.peopleInHospital > 0) {

				if (_Hospital.HospitalCoords.Count > 0) {
					location = _Hospital.HospitalCoords [UnityEngine.Random.Range (0, _Hospital.HospitalCoords.Count)];
					HospitalZombie = Instantiate (Zombie, location, Quaternion.identity);
				HospitalZombie.GetComponent<Zombie>().ZombieLocation = "Hospital";

					_Hospital.UsedHospitalCoords.Add (location);
					_Hospital.HospitalCoords.Remove (location);
					Debug.Log ("Zombie placed here" + location);
				} else {

					LocationOverrun ("Hospital");

				}
			}
		for (int i = _GasStation.peopleInGasStation; i> 0; i--) {	
			//if (_Hospital.peopleInHospital > 0) {

			if (_GasStation.GasStationCoords.Count > 0) {
				location = _GasStation.GasStationCoords [UnityEngine.Random.Range (0, _GasStation.GasStationCoords.Count)];
				GasStationZombie =	Instantiate (Zombie, location, Quaternion.identity);
				GasStationZombie.GetComponent<Zombie>().ZombieLocation = "GasStation";
				_GasStation.UsedGasStationCoords.Add (location);
				_GasStation.GasStationCoords.Remove (location);
				Debug.Log ("Zombie placed here" + location);
			} else {

				LocationOverrun ("GasStation");

			}
		}
	}


	public void LocationOverrun (string overrunLocation){
		Debug.Log (overrunLocation + "IS OVERRUNN!");
	}

	public void ZombieFight(string playerName, string playerLocation, GameObject zombie){

		targetZombie = zombie;

		targetZombieLocation = targetZombie.GetComponent<Zombie> ().ZombieLocation;

		if (targetZombieLocation == playerLocation) {
			Debug.Log (zombie.name  + " at " + targetZombieLocation + " fights " + playerName + " at " + playerLocation);
			Debug.Log ("Zombie Fight!"+ zombie.transform.position);
			//zombie.GetComponent<Renderer> ().material.color = Color.red;
			_ZombiePopup.ZombieAttackPanel ();
		}


	}
	public void ZombieFightRes(){
		Debug.Log ("zombie dead" + targetZombie.transform.position);
		Destroy (targetZombie);

	}
}

//	public void CalculateZombies() {
//		if (_GroceryStore.peopleInGroceryStore == 1) {
//			numZombiesGroceryStore = 1;
//		} else if (_GroceryStore.peopleInGroceryStore == 2) {
//			numZombiesGroceryStore = 2;
//		} else if (_GroceryStore.peopleInGroceryStore == 3) {
//			numZombiesGroceryStore = 3;
//		} 
//		if (_Hospital.peopleInHospital == 1) {
//			numZombiesHospital = 1;
//		}else if (_Hospital.peopleInHospital == 2) {
//			numZombiesHospital = 2;
//		}else if (_Hospital.peopleInHospital == 3) {
//			numZombiesHospital = 3;
//		}
//
//	}


