using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {

//	// Use this for initialization
//	void Start () {
//	
//	}
//	
	// Update is called once per frame
	void Update () {
		int DistanceAwayZ = 10;
		int DistanceAwayY = -4; // Это расстояние по высоте. Отрицательное, потому что потом я вычитаю

		/// Ищем клон префаба
		GameObject player = GameObject.Find ("Player(Clone)");
		if (player) 
		{
			/// Берем координаты из префаба игрока
			Vector3 PlayerPOS = player.transform.transform.position;
				
			/// Обновляем положение камеры
			GameObject.Find ("Main Camera").transform.position = new Vector3 (PlayerPOS.x, PlayerPOS.y - DistanceAwayY, PlayerPOS.z - DistanceAwayZ);	
					
		}
	}
}
