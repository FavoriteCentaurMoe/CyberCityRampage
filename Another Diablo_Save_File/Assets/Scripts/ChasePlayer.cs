﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class ChasePlayer : MonoBehaviour {

    public Transform player = null;
    public bool inRange;
    public bool stunned;
    public bool knockBack;
    //public float speed;
    public float damage;
    public float stunTime;
    public Transform defaultPosition;
    public float attackFrom;
    public float knockBackDistance;
    public float leftRight;
    public bool hurt;
    public Animator anim;

    // NEW STUFF FOR PATHFINDING
    public float updateRate = 2f;

    private Seeker seeker;
    private Rigidbody2D rb;
    public Path path;

    public float speed = 30f;

    public bool pathIsEnded = false;

    public float nextWaypointDistance = 3f;

    private int currentWaypoint = 0;

	// Use this for initialization
	public void Start () {
        //speed = 4f;
        damage = 5f;
        stunned = false;
        knockBack = false;
        anim = GetComponent<Animator>();

        // pathfinding stuff
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        player = defaultPosition;
        seeker.StartPath(transform.position, player.position, OnPathComplete);

        StartCoroutine(UpdatePath());
	}

    public IEnumerator UpdatePath()
    {
        if(player == null)
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

	
	// Update is called once per frame
	void Update () {
        if(hurt)
        {
            StartCoroutine(Hurt());
        }
        if(knockBack)
        {
            StartCoroutine(KnockBack());
        }
        if(stunned) // can be knocked back and stunned
        {
            StartCoroutine(Stunned());
        }
        //else if (!stunned)
        else
        {
            if (inRange && player.GetComponent<PlayerController>() != null)
            {
                anim.SetBool("Chasing", true);
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
            else
            {
                anim.SetBool("Chasing", false);
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



        }
		
	}



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (!collision.gameObject.GetComponent<PlayerController>().hurt)
            {
                collision.gameObject.GetComponent<PlayerController>().HurtPlayer(damage);
                //DamageTextHandler.makeDamageText(damage.ToString(), collision.transform);
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
        Debug.Log(attackFrom * knockBackDistance);
        transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3 (attackFrom * knockBackDistance,0,0), 0.5f);
        yield return new WaitForSeconds(0.1f);
        knockBack = false;
    }

    public void FaceDirection(Vector3 direction)
    {
        if(direction.x > 0)
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