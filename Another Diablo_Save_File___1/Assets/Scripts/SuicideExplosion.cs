using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuicideExplosion : MonoBehaviour {

    public float damage;

	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (!collision.gameObject.GetComponent<PlayerController>().hurt)
            {
                collision.gameObject.GetComponent<PlayerController>().HurtPlayer(damage);
                //DamageTextHandler.makeDamageText(damage.ToString(), collision.transform);
            }
        }
    }
}
