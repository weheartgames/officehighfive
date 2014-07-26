using UnityEngine;
using System.Collections;

public class ScorePointsForWalls : MonoBehaviour {

	public GameController gameController;
	public int multiplier;

	void Start()
	{
		multiplier = 1;

		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent<GameController>();
		}
	}

	void OnTriggerEnter(Collider other) 
	{
		
			
		if (other.tag == "Obstacle")
		{
			Debug.Log("score a wall");
			gameController.AddScore(1 * multiplier);
			gameController.AddWallsPassed(1);
		}

	}
}
