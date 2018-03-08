using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogScript : MonoBehaviour {

    public float speed;
    public float time;
    public float healing;
    public float damage = 6;
    public float lastDirection;
    public float attackMultiplier = 1f;

    public bool go;
    public bool attacking;

    public Rigidbody2D rig;
    public GameObject owner;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
           if(!collision.gameObject.GetComponent<PlayerController>().isMedic())
            {
                collision.gameObject.GetComponent<PlayerController>().HealPlayer(healing);
               
            }
        }
        if (attacking && collision.transform.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyController>().HurtEnemy(damage);
            go = false;
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        /*
        if (collision.transform.tag == "Player")
        {
            if (!collision.gameObject.GetComponent<PlayerController>().isMedic())
            {
                collision.gameObject.GetComponent<PlayerController>().HealPlayer(healing);
            }
        }
        */
        if (attacking && collision.transform.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyController>().HurtEnemy(damage);
            go = false;
        }
    }

    public void Attack(float lastDir)
    {
        lastDirection = lastDir;
        attacking = true;
        StartCoroutine(AttackMovement());
    }

    private IEnumerator AttackMovement() //The normal attack. Shoots something straight ahead 
    {
        // if (Input.GetAxis("Left Trigger") == 1 || Input.GetAxis("Right Trigger") == 1)
        go = true;
        speed = speed * attackMultiplier;
        yield return new WaitForSeconds(0.1f);
        //speed = speed / attackMultiplier;
        go = false;
        attacking = false;
        yield return new WaitForSeconds(0.1f);
        speed = speed / attackMultiplier;
        //currentRage -= Time.deltaTime;
    }

    public void VentureForth()
    {
        rig = GetComponent<Rigidbody2D>();
        StartCoroutine(DogMovement());
    }

	// Use this for initialization
	void Start () {
        attacking = false;
        rig = GetComponent<Rigidbody2D>();
		
	}

    private IEnumerator DogMovement() //The normal attack. Shoots something straight ahead 
    {
            go = true;
            yield return new WaitForSeconds(time);
            go = false;
    }

    // Update is called once per frame
    void Update () {

        if (go)
        {
            if (lastDirection < 0)
            {
                rig.transform.position = new Vector3(transform.position.x + (-speed * Time.deltaTime), transform.position.y);
            }
            else
            {
                rig.transform.position = new Vector3(transform.position.x + (speed * Time.deltaTime), transform.position.y);
            }
        }
        else
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, owner.transform.position, step);
        }
    }
}
