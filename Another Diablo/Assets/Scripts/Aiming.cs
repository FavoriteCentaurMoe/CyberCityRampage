using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script controls the aiming thing (which is a child of the player). 
//It appears to indicate the direction in which the right joystick is facing

public class Aiming : MonoBehaviour {

    public float range;    
    public int speed;

    private float sizeMultiplier;
    private float vert;
    private float horz;


    public GameObject eternalAimer; //This is the aiming line

    
	void Start () {
        eternalAimer.SetActive(false);
        sizeMultiplier = 1.5f;
	}
	
	// Update is called once per frame
	void Update () {
        vert = -Input.GetAxis("Right Joystick Vertical") * range;
        horz = Input.GetAxis("Right Joystick Horizontal") * range;

        moveAimer();
    }

    void moveAimer()
    {
        eternalAimer.transform.up = new Vector3(Input.GetAxis("Right Joystick Horizontal"), -Input.GetAxis("Right Joystick Vertical"), 0) * Time.deltaTime * speed;
        if (vert != 0 || horz != 0)
        {
            Vector3 linePosition = new Vector3(transform.position.x + horz, transform.position.y + vert, 0);
            float dif = Vector3.Distance(transform.position, linePosition);
            Debug.DrawLine(transform.position, linePosition, Color.blue);
            eternalAimer.SetActive(true);
            eternalAimer.transform.localScale = new Vector3(transform.localScale.x/5, dif * sizeMultiplier);
            float height = GetComponent<SpriteRenderer>().bounds.size.y * (vert);
            float width = GetComponent<SpriteRenderer>().bounds.size.x * horz;
            eternalAimer.transform.position = new Vector2(transform.position.x + width/2, transform.position.y + height/2);
        }
        else
        {
            eternalAimer.SetActive(false);
        }
    }

    public Transform eternalAimerInfo()
    {
        return eternalAimer.transform;
    }
}
