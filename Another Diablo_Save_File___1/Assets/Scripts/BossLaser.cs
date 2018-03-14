using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLaser : MonoBehaviour {
    public float laser_damage = 5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (!collision.gameObject.GetComponent<PlayerController>().hurt)
            {
                collision.gameObject.GetComponent<PlayerController>().HurtPlayer(laser_damage);
                //DamageTextHandler.makeDamageText(damage.ToString(), collision.transform);
            }
        }
    }
}
