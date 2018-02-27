using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : MonoBehaviour {
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
            collision.gameObject.GetComponent<EnemyController>().HurtEnemy(warrior_controller.strength);
            //DamageTextHandler.makeDamageText(warrior_controller.strength.ToString(), transform);
            warrior_controller.currentRage += 3;
        }
    }
}
