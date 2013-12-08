using UnityEngine;
using System.Collections;

public class CameraMoveRTS : MonoBehaviour {

	//Скорость движения камеры
	public float moveSpeed = 0.7f;



	//Коордиаты для нового положения камеры
	float x=0;
	float y=0;

	//Координаты старого положения курсора
	float prevX=0;
	float prevY=0;

	private bool LockCamera = false; //центрировать ли камеру на персонаже

	void Start () {
		
	}
	void OnGUI ()
	{
		GUI.Label (new Rect (0,0,300,100), "Пробел - центрировать камеру на герое. Мышка у края экрана - подвинуть камеру");
	}

	// Update is called once per frame
	void Update () {
	
		//Зум по колёсику мыши

		if (Input.GetAxis("Mouse ScrollWheel") < 0) // back
		{
			transform.Translate(0,0,-1);
			
		}
		if (Input.GetAxis("Mouse ScrollWheel") > 0) // forward
		{
			transform.Translate(0,0,1);
		}


		//Идет проверка для нижнего края экрана	
		if (Input.mousePosition.y < 20){
			y = -moveSpeed;

		} 
		//Идет проверка для верхнего края экрана	
		else if(Input.mousePosition.y > Screen.height-20){
			y = moveSpeed;

		}
		else {y=0;} ;

		//Идет проверка для левого края экрана	
		if (Input.mousePosition.x < 20){
			x = -moveSpeed;

		} 

		//Идет проверка для правого края экрана	
		else if(Input.mousePosition.x > Screen.width-20){
			x = moveSpeed;

		}
		else {x=0;} ;

		prevY=Input.mousePosition.y;
		prevX=Input.mousePosition.x;

		//Устанавливается новое положение камеры, с условием, что ось Х камеры парралельна оси Х области, и наклон сделан по оси Х
		transform.Translate(x,y,y);




		//Следим за героем
			int DistanceAwayZ = 3;
			int DistanceAwayX = 3; // Это расстояние по высоте. Отрицательное, потому что потом я вычитаю
			


		if (Input.GetKeyDown (KeyCode.Space)) LockCamera = true;
		if (Input.GetKeyUp (KeyCode.Space)) LockCamera = false;
		if (LockCamera)
		{
			/// Ищем клон префаба
			GameObject player = GameObject.Find ("Player(Clone)");
			if (player) 
			{
				/// Берем координаты из префаба игрока
				Vector3 PlayerPOS = player.transform.position;

								
				/// Обновляем положение камеры
				transform.position = new Vector3 (PlayerPOS.x - DistanceAwayX, transform.position.y, PlayerPOS.z - DistanceAwayZ);	
			}
		}

	}
	
	
	
}
