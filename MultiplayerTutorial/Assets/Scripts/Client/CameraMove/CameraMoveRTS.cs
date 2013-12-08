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

	void Start () {
		
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




	}
	
	
	
}
