using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public float levelSpeed;
	
	void Start()
	{
		rigidbody.velocity = new Vector3(-1,0,0) * levelSpeed;
	}


}
