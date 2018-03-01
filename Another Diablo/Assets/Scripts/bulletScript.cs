using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour {

    public float lifetime = 5f;
    //public Rigidbody2D Rb;
    public float speed;
    public float damage; 

	// Use this for initialization
	private void Start () {
        Destroy(gameObject,lifetime);
        //Rb = GetComponent<Rigidbody2D>();
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<WarriorController>().HurtPlayer(damage);
            Destroy(gameObject);
            //DamageTextHandler.makeDamageText(damage.ToString(), collision.transform);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }
    }