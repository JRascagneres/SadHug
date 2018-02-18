using UnityEngine;
using System.Collections;

//-- This whole class was added for Assessment 3

/// <summary>
/// Script that spawns the waves of enemies
/// </summary>
public class WaveSpawner : MonoBehaviour {

    //different states within the game
	public enum SpawnState { SPAWNING, WAITING, COUNTING };

	[System.Serializable]
    /// <summary>
    /// Class that has parameters for each wave
    /// </summary>
    public class Wave
	{
		public string name;
		public Transform enemy;
		public int count;
		public float rate;
	}

	public Wave[] waves;
	private int nextWave = 0;

    /// <summary>
    /// Returns int for the next wave
    /// </summary>
    public int NextWave
	{
		get { return nextWave + 1; }
	}

    /// <summary>
    /// Array of spawn points in the scene
    /// Wait between the different waves defaulted to 5 secs
    /// </summary>
    public Transform[] spawnPoints;
	public float timeBetweenWaves = 5f;
	private float waveCountdown;

    /// <summary>
    /// returns the float time for the wave countdown
    /// </summary>
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

    /// <summary>
    /// Checks If there are no spawn point referenced then logs an error
    /// </summary>
	void Start()
	{
		if (spawnPoints.Length == 0)
		{
			Debug.LogError("No spawn points referenced.");
		}

		waveCountdown = timeBetweenWaves;
	}

    /// <summary>
    /// Checks If no enemy is alive by calling <see cref="WaveSpawner.EnemyIsAlive"/> 
    /// then calls the wave completed method <see cref="WaveSpawner.WaveCompleted"/>
    /// </summary>
	void Update()
	{
		if (state == SpawnState.WAITING)
		{
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

    /// <summary>
    /// Method when wave is completed 
    /// </summary>
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

    /// <summary>
    /// Test whether there is an enemy alive in the scene view
    /// </summary>
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

    /// <summary>
    /// Spawn wave function
    /// </summary>
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

    /// <summary>
    /// Spawn enemy function
    /// </summary>
    void SpawnEnemy(Transform _enemy)
	{
		Debug.Log("Spawning Enemy: " + _enemy.name);

		Transform _sp = spawnPoints[ Random.Range (0, spawnPoints.Length) ];
		Instantiate(_enemy, _sp.position, _sp.rotation);
	}

}
