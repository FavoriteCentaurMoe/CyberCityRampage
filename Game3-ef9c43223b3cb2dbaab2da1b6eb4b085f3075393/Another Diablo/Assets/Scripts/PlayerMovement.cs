using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {
    private Rigidbody2D rb2d;
    public float speed;
    public bool stunned; // turning stunned true and false can be handled in the respective player controllers (and duration)
    public float lastDirection;
    public Animator anim;
    Vector3 theScale;
    void Start() {
        //currenthealth = health;
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        stunned = false;
    }

    // Update is called once per frame
    void Update() {
        //anim.SetFloat("Horizontal", Input.GetAxis("Left Joystick Horizontal"));
        //anim.SetFloat("Vertical", Input.GetAxis("Left Joystick Vertical"));
        if(Input.GetAxis("Left Joystick Horizontal") == 0 && Input.GetAxis("Left Joystick Vertical") == 0)
        {
            anim.SetBool("Idle", true);

        }
        else
        {
            anim.SetBool("Idle", false);
        }
        if (!stunned) // not stunned
        {
            rb2d.transform.position += new Vector3(Input.GetAxis("Left Joystick Horizontal"), -Input.GetAxis("Left Joystick Vertical"), 0) * Time.deltaTime * speed;
            if (Input.GetAxis("Left Joystick Horizontal") < 0){
                lastDirection = Input.GetAxis("Left Joystick Horizontal");
            }
            else if(Input.GetAxis("Left Joystick Horizontal") > 0)
            {
                lastDirection = Input.GetAxis("Left Joystick Horizontal");
            }
            PlayerFacing();
        }
        // stunned
        // will not be able to move
    
    }

    public void PlayerFacing()
    {
        if(lastDirection > 0)
        {
            transform.localScale = new Vector3(5, 5, 5);
        }
        else if(lastDirection < 0)
        {
            transform.localScale = new Vector3(-5, 5, 5);
        }
    }

    
}
