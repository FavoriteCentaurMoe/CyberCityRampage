using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBash : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            StunEnemies(collision);

        }
    }

    private void StunEnemies(Collider2D collision)
    {
        collision.transform.SetParent(transform, true);
        collision.gameObject.GetComponent<ChasePlayer>().stunTime = 2f;
        collision.gameObject.GetComponent<ChasePlayer>().stunned = true;
    }
}
