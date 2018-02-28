using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBash : MonoBehaviour {
    public float knockDist = 2f;
    public float stunDuration = 1f;

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
        //collision.transform.SetParent(transform, true);
        collision.gameObject.GetComponent<ChasePlayer>().stunTime = stunDuration;
        collision.gameObject.GetComponent<ChasePlayer>().stunned = true;
        collision.gameObject.GetComponent<ChasePlayer>().attackFrom = GetComponentInParent<PlayerMovement>().lastDirection;
        collision.gameObject.GetComponent<ChasePlayer>().knockBackDistance = knockDist;
        collision.gameObject.GetComponent<ChasePlayer>().knockBack = true;

    }
}
