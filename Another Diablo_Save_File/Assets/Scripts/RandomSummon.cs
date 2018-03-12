using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSummon : MonoBehaviour {
    public int type = 10;
    public Animator anim;
    public BoxCollider2D hitbox;
    public MageController mage_controller;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        hitbox = GetComponent<BoxCollider2D>();
	}

    public IEnumerator WhichSummon()
    {
        if (type == 0) //pebble
        {
            hitbox.size = new Vector2 (0.3f,1f);
            anim.SetBool("Pebble", true);
            yield return new WaitForSeconds(0.7f);
            hitbox.enabled = true;
            yield return new WaitForSeconds(0.3f);
            anim.SetBool("Pebble", false);
        }
        else if (type == 1) // box
        {
            hitbox.size = new Vector2(0.5f, 1f);
            anim.SetBool("Box", true);
            yield return new WaitForSeconds(0.7f);
            hitbox.enabled = true;
            yield return new WaitForSeconds(0.3f);
            anim.SetBool("Box", false);
        }
        else if (type == 2)  // anvil
        {
            hitbox.size = new Vector2(0.7f, 1f);
            anim.SetBool("Anvil", true);
            yield return new WaitForSeconds(0.7f);
            hitbox.enabled = true;
            yield return new WaitForSeconds(0.3f);
            anim.SetBool("Anvil", false);
        }
        
    }
	
	// Update is called once per frame
	void Update () {

        StartCoroutine(WhichSummon());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy" && type == 0) //pebble
        {
            collision.gameObject.GetComponent<EnemyController>().HurtEnemy(1f);
        }
        else if (collision.gameObject.tag == "Enemy" && type == 1) // box
        {
            collision.gameObject.GetComponent<EnemyController>().HurtEnemy(mage_controller.strength);
        }
        else if (collision.gameObject.tag == "Enemy" && type == 2) // anvil
        {
            collision.gameObject.GetComponent<EnemyController>().HurtEnemy(mage_controller.strength*2);
        }
    }

}
