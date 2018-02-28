using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : MonoBehaviour {
    public float knockDist = 1.5f;
    public WarriorController warrior_controller;


	// Use this for initialization
	void Start () {
        warrior_controller = gameObject.GetComponentInParent<WarriorController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            //Vector3 collider_pos = collision.gameObject.transform.position;
            collision.gameObject.GetComponent<EnemyController>().HurtEnemy(warrior_controller.strength);
            
            collision.gameObject.GetComponent<ChasePlayer>().attackFrom = GetComponentInParent<PlayerMovement>().lastDirection;
            collision.gameObject.GetComponent<ChasePlayer>().knockBackDistance = knockDist;
            collision.gameObject.GetComponent<ChasePlayer>().knockBack = true;


            warrior_controller.currentRage += 3;
        }
    }
}
