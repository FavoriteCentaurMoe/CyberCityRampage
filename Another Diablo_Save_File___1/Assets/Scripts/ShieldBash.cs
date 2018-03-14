using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBash : MonoBehaviour {
    public float knockDist;
    public float stunDuration;

	// Use this for initialization
	void Start () {
        knockDist = 5f;
        stunDuration = 1f;
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
        if (collision.gameObject.GetComponent<EnemyController>().chase_player != null)
        {
            collision.gameObject.GetComponent<ChasePlayer>().stunTime = stunDuration;
            collision.gameObject.GetComponent<ChasePlayer>().stunned = true;
            collision.gameObject.GetComponent<ChasePlayer>().attackFrom = GetComponentInParent<PlayerMovement>().lastDirection;
            collision.gameObject.GetComponent<ChasePlayer>().knockBackDistance = knockDist;
            collision.gameObject.GetComponent<ChasePlayer>().knockBack = true;
        }
        else if (collision.gameObject.GetComponent<EnemyController>().shoot_player != null)
        {
            collision.gameObject.GetComponent<ShootPlayer>().stunTime = stunDuration;
            collision.gameObject.GetComponent<ShootPlayer>().stunned = true;
            collision.gameObject.GetComponent<ShootPlayer>().attackFrom = GetComponentInParent<PlayerMovement>().lastDirection;
            collision.gameObject.GetComponent<ShootPlayer>().knockBackDistance = knockDist;
            collision.gameObject.GetComponent<ShootPlayer>().knockBack = true;
        }

    }
}
