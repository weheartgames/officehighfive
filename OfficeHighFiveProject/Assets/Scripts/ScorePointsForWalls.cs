using UnityEngine;
using System.Collections;

public class ScorePointsForWalls : MonoBehaviour {

	public GameController gameController;
	private int multiplier;

	GameObject playerControllerObject;
	
	public GameObject audioLostMultiplier;

	void Start()
	{
		multiplier = 1;

		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent<GameController>();
		}

		playerControllerObject = GameObject.FindWithTag ("Player");
		if (playerControllerObject != null)
		{
			multiplier = playerControllerObject.GetComponent<PlayerController>().multiplier;

		}
	}

	void OnTriggerEnter(Collider other) 
	{
		//Debug.Log(other.tag);
		if (other.tag == "Obstacle")
		{
			//score a wall
			multiplier = playerControllerObject.GetComponent<PlayerController>().multiplier;
			gameController.AddScore(1 * multiplier);
			gameController.AddWallsPassed(1);
		}

		if (other.tag == "Female" || other.tag == "Male")
		{
			//reset multiplier
			playerControllerObject.GetComponent<PlayerController>().multiplier = 1;
			audioLostMultiplier.audio.Play();
		}
	}
}
