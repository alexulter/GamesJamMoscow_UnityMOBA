using UnityEngine;
using System.Collections;

public class CameraMoveRTS : MonoBehaviour {

	//Скорость движения камеры
	public float moveSpeed = 10f;

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
	
		//Идет проверка для нижнего края экрана	
		if (Input.mousePosition.y < 20 && Input.mousePosition.y<=prevY){
			y = moveSpeed * Input.GetAxis ("Mouse Y");

		} 
		//Идет проверка для верхнего края экрана	
		else if(Input.mousePosition.y > Screen.height-20&&Input.mousePosition.y >= prevY){
			y = moveSpeed * Input.GetAxis ("Mouse Y");

		}
		else {y=0;} ;

		//Идет проверка для левого края экрана	
		if (Input.mousePosition.x < 20 && Input.mousePosition.x<=prevX){
			x = moveSpeed * Input.GetAxis ("Mouse X");

		} 

		//Идет проверка для правого края экрана	
		else if(Input.mousePosition.x > Screen.width-20&&Input.mousePosition.x >= prevX){
			x = moveSpeed * Input.GetAxis ("Mouse X");

		}
		else {x=0;} ;

		prevY=Input.mousePosition.y;
		prevX=Input.mousePosition.x;

		//Устанавливается новое положение камеры, с условием, что ось Х камеры парралельна оси Х области
		transform.Translate(x,y,y);
	}
	
	
	
}
