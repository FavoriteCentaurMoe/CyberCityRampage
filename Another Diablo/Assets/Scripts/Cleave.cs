using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleave : MonoBehaviour {

    /*
     * the skill cleave does 2x the current strength of the warrior in a cone like shape
     */
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
            float damage;
            damage = warrior_controller.strength * 2f;
            //DamageTextHandler.makeDamageText(damage.ToString(), transform);
            collision.gameObject.GetComponent<EnemyController>().HurtEnemy(damage);
        }
    }
}
