using UnityEngine;
using System.Collections;

public class WaveSpawner : MonoBehaviour {


    //different states within the game
	public enum SpawnState { SPAWNING, WAITING, COUNTING };

	[System.Serializable]
	public class Wave
	{
        //Parameters for each wave
		public string name;
		public Transform enemy;
		public int count;
		public float rate;
	}

    //Array for waves
	public Wave[] waves;
	private int nextWave = 0;

    //Returns int of next wave
	public int NextWave
	{
		get { return nextWave + 1; }
	}

    //Array of spawn points in the scene
	public Transform[] spawnPoints;

    //Wait between the different waves defaulted to 5 secs
	public float timeBetweenWaves = 5f;
	private float waveCountdown;

    //returns the float time for the wave countdown
	public float WaveCountdown
	{
		get { return waveCountdown; }
	}

	private float searchCountdown = 1f;

    //Changes spawn state to counting
	private SpawnState state = SpawnState.COUNTING;

    //Returns current spawn state
	public SpawnState State
	{
		get { return state; }
	}

	void Start()
	{
        //If there are no spawn point referenced
		if (spawnPoints.Length == 0)
		{
			Debug.LogError("No spawn points referenced.");
		}

		waveCountdown = timeBetweenWaves;
	}

	void Update()
	{
		if (state == SpawnState.WAITING)
		{
            //If no enemy is alive calls the wave completed method
			if (!EnemyIsAlive())
			{
				WaveCompleted();
			}
			else
			{
				return;
			}
		}

		if (waveCountdown <= 0)
		{
            //Spawns next wave
			if (state != SpawnState.SPAWNING)
			{
				StartCoroutine( SpawnWave ( waves[nextWave] ) );
			}
		}
		else
		{
			waveCountdown -= Time.deltaTime;
		}
	}

    //Method when wave is completed 
	void WaveCompleted()
	{
		Debug.Log("Wave Completed!");

		state = SpawnState.COUNTING;
		waveCountdown = timeBetweenWaves;

		if (nextWave + 1 > waves.Length - 1)
		{
			nextWave = 0;
			Debug.Log("ALL WAVES COMPLETE! Looping...");
		}
		else
		{
			nextWave++;
		}
	}

    //Test whether there is an enemy alive in the scene view
	bool EnemyIsAlive()
	{
		searchCountdown -= Time.deltaTime;
		if (searchCountdown <= 0f)
		{
			searchCountdown = 1f;
			if (GameObject.FindGameObjectWithTag("Enemy") == null)
			{
				return false;
			}
		}
		return true;
	}

    //Spawn wave function
	IEnumerator SpawnWave(Wave _wave)
	{
		Debug.Log("Spawning Wave: " + _wave.name);
		state = SpawnState.SPAWNING;

		for (int i = 0; i < _wave.count; i++)
		{
			SpawnEnemy(_wave.enemy);
			yield return new WaitForSeconds( 1f/_wave.rate );
		}

		state = SpawnState.WAITING;

		yield break;
	}

    //Spawn enemy function
	void SpawnEnemy(Transform _enemy)
	{
		Debug.Log("Spawning Enemy: " + _enemy.name);

		Transform _sp = spawnPoints[ Random.Range (0, spawnPoints.Length) ];
		Instantiate(_enemy, _sp.position, _sp.rotation);
	}

}
