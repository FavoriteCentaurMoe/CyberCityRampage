using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayer : MonoBehaviour {

    public GameObject bullet;

    public GameObject aimingThing;

    public bulletScript bully = null; 

    public Transform player = null;
    public Transform defaultPosition;

    public bool ATTACK;
    public bool inRange;

    public float attackFrom;
    public float knockBackDistance;
    public bool knockBack;
    public bool stunned;
    public float stunTime;

    public float speed;
    public float damage;
    public float fireRate;
    public float chaseRange;
    float timeToFire;
    public bool hurt;
    public Animator anim;
   



    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    //Debug.Log("A collision with " + collision.gameObject.tag);
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        inRange = true;
    //        player = collision.transform;
    //    }
    //}
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        player = null;
    //    }
    //}

    // Use this for initialization
    void Start () {
        ATTACK = false;
        anim = GetComponent<Animator>();
    }
	
    void shoot()
    {
        GameObject thing = Instantiate(bullet, aimingThing.transform.position, aimingThing.transform.rotation);
        bully = thing.GetComponent<bulletScript>();
        bully.damage = damage;
        
       
    }

	// Update is called once per frame
	void Update () {
        if (hurt)
        {
            StartCoroutine(Hurt());
        }
        if (knockBack)
        {
            StartCoroutine(KnockBack());
        }
        if (stunned) // can be knocked back and stunned
        {
            StartCoroutine(Stunned());
        }
        float distance = Vector3.Distance(defaultPosition.position, transform.position);
        if (inRange && player != null && (distance < chaseRange))
        {
            ATTACK = true;
            anim.SetBool("Shooting", true);
            //Debug.Log("The current situation warrants movement");
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 0;
            FaceDirection(angle);
            aimingThing.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.position += (player.position - transform.position).normalized * speed * Time.deltaTime;
        }
        else
        {
            //remeber that is should be <ath.Rad2DEg  + 270 kiddo
            ATTACK = false;
            anim.SetBool("Shooting", false);
            //Debug.Log("Don't move kiddo");
            Vector3 direction = defaultPosition.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // changed to 0 - jared
            FaceDirection(angle);
            aimingThing.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.position += (defaultPosition.position - transform.position).normalized * speed * Time.deltaTime;
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

    private IEnumerator Stunned()
    {

        yield return new WaitForSeconds(stunTime);
        stunned = false;
    }

    public IEnumerator KnockBack()
    {
        //Debug.Log(attackFrom * knockBackDistance);
        transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(attackFrom * knockBackDistance, 0, 0), 0.5f);
        yield return new WaitForSeconds(0.1f);
        knockBack = false;
    }

    public void FaceDirection(float direction)
    {
        if (direction > 90f || direction < -90f)
        {
            transform.localScale = new Vector3(-10, 10, 1);
        }
        else
        {
            transform.localScale = new Vector3(10, 10, 1);
        }
    }

    public IEnumerator Hurt()
    {
        anim.SetBool("Hurt", true);
        yield return new WaitForSeconds(0.01f);
        anim.SetBool("Hurt", false);
        hurt = false;
    }
}
