using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageController : PlayerController
{
    public Animator anim;

    public float maxEnergy;
    public float currentEnergy;

    public Aiming aimer;
    //public GameObject bullet;
    //public GameObject aimedBullet;
    //public GameObject ultimateBox;

    public GameObject gravityWell;
    public GameObject randomSummon;
    public Transform randomSummonSpot;
    public GameObject meteor;
    public Transform meteorSpot;

    public bulletScript bully;

    public aimedBulletScript aibully;

    public float phaseCooldown  = 0f;
    public float randomAttackCooldown = 0f;
    public float meteorCooldown = 0f;
    public float gravityCooldown = 0f;

    public BoxCollider2D spearRange;

    // Use this for initialization
    void Start () {
        base.Start();
        anim = GetComponent<Animator>();
        maxHealth = 75f;
        currentHealth = maxHealth;
        maxEnergy = 150f;
        currentEnergy = maxEnergy;
        player_movement.speed = 25f; 
        attackSpeed = 0.15f;
        strength = 5f;
    }

    private void EnergyCap() // increases energy always and caps it 
    {
        currentEnergy += Time.deltaTime * 2;
        if (currentEnergy > maxEnergy)
        {
            currentEnergy = maxEnergy;
        }
        if (currentEnergy < 0f)
        {
            currentEnergy = 0f;
        }
    }

    private IEnumerator Meteor()//shoots a giant laser that creates a collider that expands forward from the player 
    {
        if (currentEnergy > 30)
        {
            if (meteorCooldown <= Time.time)
            {
                if (Input.GetAxis(player_movement.controller_num + "Left Trigger") == 1)
                {
                    currentEnergy -= 30f;
                    //anim.SetBool("Laser", true);
                    meteorCooldown = Time.time + 10f;
                    anim.SetBool("Ultimate", true);
                    meteor.gameObject.SetActive(true);
                    meteor.gameObject.transform.parent = null;
                    StartCoroutine(meteor.GetComponent<Meteor>().MeteorStrike());
                    yield return new WaitForSeconds(1.5f);
                    anim.SetBool("Ultimate", false);
                    meteor.gameObject.transform.parent = this.gameObject.transform;
                    meteor.gameObject.transform.position = meteorSpot.transform.position;
                    meteor.GetComponent<Meteor>().on = false;
                    meteor.GetComponent<BoxCollider2D>().enabled = false;
                    meteor.gameObject.SetActive(false);

                }
            }
        }
    }


    private IEnumerator BasicAttack()
    {
        if (Input.GetAxis(player_movement.controller_num + "X Button") == 1)
        {
            if (!isBasicAttacking)
            {
                anim.SetBool("isBasicAttacking", true);
                isBasicAttacking = true;
                //Debug.Log("basic attack");
                yield return new WaitForSeconds(0.15f);
                spearRange.gameObject.SetActive(true);
                yield return new WaitForSeconds(0.1f);

                anim.SetBool("isBasicAttacking", false);
                spearRange.gameObject.SetActive(false);
                yield return new WaitForSeconds(attackSpeed); // how long to wait before the next attack can be done
                isBasicAttacking = false;


            }
        }
    }

    private IEnumerator GravityWell() // utility skill: AOE taunt around the player.   cost 35, cooldown 7 seconds
    {
        if (currentEnergy > 35f) // if you have enough rage to use this skill
        {
            if(gravityCooldown <= Time.time) // if cooldown is 0
            {
                if (Input.GetButton(player_movement.controller_num + "Y Button"))
                {
                    anim.SetBool("Gravity Well", true);
                    currentEnergy -= 35f;
                    Debug.Log("Taunt");
                    gravityCooldown = Time.time + 7f; // set the next time that this skill can be used to the current time plus the cooldown time
                    //tauntRange.gameObject.SetActive(true);
                    yield return new WaitForSeconds(1f);
                    float height = GetComponent<SpriteRenderer>().sprite.bounds.size.y * transform.localScale.y;
                    Vector2 spot = new Vector2(transform.position.x, transform.position.y - (height / 2));
                    Instantiate(gravityWell, spot, transform.rotation);
                    //tauntRange.gameObject.SetActive(false);
                    anim.SetBool("Gravity Well", false);
                }

            }
        }

    }
    private IEnumerator RandomSummon() // random 1 of 3 options, little, decent, and a lot of damage
    {
        if (currentEnergy > 15f) // if you have enough rage to use this skill
        {
            if (randomAttackCooldown <= Time.time) // if cooldown is 0
            {
                if (Input.GetButton(player_movement.controller_num + "A Button"))
                {

                    //anim.SetBool("Cleave", true);
                    currentEnergy -= 15f;
                    randomAttackCooldown = Time.time + 3f; // set the next time that this skill can be used to the current time plus the cooldown time
                    //Debug.Log("Cleave");
                    anim.SetBool("Random Summon", true);
                    randomSummon.gameObject.SetActive(true);
                    randomSummon.gameObject.transform.parent = null;
                    int summon = Random.Range(0,3);
                    if(summon == 0)
                    {
                        //Debug.Log("pebble");
                        randomSummon.GetComponent<RandomSummon>().type = 0;
                    }
                    else if (summon == 1)
                    {
                        //Debug.Log("box");
                        randomSummon.GetComponent<RandomSummon>().type = 1;
                    }
                    else
                    {
                        //Debug.Log("anvil");
                        randomSummon.GetComponent<RandomSummon>().type = 2;
                    }
                    yield return new WaitForSeconds(1f);
                    anim.SetBool("Random Summon", false);
                    randomSummon.GetComponent<RandomSummon>().type = 10;
                    randomSummon.GetComponent<BoxCollider2D>().enabled = false;
                    randomSummon.gameObject.transform.parent = this.gameObject.transform;
                    randomSummon.gameObject.transform.position = randomSummonSpot.transform.position;
                    randomSummon.gameObject.SetActive(false);
                }
            }
        }
    }

    private IEnumerator Phase() // mobility skill can go through enemies
    {
        if (currentEnergy > 10)
        {
            if (phaseCooldown <= Time.time) // if cooldown is 0
            {
                if (Input.GetButton(player_movement.controller_num + "B Button"))
                {
                    anim.SetBool("Phase", true);
                    currentEnergy -= 10f;
                    phaseCooldown = Time.time + 5f;
                    yield return new WaitForSeconds(0.55f); // animation time
                    if(player_movement.lastDirection > 0)
                    {
                        transform.position += new Vector3(20, 0, 0);
                    }
                    else
                    {
                        transform.position += new Vector3(-20, 0, 0);
                    }
                    anim.SetBool("Phase", false);
                }
            }
        }
    }


    // Update is called once per frame
    void Update () {
        base.StatsCap();
        EnergyCap();
        StartCoroutine(BasicAttack());
        StartCoroutine(Phase());
        StartCoroutine(GravityWell());
        StartCoroutine(RandomSummon());
        StartCoroutine(Meteor());
    }
}
