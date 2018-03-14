using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggroRange : MonoBehaviour {
    public ChasePlayer chase_player = null;
    public ShootPlayer shoot_player = null;
    public bool chasing;
	// Use this for initialization
	void Start () {
        if(chasing)
        {
            chase_player = GetComponentInParent<ChasePlayer>();
        }
        else
        {
            shoot_player = GetComponentInParent<ShootPlayer>();
        }
        
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(chasing)
            {
                chase_player.inRange = true;
                chase_player.player = collision.transform;
            }
            else
            {
                shoot_player.inRange = true;
                shoot_player.player = collision.transform;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(chasing)
            {
                chase_player.inRange = false;
                chase_player.player = null;
            }
            else
            {
                shoot_player.inRange = false;
                shoot_player.player = null;
            }

        }
    }
}
