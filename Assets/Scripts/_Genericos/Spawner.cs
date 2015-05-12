using UnityEngine;
using System.Collections;



public class Spawner : MonoBehaviour
{

	[Header("Tiempo entre cada spawn")]
	public float spawnTime = 5f;		// The amount of time between each spawn.
	[Header("Tiempo cuando comienza")]
	public float spawnDelay = 3f;		// The amount of time before spawning starts.
	[Header("Array de enemigos")]
	public GameObject[] enemies;		// Array of enemy prefabs.
	[Header("En el caso de que debas unirlo a un padre")]
	public bool tienePadre = false;
	public GameObject elPadre;
	[Header("Aumento en la escala del gameobject")]
	public float prefabsScale = 1;
	[Header("Tiempo que tarda en llegar a la siguiente pos")]
	public float tiempoMovimiento = 3.0f;
	[Header("Tiempo espera en la posicion")]
	public float tiempoDeEspera = 10.0f;
	[Header("Matriz de posiciones")]
	public PositionsList[] gameObjectsPositionsMatrix;
	[Header("Gamecontroller")]
	public DestruyeGameController gameController;
	[Header("Nombre de la etiqueta para encontralos")]
	public string nombreTag = "Enemy";
	private float levelNumber =1;
	[System.Serializable]
	public class PositionsList
	{
		public GameObject[] posColumnas;
	}

	public void CancelInvokeRepeiting(){
		CancelInvoke ();
	}

	void OnEnable ()
	{
		levelNumber = (gameController.LevelNumber ()!=0) ? gameController.LevelNumber() /2 : 0;

		if (levelNumber < 0)
			levelNumber = 0;
		float spawnDelayAux = spawnDelay - levelNumber;
		float spawnTimeAux = spawnTime - levelNumber;
		if (spawnDelayAux <= 5)
			spawnDelayAux = 5;
		if (spawnTimeAux <= 1)
			spawnTimeAux = 1;

		InvokeRepeating("Spawn", spawnDelayAux, spawnTimeAux);
	}


	void Spawn ()
	{
		// Instantiate a random enemy.
		int enemyIndex = Random.Range(0, enemies.Length);
		GameObject objectIncreaseSize = Instantiate (enemies [enemyIndex], transform.position, transform.rotation) as GameObject;

		objectIncreaseSize.tag= nombreTag;

		objectIncreaseSize.transform.localScale = Vector3.one * prefabsScale;
		if (tienePadre) {
			objectIncreaseSize.transform.parent = elPadre.transform;

		} 
		MoveToAnObjectPosition moveToAnObjectPosition = objectIncreaseSize.GetComponent<MoveToAnObjectPosition>();

	
		GameObject[] temporal = new GameObject[gameObjectsPositionsMatrix.Length];
		// para recorrer la matrix completa
		int i = 0;
		foreach (PositionsList filas in gameObjectsPositionsMatrix){
			// recorremos las filas para obtener una columna de forma aleatoria
			// random.range(inclusive,exclusive) aleatorio entre esos valores.
			temporal[i] = filas.posColumnas[Random.Range(0, filas.posColumnas.Length)];
			i++;
			//foreach (GameObject cols in filas.posColumnas){
			//}
		}
		moveToAnObjectPosition.posicionesObjecto = temporal;

		float tiempoMovimientoAux =  tiempoMovimiento  -levelNumber;
		float tiempoDeEsperaAux = tiempoDeEspera - levelNumber;
		if (tiempoMovimientoAux <= 2)
			tiempoMovimientoAux = 2;
		if (tiempoDeEsperaAux <= 4)
			tiempoDeEsperaAux = 4;

		moveToAnObjectPosition.tiempoMovimiento = tiempoMovimientoAux;
		moveToAnObjectPosition.tiempoDeEspera = tiempoDeEsperaAux;



		// Play the spawning effect from all of the particle systems.
		foreach(ParticleSystem p in GetComponentsInChildren<ParticleSystem>())
		{
			p.Play();
		}
	}
}
