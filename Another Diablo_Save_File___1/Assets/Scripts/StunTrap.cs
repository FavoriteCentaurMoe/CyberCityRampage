using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunTrap : MonoBehaviour {



    //This just calls the StunEnemy function, provides it the time, and the deletes itself after a few seconds 

    public float stunTime;

    public float lifetime = 4f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            Debug.Log("Stun Mine has detected an Enemy");
            collision.gameObject.GetComponent<EnemyController>().HurtEnemy(5f);
            collision.gameObject.GetComponent<EnemyController>().StunEnemy(stunTime);
            Destroy(this.gameObject);
        }
    }

    // Use this for initialization
    void Start () {
        Destroy(gameObject, lifetime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
