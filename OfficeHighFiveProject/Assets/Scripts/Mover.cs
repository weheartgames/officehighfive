using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public float levelSpeed = 10.0f;
	
	void Start()
	{
		rigidbody.velocity = new Vector3(-1,0,0) * levelSpeed;
	}


}
