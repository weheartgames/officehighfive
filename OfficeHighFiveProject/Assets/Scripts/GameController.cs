using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	public List<Rigidbody> listOfObjects = new List<Rigidbody>();

	public int gameSpeed;

	public Rigidbody hazard;

	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public GUIText scoreText;
	private int score;

	void Start()
	{
		score = 0;
		UpdateScore();

		StartCoroutine (SpawnWaves());

	}
	
	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				MakeHazard();
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
		}
	}

	public void MakeHazard()
	{

		Vector3 spawnPosition = new Vector3(spawnValues.x, spawnValues.y, spawnValues.z);
		Quaternion spawnRotation = Quaternion.identity;
		Rigidbody newHazard = Instantiate (hazard, spawnPosition, spawnRotation) as Rigidbody;
		newHazard.velocity = new Vector3(-1,0,0) * gameSpeed;

	}

	public void AddScore( int newScoreValue )
	{
		score += newScoreValue;
		UpdateScore();
	}

	void UpdateScore()
	{
		scoreText.text = "Score: " + score;
	}
}
