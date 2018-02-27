using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character1Controller : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButton("A Button"))
        {
            Debug.Log("A button pressed");
        }
        Debug.Log("Controller 1 Right Joystick Horizontal = " + Input.GetAxis("Right Joystick Horizontal"));
        //{
        //    Debug.Log("Right Joystick Horizontal pressed");
        //}
        //if (Input.GetAxis("Right Joystick Vertical") != 0)
        //{
        //    Debug.Log("Right Joystick Vertical pressed");
        //}
    }
}
