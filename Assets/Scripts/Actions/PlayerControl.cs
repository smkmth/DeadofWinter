using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
//	public Player _Player;
	private Camera PlayerCam;
	private Movement _Movement;
	private GameState _GameState;
	private Zombies _Zombies;
	private ItemActions _ItemActions;
	public GameObject selectedPiece;
	private GameObject _Character;
	private Piece _Piece;
	public string targetMovementLocation;
	public string targetDeckLocation;
	public string lastPieceLocation;
	public string lastPieceName;
	public GameObject selectedItemPiece = null;
	public bool selectAPiece = false;

	public StrateCamC _StrateCam;
	public GameObject objectToGoTo;
	public GameObject objectToFollow;


	void Awake ()
	{
		//these componenents are all located within this game object so i can just use getcomponent
		PlayerCam = Camera.main;
		//Camera PlayerCam = GameObject.Find("Main Camera").GetComponent<Camera>();
		_GameState = gameObject.GetComponent<GameState>();
		_Movement = gameObject.GetComponent<Movement> ();
		_Zombies = gameObject.GetComponent<Zombies> ();
		_ItemActions = gameObject.GetComponent<ItemActions> ();



	}

	void Start(){


	}
//	void Update(){
//		if (Input.GetKey("up")){
//			Debug.Log ("Keypressed");
//		}
//	}
//
	void Update()

	{
		if (Input.GetKey(KeyCode.T)) {
			_StrateCam.Follow(objectToFollow);
		}
		if (Input.GetKey(KeyCode.G)) {
			_StrateCam.GoTo(objectToGoTo.transform.position);
		}

//		if (Input.GetButtonDown ("Inv")) {
//			Debug.Log (_Player.PlayerInv.itemList.Count);
//			
//		}

		///select a piece
		if (selectAPiece == false) {
			Ray _ray;
			RaycastHit _hitInfo;
			 
			if (_GameState.gamestate < 2) {
				
				//on left click
				if (Input.GetMouseButtonDown (0)) {
					//Debug.Log ("Click");
					_ray = PlayerCam.ScreenPointToRay (Input.mousePosition);
					//if ray collides
					if (Physics.Raycast (_ray, out _hitInfo)) {
						if (_hitInfo.collider.gameObject.tag == ("Player")) {
							
							selectedPiece = _hitInfo.collider.gameObject;
							lastPieceName = selectedPiece.GetComponent<Piece> ().MyName ();
							Debug.Log ("lastPieceName = " + lastPieceName);


							_Movement.SelectPiece (selectedPiece);
							//selectedPiece.GetComponent<Piece> ().CheckInventory ();


							_GameState.ChangeState (1);

						}

					}
		
				}
			}
			//Do somthing with piece 
			if (_GameState.gamestate == 1) {



				//			if (Input.GetButtonDown ("Inv")) {
				//				selectedPiece.GetComponent<Piece> ().CheckInventory ();
				//			}
				Vector3 selectedCoord;

				if (Input.GetMouseButtonDown (0)) {
					_ray = PlayerCam.ScreenPointToRay (Input.mousePosition);
					//raycast
					if (Physics.Raycast (_ray, out _hitInfo)) {
						lastPieceLocation = selectedPiece.GetComponent<Piece> ().MyCurrentLocation ();
						//lastPieceName = selectedPiece.gameObject.name;
						//lastPieceName = selectedPiece.name;

						//select place for tag
						if (_hitInfo.collider.tag == ("HumanTile") && _hitInfo.collider.gameObject.GetComponent<HumanTile> ().occupiedTile != true) {
							//						Debug.Log ("HitTile!x" + _hitInfo.collider.gameObject.transform.position.x);
							//						Debug.Log ("HitTile!y" + _hitInfo.collider.gameObject.transform.position.y);
							//						Debug.Log ("HitTile!z" + _hitInfo.collider.gameObject.transform.position.z);
							targetMovementLocation = _hitInfo.collider.gameObject.GetComponent<HumanTile> ().tileLocation;
							//Debug.Log ("TargetLoaction = " + targetMovementLocation);
							selectedCoord = new Vector3 (_hitInfo.collider.gameObject.transform.position.x, 2, _hitInfo.collider.gameObject.transform.position.z);
							//Debug.Log ("Selectedcoord" + selectedCoord);
							_Movement.MovePiece (selectedCoord);
							_GameState.ChangeState (0);
							_Movement.DeSelectPiece (selectedPiece);
						} else if (_hitInfo.collider.tag == ("Zombie")) {
							
							_Zombies.ZombieFight (lastPieceName, lastPieceLocation, _hitInfo.collider.gameObject);
							_Movement.DeSelectPiece (_Movement.SelectedPiece);
						} else if (_hitInfo.collider.tag == ("Item")) {
							//Debug.Log ("Clicked item deck");
							//lastPieceLocation = selectedPiece.GetComponent<Piece>().MyCurrentLocation();
							//lastPieceName = selectedPiece.gameObject.name;
							targetDeckLocation = _hitInfo.collider.gameObject.GetComponent<ItemDeck> ().deckLocation;

							_ItemActions.CheckToSearchItems (_hitInfo.collider.gameObject, lastPieceLocation, lastPieceName);
							_GameState.ChangeState (0);
							_Movement.DeSelectPiece (_Movement.SelectedPiece);
						} else if (_hitInfo.collider.tag == (null)) {
							_Movement.DeSelectPiece (_Movement.SelectedPiece);
						}
					}
				}
					
			}
		} else { 
			//an item has been selected and is about to be used, choose an object to use it on
			if (_GameState.gamestate == 2) {
				Ray _ray;
				RaycastHit _hitInfo;

				//on left click
				if (Input.GetMouseButtonDown (0)) {
					//Debug.Log ("Click");
					_ray = PlayerCam.ScreenPointToRay (Input.mousePosition);
					//if ray collides
					if (Physics.Raycast (_ray, out _hitInfo)) {
						selectedItemPiece = _hitInfo.collider.gameObject;
						Debug.Log ("Used item with " + selectedItemPiece);
						_GameState.gamestate = 0;
						EventManager.TriggerEvent ("PieceSelected");
						selectAPiece = false;
					}

				}
			}


		}

	}
//	public void SelectPlayer(){
//		Ray _ray;
//		RaycastHit _hitInfo;
//		Debug.Log ("Select target");
//		Debug.Log (_GameState.gamestate);
//		if (_GameState.gamestate == 2) {
//			
//			//on left click
//			if (Input.GetMouseButtonDown (0)) {
//				Debug.Log ("Click");
//				_ray = PlayerCam.ScreenPointToRay (Input.mousePosition);
//							//if ray collides
//				if (Physics.Raycast (_ray, out _hitInfo)) {
//					selectedItemPiece = _hitInfo.collider.gameObject;
//					Debug.Log ("Used item with " + selectedItemPiece);
//					_GameState.gamestate = 0;
//					}
//			
//				}
//			}
//
//
//	}


	public void SetSmoothingFactor(float x) {
		_StrateCam.smoothingFactor = x;
	}

	public void SetPanSpeed(float x) {
		_StrateCam.panSpeed = x;
	}

	public void SetRotationSpeed(float x) {
		_StrateCam.rotationSpeed = x;
	}

	public void SetZoomSpeed(float x) {
		_StrateCam.zoomSpeed = x;
	}

	public void SetGoToSpeed(float x) {
		_StrateCam.goToSpeed = x;
	}

	public void SetDoubleClickMovement(bool x) {
		_StrateCam.allowDoubleClickMovement = x;
	}

}