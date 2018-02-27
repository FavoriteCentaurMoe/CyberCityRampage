using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public float maxHealth;
    public float currentHealth;

	// Use this for initialization
	void Start () {
        maxHealth = 10f;
        currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
        Death();
		
	}


    public void HurtEnemy(float damage)
    {
        currentHealth -= damage;
        DamageTextHandler.makeDamageText(damage.ToString(), transform,1f,"Enemy");
    }

    public void Death()
    {
        if(currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
