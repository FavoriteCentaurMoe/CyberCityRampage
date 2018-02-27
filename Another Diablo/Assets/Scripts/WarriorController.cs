﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorController : MonoBehaviour {
    // this class needs to be abstracted later for utilization with other classes
    // class that utilizes the general Player Movement script 
    // set a speed for the player in the Start() 

    public Animator anim;
    public float maxHealth;
    public float maxRage;
    public float currentHealth;
    public float currentRage;
    public float attackSpeed;
    public bool isBasicAttacking;
    public PlayerMovement player_movement;

    public BoxCollider2D attackRangeRight;
    public PolygonCollider2D cleaveRangeRight;
    public BoxCollider2D shieldBashRangeRight;
    public CapsuleCollider2D tauntRange;

    //ability cooldown variables
    private float shieldBashCooldown;
    private float tauntCooldown;
    private float cleaveCooldown;

    private float berserkerCooldown;
    private float berserkTime;
    private bool goingBerserk;

    //player stats
    public float strength;
    public float intelligence;
    public float luck;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        maxHealth = 100f;
        maxRage = 100f;
        currentHealth = maxHealth;
        currentRage = 100f;
        attackSpeed = 0.35f;
        isBasicAttacking = false;
        player_movement.speed = 5f;
        
        

        shieldBashCooldown = 0f;
        tauntCooldown = 0f;
        cleaveCooldown = 0f;

        berserkerCooldown = 0f;
        berserkTime = 0f;
        goingBerserk = false;

        strength = 5f;

		
	}
	
	// Update is called once per frame
	void Update () {
        StatsCap();
        StartCoroutine(BasicAttack());
        StartCoroutine(ShieldBash());
        StartCoroutine(Taunt());
        StartCoroutine(Cleave());
        Berserker();
		
	}

    private IEnumerator BasicAttack()
    {
        if (Input.GetAxis("Left Trigger") == 1 || Input.GetAxis("Right Trigger") == 1)
        //if(Input.GetButton("Cancel")) // placeholder until i have access to a controller
        {
            if (!isBasicAttacking)
            {
                anim.SetBool("isBasicAttacking", true);
                isBasicAttacking = true;
                //Debug.Log("basic attack");
                attackRangeRight.gameObject.SetActive(true);
                yield return new WaitForSeconds(attackSpeed); // how long to wait before the next attack can be done
                isBasicAttacking = false;
                anim.SetBool("isBasicAttacking", false);
                attackRangeRight.gameObject.SetActive(false);


            }
        }
        currentRage -= Time.deltaTime;
    }
    private IEnumerator ShieldBash() //mobility skill: that knocks back and stuns if hits a wall.  cost 25 rage, cooldown 5 seconds
    {
        if(currentRage > 25f) // if you have enough rage to use this skill
        {
            if (shieldBashCooldown <= Time.time) // if cooldown is 0
            {
                if (Input.GetButton("A Button"))
                {
                    anim.SetBool("ShieldBash", true);
                    currentRage -= 25f;
                    shieldBashCooldown = Time.time + 5f; // set the next time that this skill can be used to the current time plus the cooldown time
                    Debug.Log("shield bash");
                    player_movement.speed = 9.5f;
                    shieldBashRangeRight.gameObject.SetActive(true);

                    yield return new WaitForSeconds(1.5f); // animation time
                    player_movement.speed = 5f;
                    shieldBashRangeRight.transform.DetachChildren();
                    shieldBashRangeRight.gameObject.SetActive(false);
                    anim.SetBool("ShieldBash", false);
                }

            }
        }

    }
    private IEnumerator Taunt() // utility skill: AOE taunt around the player.   cost 35, cooldown 7 seconds
    {
        if (currentRage > 35f) // if you have enough rage to use this skill
        {
            if (tauntCooldown <= Time.time) // if cooldown is 0
            {
                if (Input.GetButton("X Button"))
                {
                    currentRage -= 35f;
                    Debug.Log("Taunt");
                    tauntCooldown = Time.time + 7f; // set the next time that this skill can be used to the current time plus the cooldown time
                    tauntRange.gameObject.SetActive(true);
                    yield return new WaitForSeconds(1f);
                    tauntRange.gameObject.SetActive(false);
                    
                }

            }
        }

    }
    private IEnumerator Cleave() // some time of AOE damage around the player.  cost 15, cooldown 3 seconds
    {
        if (currentRage > 15f) // if you have enough rage to use this skill
        {
            if (cleaveCooldown <= Time.time) // if cooldown is 0
            {
                if (Input.GetButton("B Button"))
                {
                    currentRage -= 15f;
                    cleaveCooldown = Time.time + 3f; // set the next time that this skill can be used to the current time plus the cooldown time
                    Debug.Log("Cleave");

                    cleaveRangeRight.gameObject.SetActive(true);

                    yield return new WaitForSeconds(0.5f); // this number is the duration of the animation
                    cleaveRangeRight.gameObject.SetActive(false);

                }

            }
        }

    }
    private void Berserker()// Ultimate skill: cant be CC'd (maybe also attack speed up), cost 50, cooldown 30
        // skill when activated lasts for 20 seconds
    {

        if (currentRage > 50f) // if you have enough rage to use this skill
        {
            if (berserkerCooldown <= Time.time) // if cooldown is 0
            {
                if (Input.GetButton("Y Button"))
                {
                    currentRage -= 50f;
                    berserkerCooldown = Time.time + 30f; // set the next time that this skill can be used to the current time plus the cooldown time
                    berserkTime = Time.time + 20f;
                    goingBerserk = true;
                    Debug.Log("Berserker!!!");
                }

            }
        }
        if(goingBerserk) 
        {
            if(berserkTime <= Time.time) // time is up
            {
                goingBerserk = false;
                attackSpeed = 0.35f;
                Debug.Log("Done going Berserk");
            }
            else // still going berserk
            {
                // buffs and stuff go here
                attackSpeed = 0.25f;
            }
        }

    }
    private void StatsCap()
    {
        if(currentRage > maxRage)
        {
            currentRage = maxRage;
        }
        if(currentRage < 0f)
        {
            currentRage = 0f;
        }
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        if(currentHealth < 0f)
        {
            currentHealth = 0f;
            Debug.Log("You DIED");
        }
    }

    public void HurtPlayer(float damage)
    {
        currentHealth -= damage;
    }

    //public void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Enemy")
    //    {
    //        HurtPlayer(collision.gameObject.GetComponent<ChasePlayer>().damage);
    //    }
    //}
}