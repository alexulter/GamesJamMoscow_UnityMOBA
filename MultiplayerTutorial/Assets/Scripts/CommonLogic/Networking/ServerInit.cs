using UnityEngine;
using System.Collections;
using System;//Чтобы использовать Convert.ToInt32

public class ServerInit : MonoBehaviour {

	public int PlayersNumber = 1;
	private string PlayersNumberStringVar = "1";
	public int connectionPort = 25001;
	public string connectionIP = "127.0.0.1";




	void OnGUI ()
	{
		if (Network.peerType == NetworkPeerType.Disconnected) {
			GUI.BeginGroup (new Rect (Screen.width/2 - 200, Screen.height/2 - 100, 400, 200));
			GUI.Label (new Rect (0, 0, 400, 30), "Status: Disconnected");
			GUI.Label (new Rect (0, 40, 100, 30), "Players: ");
			PlayersNumberStringVar = GUI.TextField (new Rect (100, 40, 50, 30),  PlayersNumberStringVar);
			if (GUI.Button (new Rect (160, 40, 240, 30), "Create Server")) {
				PlayersNumber = Convert.ToInt32 ( PlayersNumberStringVar);
				MultiplayerManager.PlayersNumber = PlayersNumber;
				Network.InitializeServer (PlayersNumber, connectionPort, false);
			}

			GUI.Label (new Rect (0, 80, 40, 30), "IP: ");
			connectionIP = GUI.TextField (new Rect (50, 80, 100, 30), connectionIP);
			if (GUI.Button (new Rect (160, 80, 240, 30), "Join Game")) {
				Network.Connect (connectionIP, connectionPort);
			}
			GUI.EndGroup();
			
		} else if (Network.peerType == NetworkPeerType.Client) {
			GUI.Label (new Rect (10, Screen.height - 40, 300, 30), "Status: Connected as Client");
			if (GUI.Button (new Rect (310, Screen.height - 40, 150, 30), "Disconnect")) {
				Network.Disconnect (200);
				Application.LoadLevel ("Main");
			}
		} else if (Network.peerType == NetworkPeerType.Server) {
			GUI.Label (new Rect (10, Screen.height - 40, 300, 30), "Status: Connected as Server");
			if (GUI.Button (new Rect (310, Screen.height - 40, 150, 30), "Disconnect")) {
				Network.Disconnect (200);
				Application.LoadLevel ("Main");
			}
		}
	}



//	void StartServer () {
//		Network.InitializeServer (PlayersNumber, 25001, !Network.HavePublicAddress ());
//		//MasterServer.RegisterHost ("YinYanMOBA", GameName);
//	}
}
