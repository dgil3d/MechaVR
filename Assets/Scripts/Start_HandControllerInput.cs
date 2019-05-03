using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class Start_HandControllerInput : MonoBehaviour {


	public SteamVR_TrackedObject trackedObj;
	//public SteamVR_TrackedObject trackedObj2;
	public SteamVR_Controller.Device device;
	//public SteamVR_Controller.Device device2;
	private SteamVR_LaserPointer laser;

	//private LineRenderer laser;
	public Vector3 selection;
	

	void Start () 
	{
		trackedObj = GetComponent<SteamVR_TrackedObject>();

		laser = GetComponent<SteamVR_LaserPointer>();

	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		

		if(device.GetPress(SteamVR_Controller.ButtonMask.Trigger))
        {
        	
			if (EventSystem.current.currentSelectedGameObject != null)
        	{
            	ExecuteEvents.Execute(EventSystem.current.currentSelectedGameObject, new PointerEventData(EventSystem.current), ExecuteEvents.submitHandler);
	        }

			


    	}

	}

	void Update () 
	{
		device = SteamVR_Controller.Input((int)trackedObj.index);
	}

	public void Selection()
	{
		RaycastHit hit; //Laser's endpoint
		if(Physics.Raycast(transform.position, transform.forward, out hit, 100))
		{
			selection = hit.point;
		}
	}
}
