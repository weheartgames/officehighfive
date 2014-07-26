using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public float levelSpeed;

	void Start()
	{
		rigidbody.velocity = transform.position += Vector3.back * levelSpeed * Time.deltaTime;

	}
}
