using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {
    //public Text wintext;
    public string controller_num;
    //public string controller_num = null;
    private Rigidbody2D rb2d;
    public float speed;
    public bool stunned; // turning stunned true and false can be handled in the respective player controllers (and duration)
    public float lastDirection;
    public Animator anim;
    Vector3 theScale;
    void Start() {
        //controller_num = "Ctr 1 "; // for testing
        //currenthealth = health;
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        stunned = false;
        if(controller_num == null)
        {
            Debug.Log("controller not assigned");
        }
        }
    // Update is called once per frame
    void Update() {
        if(Input.GetAxis( controller_num + "Left Joystick Horizontal") == 0 && Input.GetAxis(controller_num + "Left Joystick Vertical") == 0)
        {
            anim.SetBool("Idle", true);

        }
        else
        {
            anim.SetBool("Idle", false);
        }
        if (!stunned) // not stunned
        {
            rb2d.transform.position += new Vector3(Input.GetAxis(controller_num + "Left Joystick Horizontal"), -Input.GetAxis(controller_num + "Left Joystick Vertical"), 0) * Time.deltaTime * speed;
            if (Input.GetAxis(controller_num + "Left Joystick Horizontal") < 0){
                lastDirection = Input.GetAxis(controller_num + "Left Joystick Horizontal");
            }
            else if(Input.GetAxis(controller_num + "Left Joystick Horizontal") > 0)
            {
                lastDirection = Input.GetAxis(controller_num + "Left Joystick Horizontal");
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
            transform.localScale = new Vector3(10, 10, 1);
        }
        else if(lastDirection < 0)
        {
            transform.localScale = new Vector3(-10, 10, 1);
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Portal")
    //    {
    //        wintext.gameObject.SetActive(true);
    //    }
    //}


}
