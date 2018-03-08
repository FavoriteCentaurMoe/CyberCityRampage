﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeScript : MonoBehaviour {

    public float byHowMuch; //how much should the enemy be slowed down by 
    public float forHowLong;    //how long should the enemy be slowed down
    public float explosionRadius;   //how big should the explosion be 
    public float timer;     //how long till explosion
    public float jumpHeight;   //how far
    public float jumpTime; //how high
    public float moveSpeed; //how fast
    //public GameObject grenade;
    public bool rise; //is the grenade currently supposed to go up?

    public float lastDirection; //this will be set by the MedicPlayerController

    private IEnumerator Explosion()
    {
        yield return new WaitForSeconds(timer);
        CircleCollider2D collide = GetComponent<CircleCollider2D>();
        collide.radius = explosionRadius;  // =  new Vector2(explosionRadius,explosionRadius);
        Destroy(gameObject, 0.2f);
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyController>().SlowEnemy(byHowMuch, forHowLong);
        }
    }

    // Use this for initialization
    void Start () {

        StartCoroutine(Explosion());
        StartCoroutine(Jump());
		
	}

    private IEnumerator Jump()
    {
        Debug.Log("Jump was initiated");
        rise = true;
        jumpTime = Time.time + 1f;
        yield return new WaitForSeconds(1f);
        jumpHeight = -jumpHeight;
        yield return new WaitForSeconds(1f);
        jumpHeight = -jumpHeight;
        rise = false;
    }


    public void Rise()
    {
        if (lastDirection > 0)
        {
            transform.position += (Vector3.right * moveSpeed * Time.deltaTime);
            transform.position += (Vector3.up * jumpHeight * Time.deltaTime);
        }
        else
        {
            transform.position += (Vector3.left * moveSpeed * Time.deltaTime);
            transform.position += (Vector3.up * jumpHeight * Time.deltaTime);
        }
    }

    // Update is called once per frame
    void Update () {
        if (rise)
        {
            Rise();
        }

    }
}
