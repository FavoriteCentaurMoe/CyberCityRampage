using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayer : MonoBehaviour {

    public GameObject bullet;

    public bulletScript bully = null; 

    public Transform player = null;
    public Transform defaultPosition;

    public bool ATTACK;
    public bool inRange;

    public float speed;
    public float damage;
    public float fireRate;
    float timeToFire;
   



    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("A collision with " + collision.gameObject.tag);
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
        GameObject thing = Instantiate(bullet, transform.position, transform.rotation);
        bully = thing.GetComponent<bulletScript>();
        bully.damage = damage;
        
       
    }

	// Update is called once per frame
	void Update () {
        if (inRange && player != null)
        {
            ATTACK = true;
            Debug.Log("The current situation warrants movement");
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 0;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            //transform.position += (player.position - transform.position).normalized * speed * Time.deltaTime;
        }
        else
        {
            //remeber that is should be <ath.Rad2DEg  + 270 kiddo
            ATTACK = false;
            Debug.Log("Don't move kiddo");
            Vector3 direction = defaultPosition.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 270;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
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
