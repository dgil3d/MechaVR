using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Crosshair : MonoBehaviour {

public Texture2D crosshairTexture;
public float crosshairScale = 1;

public float range = 50f;

public Vector3 directionRay;
public Vector3 point;
public Vector3 fwd;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		//fwd = transform.TransformDirection(Vector3.forward);
		
		
	}

	
    
    void OnGUI()
    {
        //if not paused
        if(Time.timeScale != 0)
        {
        	//GUI.DrawTexture(new Rect(10, 10, 60, 60),crosshairTexture);
        	//GUI.DrawTexture(new Rect(Screen.width/2 , Screen.height/2,100,100),crosshairTexture);
        }
    }

    

}
