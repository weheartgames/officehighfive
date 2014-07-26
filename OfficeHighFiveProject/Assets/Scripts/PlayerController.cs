using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Transform playerTransform;
	private int currentLane;
	public Vector3 targetPosition = new Vector3 (0,0,3f);
	public float moveSpeed = 1;

	public float jumpSpeed = 100.0f;

	void Start()
	{
		playerTransform = transform;
		currentLane = 0;
	}

	void Update(){
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
		} else if (currentLane == 1 && playerTransform.position.z <= 3){
			playerTransform.Translate (new Vector3(0,0,moveSpeed) * Time.deltaTime);
		}

		if (Input.GetButtonDown("Fire2") && playerTransform.position.y <= 0) 
		{
			//animation.Play("jump_pose");
			rigidbody.AddForce(Vector3.up * jumpSpeed);
		}

	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Boundary")
		{
			return;
		}
		Debug.Log (other.name);
		Destroy(other.gameObject);
		Destroy(gameObject);
		Time.timeScale = 0.0F;
	}
	
}
