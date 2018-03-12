using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour {
    public Animator anim;
    public BoxCollider2D hitbox;
    public MageController mage_controller;
    public bool on;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        hitbox = GetComponent<BoxCollider2D>();
        //on = false;
	}

    public IEnumerator MeteorStrike()
    {
        //if(on)
        //{
            anim.SetBool("Strike", true);
            yield return new WaitForSeconds(1f);
            hitbox.enabled = true;
            yield return new WaitForSeconds(0.5f);
            anim.SetBool("Strirke", false);
            on = false;
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyController>().HurtEnemy(mage_controller.strength*4);
        }
    }

    // Update is called once per frame
    void Update () {
		//StartCoroutine(MeteorStrike());
	}
}
