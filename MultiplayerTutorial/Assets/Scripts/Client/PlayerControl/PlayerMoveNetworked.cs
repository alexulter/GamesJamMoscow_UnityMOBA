using UnityEngine;
using System.Collections;

public class PlayerMoveNetworked : MonoBehaviour {

	bool clicked = false;
	private float gunTime = 0;
	private Character target = null; //character we have clicked on
	Vector3 serverCurrentClick = Vector3.zero;
	private Vector3 movementDirection;
	private Character c;
	private CharacterController charController;
	NetworkPlayer heroOwner;
	// Use this for initialization
	void Start () {
		//enabled = false;
		c = GetComponent<Character> ();
		charController = GetComponent<CharacterController> ();
	
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (Network.isClient&&Network.player == heroOwner) 
		{

			//Camera.main.GetComponent<CameraMove ().SetTarget (transform);
		//enabled = true;

			if (Input.GetMouseButtonDown(1))//GetButtonDown ("Fire1")) 
			{
			Debug.Log ("Yay!");
				Vector2 point = Input.mousePosition;
				RaycastHit hit = new RaycastHit ();
				if (Physics.Raycast (Camera.main.ScreenPointToRay (point), out hit, 100.0f)) 
				{
					if (hit.collider.name != transform.name) 
					{
						Vector3 click = hit.point;
						string hitName = hit.collider.name;
						if (Network.isClient) 
							networkView.RPC ("SendMovementInput", RPCMode.Server, click.x, click.y, click.z, hitName);
						else SendMovementInput(click.x, click.y, click.z, hitName);
					}
				}

			}
		}
		if (Network.isServer) 
		{
			gunTime -= Time.deltaTime;
			if (target == null) 
			{
				float distance = (serverCurrentClick - transform.position).magnitude;
				if (serverCurrentClick != Vector3.zero && distance > 1) 
				{
					transform.LookAt (serverCurrentClick);
					Vector3 euler = transform.localEulerAngles;
					euler.x = 0;
					euler.z = 0;
					transform.localEulerAngles = euler;
					movementDirection = transform.TransformDirection (Vector3.forward) * 5 - Vector3.up * 10;
				}
				else {
					movementDirection = Vector3.zero + Vector3.up * 10;
				}
			} 
			else 
			{
				transform.LookAt (target.transform);
				float distance = (transform.position - target.transform.position).magnitude;
				if (distance < c.range) 
				{
//					///The hero is gonna hit enemy at this point
					movementDirection = Vector3.zero - Vector3.up * 10;
//					if (clicked) {
//						clicked = false;
//						if (gunTime <= 0) {
//							gunTime = 0.25f;
//							if (target.health > 0) {
//								target.Hit(c.Damage());
//								Network.Instantiate (ShotPrefab, transform.position, transform.rotation, 0);
//								if (target.health <= 0 && target.tag != tag) {
//									if (target.isHero) {
//										c.Xp(3);
//									}
//									else {
//										c.creeps++;
//										c.Xp(1);
//									}
//								}
//							}
//						}
//					}
				} 
				else 
				{
					movementDirection = transform.TransformDirection (Vector3.forward) * 5 - Vector3.up * 10;
				}
			}
			
//			if (c.health <= 0) {
//				c.health = c.maxHealth;
//				transform.position = originalPos;
//			}
//			else {
//				c.Hit(-0.25f * Time.deltaTime);
//			}
		}
		
		charController.Move(movementDirection*Time.deltaTime);


	}

	[RPC]
	void SendMovementInput (float x, float y, float z, string hitName)
	{
		if (hitName != "Terrain") 
		{
			GameObject AimedObject = GameObject.Find (hitName);
			if (AimedObject != null) 
			{
				//target = AimedObject.GetComponent<Character> ();
				
			}
		} 
		else 
		{
			target = null;
		}
		serverCurrentClick = new Vector3 (x, y, z);
		clicked = true;
	}

	[RPC]
	void EnablePlayer (NetworkPlayer player)
	{
		heroOwner = player;
		if (player == Network.player)
		{
			enabled = true;
		}

	}
}
