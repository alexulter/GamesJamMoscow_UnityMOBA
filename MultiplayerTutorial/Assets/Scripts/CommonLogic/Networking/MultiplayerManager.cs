using UnityEngine;
using System.Collections;
using System; //Чтобы использовать класс Convert

public class MultiplayerManager : MonoBehaviour {
	private int PlayersConnectedCounter = 0;
	private NetworkPlayer[] NetworkPlayersArray;
	public static int PlayersNumber;
	public Transform PlayerPrefab;
	public bool IsServerPlaying = true;
	//public bool GameStarted = false;


	void Start()
	{
		//enabled = false;
	}

	void OnServerInitialized() //Called when server was succesfully initialized
	{
		NGUIDebug.Log("Server was succefully initialized");
		NetworkPlayersArray = new NetworkPlayer[PlayersNumber];
		if (IsServerPlaying) 
		{
			NetworkPlayersArray[ PlayersConnectedCounter++] = Network.player; //Spawning player even if on the Server
		if ( PlayersConnectedCounter == PlayersNumber) 
			StartGame();
		else NGUIDebug.Log ("Number of players",  PlayersConnectedCounter);
		}
		
		
	}
	
	void OnPlayerConnected (NetworkPlayer player) //Call whenever player was connected
	{
		NetworkPlayersArray[ PlayersConnectedCounter++] = player;
		if ( PlayersConnectedCounter == PlayersNumber)
			StartGame();
		else NGUIDebug.Log ("Number of players", PlayersConnectedCounter);
	}

	void Update()
	{
	}

	void StartGame()
	{
		//GameStarted = true;
		int PlayerSpawnPosition = 0;
		foreach (NetworkPlayer player in NetworkPlayersArray) 
		{
			SpawnPlayer(PlayerPrefab, player, Vector3.up); //+ Vector3.right * PlayerSpawnPosition++);
		}
	}
	private void SpawnPlayer ()
	{
		Network.Instantiate (PlayerPrefab, Vector3.up, Quaternion.identity, 0);
	}

// Вообще сюда надо добавить код типа такого:
	private void SpawnPlayer (Transform prefab, NetworkPlayer player, Vector3 position)
	{
	
		string tempPlayerString = player.ToString ();
		int playerNumber = Convert.ToInt32 (tempPlayerString);

		Transform NewPlayerTransform = (Transform)Network.Instantiate (prefab, position, transform.rotation, playerNumber);
		//NewPlayerTransform.GetComponent<Character>().charID = 1;//charNumber++;
		//playerScripts.Add (newPlayerTransform.GetComponent<Hero> ());

		NetworkView theNetworkView = NewPlayerTransform.networkView;
		theNetworkView.RPC ("EnablePlayer", RPCMode.AllBuffered, player);

		//Кроме того, происходит какая-то лажа при дисконнекте: кубик никуда не девается и втыкается в террейн
	}
	
}
