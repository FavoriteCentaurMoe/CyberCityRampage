using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggroRange : MonoBehaviour {
    public ChasePlayer chase_player;

	// Use this for initialization
	void Start () {
        chase_player = GetComponentInParent<ChasePlayer>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            chase_player.inRange = true;
            chase_player.player = collision.transform;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            chase_player.player = null;
        }
    }
}
