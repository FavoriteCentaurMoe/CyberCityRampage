using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

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

    //public float speed;
    public float damage;
    public float fireRate;
    public float chaseRange;
    float timeToFire;
    public bool hurt;
    public Animator anim;

    // NEW STUFF FOR PATHFINDING
    public float updateRate = 2f;

    private Seeker seeker;
    private Rigidbody2D rb;
    public Path path;

    public float speed = 2f;

    public bool pathIsEnded = false;

    public float nextWaypointDistance = 3f;

    private int currentWaypoint = 0;




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

        //pathfinding stuff
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        player = defaultPosition;
        seeker.StartPath(transform.position, player.position, OnPathComplete);

        StartCoroutine(UpdatePath());
    }

    public IEnumerator UpdatePath()
    {
        if (player == null)
        {
            player = defaultPosition;
        }
        seeker.StartPath(transform.position, player.position, OnPathComplete);
        yield return new WaitForSeconds(1f / updateRate);
        StartCoroutine(UpdatePath());
    }
    public void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
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
        if (inRange  && (distance < chaseRange))
        {
            ATTACK = true;
            anim.SetBool("Shooting", true);
            //Debug.Log("The current situation warrants movement");
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 0;
            //FaceDirection(angle);
            aimingThing.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.position += (player.position - transform.position).normalized * speed * Time.deltaTime;

        }
        else // default
        {
            ATTACK = false;
            anim.SetBool("Shooting", false);
            Vector3 direction = defaultPosition.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // changed to 0 - jared
            aimingThing.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            //pathfinding
            if (currentWaypoint >= path.vectorPath.Count)
            {
                if (pathIsEnded)
                    return;
                pathIsEnded = true;
                return;
            }
            pathIsEnded = false;
            Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
            dir *= speed * Time.deltaTime;
            FaceDirection(dir);
            transform.position += dir * speed;
            float dist = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);
            if (dist < nextWaypointDistance)
            {
                currentWaypoint++;
                return;
            }
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

    //public void FaceDirection(float direction)
    //{
    //    if (direction > 90f || direction < -90f)
    //    {
    //        transform.localScale = new Vector3(-10, 10, 1);
    //    }
    //    else
    //    {
    //        transform.localScale = new Vector3(10, 10, 1);
    //    }
    //}
    public void FaceDirection(Vector3 direction)
    {
        if (direction.x > 0)
        {
            transform.localScale = new Vector3(10, 10, 1);
        }
        else
        {
            transform.localScale = new Vector3(-10, 10, 1);
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
