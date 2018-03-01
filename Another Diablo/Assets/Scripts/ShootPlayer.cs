using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Works similar to ChasePlayer

public class ShootPlayer : MonoBehaviour {

    public GameObject bullet;

    public GameObject aimingThing; //this is a child of the Enemy that is roated to point the player. 

    public bulletScript bully = null; //This is used to be a reference to the Instantiated Bullet. We call that bullet to change the damage

    public Transform player = null;// If the player is found, move towards it, if not go back to normal spot. There will be a limit to how far it chases. 
    public Transform defaultPosition;

    public bool ATTACK;
    public bool inRange;

    public float speed;
    public float damage;
    public float fireRate;
    public float chaseRange; 
    float timeToFire;
   



    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("A collision with " + collision.gameObject.tag);
        if (collision.gameObject.tag == "Player")
        {
            inRange = true;
            player = collision.transform;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player = null;
        }
    }

    // Use this for initialization
    void Start () {
        ATTACK = false;
	}
	
    void shoot()
    {
        GameObject thing = Instantiate(bullet, transform.position, aimingThing.transform.rotation);
        bully = thing.GetComponent<bulletScript>();
        bully.damage = damage;
        
       
    }

	// Update is called once per frame
	void Update () {


        if (inRange && player != null)
        {
            ATTACK = true;
            //Debug.Log("The current situation warrants movement");
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 0;
            aimingThing.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            //transform.position += (player.position - transform.position).normalized * speed * Time.deltaTime;
        }
        else
        {
            //remeber that is should be <ath.Rad2DEg  + 270 kiddo
            ATTACK = false;
            //Debug.Log("Don't move kiddo");
            Vector3 direction = defaultPosition.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 270;
            aimingThing.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            //transform.position += (defaultPosition.position - transform.position).normalized * speed * Time.deltaTime;
        }



        if (fireRate == 0)
        {
            if (ATTACK)
            {
                shoot();
            }
        }
        else
        {
            if (ATTACK && Time.time > timeToFire)
            {
                timeToFire = Time.time + 1 / fireRate;
                shoot();
            }

        }
    }
}
