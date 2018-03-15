using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogScript : MonoBehaviour {

    public Animator anim;
    public float speed;
    public float time;
    public float healing;
    public float damage = 10;
    public float playerDirection;
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
        //if (attacking && collision.transform.tag == "Enemy")
        //{
        //    collision.gameObject.GetComponent<EnemyController>().HurtEnemy(damage);
        //    go = false;
        //}
    }

    public void Attack()
    {
        //lastDirection = lastDir;
        attacking = true;
        StartCoroutine(AttackMovement());
    }

    private IEnumerator AttackMovement() //The normal attack. Shoots something straight ahead 
    {
        
        go = true;
        speed = speed * attackMultiplier;
        anim.SetBool("isBasicAttacking", true);
        yield return new WaitForSeconds(0.5f);
        //speed = speed / attackMultiplier;

        go = false;
        attacking = false;
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("isBasicAttacking", false);
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
        anim = GetComponent<Animator>();
		
	}

    private IEnumerator DogMovement() //The normal attack. Shoots something straight ahead 
    {
        if (playerDirection > 0)
        {
            go = true;
            DogFacing(0);
            yield return new WaitForSeconds(time);
            go = false;
            DogFacing(180);
        }
        else
        {
            go = true;
            DogFacing(180);
            yield return new WaitForSeconds(time);
            go = false;
            DogFacing(0);
        }
    }

    public void DogFacing(float angle)
    {
        if (angle > 90f || angle < -90f)
        {
            transform.localScale = new Vector3(-10, 10, 1);
        }
        else
        {
            transform.localScale = new Vector3(10, 10, 1);
        }
    }

    //private IEnumerator Sit()
    //{
    //    anim.SetBool("Idle", true);
    //    yield return new WaitForSeconds(0.5f);
    //    anim.SetBool("Sit", true);
    //}

    // Update is called once per frame
    void Update () {

        if (go) // attack 
        {
            anim.SetBool("Idle", false);
            if (playerDirection < 0)
            {
                rig.transform.position = new Vector3(transform.position.x + (-speed * Time.deltaTime), transform.position.y);
                //DogFacing(0f);
            }
            else
            {
                rig.transform.position = new Vector3(transform.position.x + (speed * Time.deltaTime), transform.position.y);
                //DogFacing(180f);
            }
        }
        else if(Vector3.Distance(transform.position, owner.transform.position) <  1)//for the dog to sit
        {
            //StartCoroutine(Sit());
            anim.SetBool("Idle", true);
            // make the dog face whichever way the player is facing? 
        }
        else
        {
            anim.SetBool("Idle", false);
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, owner.transform.position, step);
            Vector3 direction = owner.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            DogFacing(angle);
        }
        
    }
}
