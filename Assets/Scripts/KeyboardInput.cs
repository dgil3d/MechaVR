using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour {

	public GameObject player;
	public Rigidbody rb;
	private float movementSpeed = 6f;
	private float rotationSpeed = 10f;
	
	public Animation anim;
	public AudioSource audio;

	public bool isMoving;
	private bool hasPlayed = false;

	void Start () 
	{
	rb = player.GetComponent<Rigidbody>();
	anim = player.GetComponent<Animation>();

	}
	
	void FixedUpdate () 
	{
		if (Input.GetKey(KeyCode.W))
		{

			rb.MovePosition(transform.position + (transform.forward* Time.fixedDeltaTime * movementSpeed));
			isMoving = true;
			//Debug.Log("Moving forward");
		}
		else if (Input.GetKey(KeyCode.S))
		{

			rb.MovePosition(transform.position + (-transform.forward* Time.fixedDeltaTime * movementSpeed));
			isMoving = true;
			//Debug.Log("Moving backward");
		}	
		else if (Input.GetKey(KeyCode.D))
		{

			transform.Rotate (Vector3.up * (rotationSpeed * Time.deltaTime));
			isMoving = true;
			//Debug.Log("Rotating Right");
		}		
		else if (Input.GetKey(KeyCode.A))
		{

			transform.Rotate (-Vector3.up * (rotationSpeed * Time.deltaTime));
			isMoving = true;
			//Debug.Log("Rotating Left");
		}
		else 
		{
			isMoving = false;
		}
	}

	void Update () 
	{

		if(isMoving)
		{
			anim.Play();
			Debug.Log("Animation On");

			if(hasPlayed == false)
			{
				hasPlayed = true;
				audio.Play();
			}
		}
		else 
		{
			anim.Stop();
			hasPlayed = false;
			audio.Stop();
			Debug.Log("Animation Off");
		}
	}
}
