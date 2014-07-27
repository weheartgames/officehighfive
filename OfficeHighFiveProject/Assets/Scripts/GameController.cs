using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	public List<Rigidbody> listOfObjects = new List<Rigidbody>();
	public List<Rigidbody> listOfPeople = new List<Rigidbody>();

	public int gameSpeed;

	public Rigidbody hazard;

	public Vector3 spawnValues;
	public Vector3 person1SpawnValues;
	public Vector3 person2SpawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	
	public float personStartWait;
	private int personPositionSetter;

	public GUIText scoreText;
	private int score;
	public GUIText finalScoreText;

//	private int multiplier;

	public GUIText wallsPassedText;
	private int wallsPassed;

	void Update(){
		if (Time.timeScale == 0.0F)
		{
			finalScoreText.text = "" + score;
		}
	}

	void Start()
	{
		score = 0;
		finalScoreText.text = "";
		UpdateScore();
		UpdateWallsPassed();

		StartCoroutine (SpawnWaves());
		StartCoroutine (SpawnPeople());
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

	IEnumerator SpawnPeople()
	{
		yield return new WaitForSeconds (personStartWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				MakePerson();
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
		}
	}

	public void MakeHazard()
	{

		Vector3 spawnPosition = new Vector3(spawnValues.x, spawnValues.y, spawnValues.z);
		Quaternion spawnRotation = Quaternion.identity;
		Rigidbody newHazard = Instantiate (listOfObjects[Random.Range (0, listOfObjects.Count)], spawnPosition, spawnRotation) as Rigidbody;

		newHazard.velocity = new Vector3(-1,0,0) * gameSpeed;

	}

	public void MakePerson()
	{

		Quaternion spawnRotation = Quaternion.identity;

		personPositionSetter = Random.Range (1,3);
		if (personPositionSetter == 1)
		{
			Vector3 spawnPosition = new Vector3(person1SpawnValues.x, person1SpawnValues.y, person1SpawnValues.z);
			Rigidbody newPerson = Instantiate (listOfPeople[Random.Range (0, listOfPeople.Count)], spawnPosition, spawnRotation) as Rigidbody;
			newPerson.velocity = new Vector3(-1,0,0) * gameSpeed;
		} else
		{
			Vector3 spawnPosition = new Vector3(person2SpawnValues.x, person2SpawnValues.y, person2SpawnValues.z);
			Rigidbody newPerson = Instantiate (listOfPeople[Random.Range (0, listOfPeople.Count)], spawnPosition, spawnRotation) as Rigidbody;
			newPerson.velocity = new Vector3(-1,0,0) * gameSpeed;
		}


		
	}

	public void AddScore( int newScoreValue )
	{
		score += newScoreValue;
		UpdateScore();
	}

	public void AddWallsPassed( int newScoreValue )
	{
		wallsPassed += newScoreValue;
		UpdateWallsPassed();
	}

	void UpdateScore()
	{
		scoreText.text = "Score: " + score;
	}

	void UpdateWallsPassed()
	{
		wallsPassedText.text = "Passed: " + wallsPassed;
	}

}
