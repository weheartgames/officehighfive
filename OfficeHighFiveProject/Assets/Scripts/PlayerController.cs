using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Transform playerTransform;
	private int currentLane;
	public Vector3 targetPosition = new Vector3 (0,0,5f);
	public float moveSpeed = 1;

	public float jumpSpeed = 100.0f;

	public GameObject audioHitWall;
	public GameObject audioHiFive;

	public int multiplier;
	public GUIText multiplierText;

	private bool gameOver;

	public Animator playerAnimation;

	void Start()
	{
		playerTransform = transform;
		currentLane = 0;
		multiplier = 1;
		multiplierText.text = "Multiplier: 1";
	}

	void Update(){
		multiplierText.text = "Multiplier: " + multiplier;

		if (Input.GetButtonDown("Fire1")) 
		{
			if (currentLane == 0)
			{
				currentLane = 1;
			} 
			else
			{
				currentLane = 0;
			}
		}

		if (currentLane == 0 && playerTransform.position.z >= 0){
			//playerTransform.position = Vector3.zero;
			
			playerTransform.Translate (new Vector3 (0,0,-moveSpeed) * Time.deltaTime);
		} else if (currentLane == 1 && playerTransform.position.z <= 5){
			playerTransform.Translate (new Vector3(0,0,moveSpeed) * Time.deltaTime);
		}

		if (Input.GetButtonDown("Fire2") && playerTransform.position.y <= 0) 
		{
			//JUMP
			//animation.Play("jump_pose");
			rigidbody.AddForce(Vector3.up * jumpSpeed);

			audio.Play ();
		}

		if (gameOver == true && Input.anyKey)
		{
			Time.timeScale = 1.0F;
			Application.LoadLevel("MainScene");
		}
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Boundary")
		{
			return;
		}
	
			
		if (other.tag == "Female" || other.tag == "Male")
		{
			//Increase multiplier

			multiplier++;
			multiplierText.text = "Multiplier: " + multiplier;
			other.tag = "TaggedPerson";
			audioHiFive.audio.Play();
			playerAnimation.SetTrigger("isHighFiving");
			return;
		}

		Debug.Log (other.tag);
		//Destroy(other.gameObject);
		//Destroy(gameObject);
		Time.timeScale = 0.0F;
		audioHitWall.audio.Play();
		gameOver = true;
		//Debug.Log("Game is over: " + gameOver);
	}
	
}
