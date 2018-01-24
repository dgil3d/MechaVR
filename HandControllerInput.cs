using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandControllerInput : MonoBehaviour {

	public SteamVR_TrackedObject trackedObj;
	//public SteamVR_TrackedObject trackedObj2;
	public SteamVR_Controller.Device device;
	//public SteamVR_Controller.Device device2;

	public GameObject player;
	public Rigidbody rb;
	private Vector3 movementDirection;
	public Transform playerCam;

	public float movementSpeed = 5f;
	private float rotationSpeed = 10f;
	
	public Animation anim;
	public AudioSource audio;

	public bool isMoving;
	private bool hasPlayed = false;

	public Projectile projectile;

	void Start () 
	{
		trackedObj = GetComponent<SteamVR_TrackedObject>();
		rb = player.GetComponent<Rigidbody>();
		anim = player.GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		//Move Forward
		if(device.GetPress(SteamVR_Controller.ButtonMask.Grip))
		{
			movementDirection = playerCam.transform.forward;
			movementDirection = new Vector3(movementDirection.x, 0, movementDirection.z);
			movementDirection = movementDirection * movementSpeed * Time.deltaTime;
			rb.MovePosition(transform.position + transform.forward * Time.deltaTime);
			player.transform.position += movementDirection;
			//rb.MovePosition(transform.position + (transform.forward* Time.fixedDeltaTime * movementSpeed));
			isMoving = true;
		}
		else 
		{
			isMoving = false;
		}

		//Turning Rotation
		if (device.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
    	{
	        Vector2 touchpad = (device.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0));

	        if (touchpad.x > 0.7f)
	        {
	            player.transform.Rotate (Vector3.up * (rotationSpeed * Time.deltaTime));
				isMoving = true;

	        }

	        else if (touchpad.x < -0.7f)
	        {
	            player.transform.Rotate (-Vector3.up * (rotationSpeed * Time.deltaTime));
				isMoving = true;
	        }

    	}

    	//Main Gun Shooting
		if(device.GetPress(SteamVR_Controller.ButtonMask.Trigger))
        {
            projectile.Fire();
        }
        else if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            projectile.audio1.Stop();
            projectile.audio2.Play();
        }

	}

	void Update () 
	{
		device = SteamVR_Controller.Input((int)trackedObj.index);

		//Animation Trigger
		if(isMoving)
		{
			anim.Play();
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
		}
	}
}
