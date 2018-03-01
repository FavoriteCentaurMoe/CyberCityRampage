using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public float maxHealth;
    public float currentHealth;

	// Use this for initialization
	void Start () {
        maxHealth = 10f; // set  high for testing
        //Debug.Log("Start of an enemy");
        currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
        Death();
		
	}


    public void HurtEnemy(float damage)
    {
        DamageTextHandler.makeDamageText(damage.ToString(), transform,1f,"Enemy");
        //Debug.Log("Ouch I was hit");
        currentHealth -= damage;
    }

    public void Death()
    {
        if(currentHealth <= 0)
        {
            //Debug.Log("Dead");
            Destroy(this.gameObject);
        }
    }
}
