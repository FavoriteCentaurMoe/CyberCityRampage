using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowGrenadeRadius : MonoBehaviour {

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
            collision.gameObject.GetComponent<EnemyController>().SlowEnemy(3, 2);
            collision.gameObject.GetComponent<EnemyController>().HurtEnemy(5f);
        }
    }
}
