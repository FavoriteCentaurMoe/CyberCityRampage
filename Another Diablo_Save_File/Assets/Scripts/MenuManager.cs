using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    public Button firstButton;
    public Button secondButton;
    public Button thirdButton;
    public Button fourthButton;

    //So far this can only be used by Player 1 

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        checkForButtonPress();
	}

    public void checkForButtonPress()
    {
        if ((Input.GetButton("Ctr 1 A Button") || Input.GetButton("Ctr 2 A Button") || Input.GetButton("Ctr 3 A Button") || Input.GetButton("Ctr 4 A Button")) && firstButton != null)
        {
            firstButton.onClick.Invoke();
        }
        if ((Input.GetButton("Ctr 1 B Button") || Input.GetButton("Ctr 2 B Button") || Input.GetButton("Ctr 3 B Button") || Input.GetButton("Ctr 4 B Button")) & secondButton != null)
        {
            Debug.Log("Yes,you are trying to quit it seesm");
            secondButton.onClick.Invoke();
        }
        if ((Input.GetButton("Ctr 1 X Button") || Input.GetButton("Ctr 2 X Button") || Input.GetButton("Ctr 3 X Button") || Input.GetButton("Ctr 4 X Button")) & thirdButton != null)
        {
            //Debug.Log("Yes,you are trying to quit it seesm");
            thirdButton.onClick.Invoke();
        }
        if ((Input.GetButton("Ctr 1 Y Button") || Input.GetButton("Ctr 2 Y Button") || Input.GetButton("Ctr 3 Y Button") || Input.GetButton("Ctr 4 Y Button")) & fourthButton != null)
        {
            //Debug.Log("Yes,you are trying to quit it seesm");
            fourthButton.onClick.Invoke();
        }
    }
}
