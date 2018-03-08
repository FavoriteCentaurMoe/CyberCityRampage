using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : MonoBehaviour {
    public float knockDist;
    public WarriorController warrior_controller;


	// Use this for initialization
	void Start () {
        knockDist = 1.5f;
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
            if (collision.gameObject.GetComponent<EnemyController>().chase_player != null)// if chasing enemy
            {
                collision.gameObject.GetComponent<ChasePlayer>().attackFrom = GetComponentInParent<PlayerMovement>().lastDirection;
                collision.gameObject.GetComponent<ChasePlayer>().knockBackDistance = knockDist;
                collision.gameObject.GetComponent<ChasePlayer>().knockBack = true;
            }
            else if(collision.gameObject.GetComponent<EnemyController>().shoot_player != null)// if shooting enemy
            {
                collision.gameObject.GetComponent<ShootPlayer>().attackFrom = GetComponentInParent<PlayerMovement>().lastDirection;
                collision.gameObject.GetComponent<ShootPlayer>().knockBackDistance = knockDist;
                collision.gameObject.GetComponent<ShootPlayer>().knockBack = true;
            }


            warrior_controller.currentRage += 3;
        }
    }
}
