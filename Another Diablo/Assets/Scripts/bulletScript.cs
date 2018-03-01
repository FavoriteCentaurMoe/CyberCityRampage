using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour {

    public float lifetime = 5f;
    //public Rigidbody2D Rb;
    public float speed;
    public float damage;
    public bool friendly;

    public Vector3 travel;

	// Use this for initialization
	private void Start () {
        travel = Vector3.right;
        Destroy(gameObject,lifetime);
        travel = Vector3.right;
        //Rb = GetComponent<Rigidbody2D>();
	}

    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Player" && !friendly)
        {
                collision.gameObject.GetComponent<PlayerController>().HurtPlayer(damage);
                Destroy(gameObject);
            //DamageTextHandler.makeDamageText(damage.ToString(), collision.transform);
        }
        else if (collision.gameObject.tag == "Enemy" && friendly)
        {
            collision.gameObject.GetComponent<EnemyController>().HurtEnemy(damage);
            Destroy(gameObject);
        }
    }
    */

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject.tag);
        //Debug.Log("HIT SOMTHING  " + collision.gameObject.tag);
        if (collision.gameObject.tag == "Player" && !friendly)
        {
            collision.gameObject.GetComponent<PlayerController>().HurtPlayer(damage);
            Destroy(gameObject);
            //DamageTextHandler.makeDamageText(damage.ToString(), collision.transform);
        }
        else if (collision.gameObject.tag == "Enemy" && friendly)
        {
            collision.gameObject.GetComponent<EnemyController>().HurtEnemy(damage);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(travel * Time.deltaTime * speed);
    }
    }