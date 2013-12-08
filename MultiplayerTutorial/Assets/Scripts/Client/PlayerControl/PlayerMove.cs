using UnityEngine;
using System.Collections;



public class PlayerMove : MonoBehaviour {



	//Переменные для работы с расстноянием

	//Переменные для вычисления дистанции
	float x_dist=0;
	float z_dist=0;

	//Переменные для получения направления
	float x_direction=0;
	float z_direction=0;

	//Переменные для получения абсолютной дистации по модулю
	float dx;
	float dz;

	//Переменные для создания луча, определяющего координаты клика по карте
	Ray ray;
	RaycastHit hit;

	//Хранилища для текущей позиции объекта(в момент клика) и для конечной точки(место клика)
	Vector3 curPos;
	Vector3 targetPos;

	//Переменная , по которой идет проверка, будет ли двигаться объект
	bool move=false;
	bool flagx=false;
	bool flagz=false;

	//Скорость объекта
	public float speed=0.15f;

	//Переменные, для получения mesh из текущего объекта, чтобы можно было вычислить реальный размер
	MeshFilter[] mfs;
	Bounds b;

	void Start () {
		//Вызываем функцию, которая вычисляет размер нашего меша
		extractMeshBounds ();
	}


	// Update is called once per frame
	void Update () {


		//Получаем луч для той точки, в которую направлен наш курсор
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Physics.Raycast (ray,out hit, 100);
		Debug.DrawLine(ray.origin, hit.point);


		//Проверка на нажатие правой кнопки мыши
		if(Input.GetMouseButtonDown(1)){

			//Получаем текущую позицию игрока
			curPos = transform.position;
			//Сохраняем конечную позицию
			targetPos = new Vector3(hit.point.x,0.5f,hit.point.z);
			//Переключаем флаг для обработки движения игрока
			move=true;
			//Вычисляем расстояние по осям X и Z
			x_dist=hit.point.x-transform.position.x;
			z_dist=hit.point.z-transform.position.z;
			//Получаем знак движения по осям
			if(x_dist>0){x_direction=1;}else{x_direction=-1;};
			if(z_dist>0){z_direction=1;}else{z_direction=-1;};
			//Получаем абсолютное значение расстояния
			dx=Mathf.Abs(x_dist);
		    dz=Mathf.Abs(z_dist);

			flagx=true;
			flagz=true;

		}
		//Вызов метода движения, если флаг движения равен true
		if(move)moveToTarget ();
	}

	//Метод, который двигает объект
	void moveToTarget(){

		//Устанавливаем приращение движения в ноль
	//	x_dist=0;
	//	z_dist=0;

		z_dist=speed*z_direction;
		x_dist=speed*x_direction;
		//Проверка, нужно ли приращение по той или иной оси

		if(dz>=0){
			//z_dist=speed*z_direction;
			//dz=dz*z_direction;
			dz=dz-speed;
		}else{
			flagz=false;
			z_dist=0;
		//	transform.position  = new Vector3(transform.position.x,0.5f,targetPos.z);
		};

		if(dx>=0){
			//x_dist=speed*x_direction;
			//dx=dx*x_direction;
			dx=dx-speed;
		}else{
			x_dist=0;
			//transform.position  = new Vector3(targetPos.x,0.5f,transform.position.z);
			flagx=false;
		};

	
		Debug.Log("player x: " + transform.position.x + "  player z: " +transform.position.z + 
		          " x direction: " + x_direction + " z direction: " + z_direction +
		          " x-sterp: " + x_dist + " z-step: " + z_dist + 
		          " dx: " + dx + " dz: " +dz +

		          " move status: " + move 
		          );
		//Двигаем игрока на нужное расстояние
		transform.Translate (x_dist, 0, z_dist);
		//transform.position  = new Vector3(transform.position.x+x_dist,0.5f,transform.position.z+z_dist);
	
		//Проверка условий, если модель игрока примерно попала в область куда было указано идти, то флаг движения переходит в false
	if (transform.position.x + b.size.x / 2 >= targetPos.x && transform.position.x - b.size.x / 2 <= targetPos.x) {
			if(transform.position.z+b.size.z/2>=targetPos.z && transform.position.z-b.size.z/2<=targetPos.z)

		//if(!(flagx&&flagz))
		//{
			move = false;
			//x_direction=0;
			//z_direction=0;
			//x_dist=0;
			//z_dist=0;
	//		dx=0;
	//		dz=0;
				}



		
	}

	//Метод извлекающий базовый mesh для модели игрока
	void extractMeshBounds(){


		mfs = transform.gameObject.GetComponentsInChildren<MeshFilter>();

		if (mfs.Length>0) {
			b = mfs[0].mesh.bounds;
			for (int i=1; i<mfs.Length; i++) {
				b.Encapsulate(mfs[i].mesh.bounds);
			}
			

		}



	}
}
