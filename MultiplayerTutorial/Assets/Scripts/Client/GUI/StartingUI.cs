//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1008
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using UnityEngine;
using AssemblyCSharp;

public class StartingUI : MonoBehaviour
{
	private const string typeName = "UniqueGameName";
	private const string gameName = "RoomName";
	private bool isRefreshingHostList = false;
	private HostData[] hostList;
	public GameObject playerPrefab;
	private float ButtonHeight = 100;
	private float ButtonWidth = 250;
	private float ButtonSpace = 50;

	void OnGUI ()
	{
		if (!Network.isClient && !Network.isServer) 
		{
			if (GUI.Button (new Rect (Screen.width / 2 - ButtonWidth / 2, Screen.height / 2 - 
			                          ButtonHeight - ButtonSpace / 2, 250, 100), "Start Server"))
				StartServer ();
			if (GUI.Button (new Rect (Screen.width / 2 - ButtonWidth / 2, Screen.height / 2 + 
			                          ButtonSpace / 2, 250, 100), "Refresh Hosts"))
				RefreshHostList ();

			if (hostList != null) 
			{
				for (int i = 0; i < hostList.Length; i++) 
				{
					if (GUI.Button (new Rect (400, 100 + (110 * i), 300, 100), hostList [i].gameName))
						JoinServer (hostList [i]);
				}
			}
		}
	}

	private void StartServer ()
	{
			Network.InitializeServer (5, 25000, !Network.HavePublicAddress ());
			MasterServer.RegisterHost (typeName, gameName);
	}

	void OnServerInitialized ()
	{
			SpawnPlayer ();
	}

	void Update ()
	{
			if (isRefreshingHostList && MasterServer.PollHostList ().Length > 0) {
					isRefreshingHostList = false;
					hostList = MasterServer.PollHostList ();
			}
	}

	private void RefreshHostList ()
	{
			if (!isRefreshingHostList) {
					isRefreshingHostList = true;
					MasterServer.RequestHostList (typeName);
			}
	}

	private void JoinServer (HostData hostData)
	{
			Network.Connect (hostData);
	}
		
	void OnConnectedToServer ()
	{
		SpawnPlayer ();
		//Camera.main.transform.
	}
		
		private void SpawnPlayer ()
		{
				Network.Instantiate (playerPrefab, Vector3.up * 5, Quaternion.identity, 0);
		}
}


