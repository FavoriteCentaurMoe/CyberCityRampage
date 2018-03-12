using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicPlayerController : PlayerController {

    public Animator anim;
    public Aiming aimer;
    public DogScript dog;
    public float dogHealTime = 0.0f;
    public float jumpTime = 0.0f;
    public float grenadeTime = 0.0f;
    public float ultimateTime = 0.0f;
    public float basicAttackTime = 0.0f;
    public float jumpHeight;
    public float moveSpeed;

    public GameObject slowGrenade;
    public GameObject healSpot;

    public bool facingRight;
    public bool rise;
    public bool jumping;

    //private void StatsCap()
    //{

    //    if (currentHealth > maxHealth)
    //    {
    //        currentHealth = maxHealth;
    //    }
    //    if (currentHealth < 0f)
    //    {
    //        currentHealth = 0f;
    //        Debug.Log("You DIED");
    //    }
    //}

    private IEnumerator DogHeal()
    {
        if (dogHealTime <= Time.time)
        {
            if (Input.GetButton(player_movement.controller_num + "A Button"))
            {
                anim.SetBool("Heal", true);
                dog.VentureForth();
                dogHealTime = Time.time + 3f;
                yield return new WaitForSeconds(0.6f);
                anim.SetBool("Heal", false);
            }
        }
    }

    public override void HurtPlayer(float damage)
    {
        if(!jumping)
        {
            DamageTextHandler.makeDamageText(damage.ToString(), transform, 1f, "Player");
            currentHealth -= damage;
        }
    }

    private IEnumerator Ultimate()
    {
        if (ultimateTime <= Time.time)
        {
            if (Input.GetAxis(player_movement.controller_num + "Left Trigger") == 1)
            {
                anim.SetBool("Ultimate", true);
                ultimateTime = Time.time + 5f;
                float height = GetComponent<SpriteRenderer>().sprite.bounds.size.y * transform.localScale.y;
                Vector2 spot = new Vector2(transform.position.x, transform.position.y - (height / 2));
                yield return new WaitForSeconds(1.5f);
                Instantiate(healSpot, spot, transform.rotation);
                //yield return new WaitForSeconds(0.2f);
                anim.SetBool("Ultimate", false);
            }
        }
    }

    private IEnumerator Jump()
    {
        if (jumpTime <= Time.time)
        {
            if (Input.GetButton(player_movement.controller_num + "B Button"))
            {
                anim.SetBool("Jump", true);
                Debug.Log("Jump button was pressed");
                //yield return new WaitForSeconds(0.3f);

                yield return new WaitForSeconds(0.5f);
                moveSpeed = player_movement.speed * 3;
                //jumping = true;
                rise = true;

                jumpTime = Time.time + 1f;
                BoxCollider2D boxx = gameObject.GetComponent<BoxCollider2D>();
                //yield return new WaitForSeconds(0.1f);
                boxx.isTrigger = true;
                transform.tag = "Invisible";
                yield return new WaitForSeconds(0.6f);
                boxx.isTrigger = false;
                transform.tag = "Player";
                yield return new WaitForSeconds(0.4f);
                //jumpHeight = -jumpHeight;
                ///moveSpeed = -moveSpeed;
                rise = false;
                //jumping = false;
                anim.SetBool("Jump", false);
            }
        }
    }

    private IEnumerator SlowGrenade()
    {
        if (grenadeTime <= Time.time)
        {
            if (Input.GetButton(player_movement.controller_num + "Y Button"))
            {
                anim.SetBool("SlowGrenade", true);
                Debug.Log("Grenade button was pressed");
                grenadeTime = Time.time + 3f;
                yield return new WaitForSeconds(1.5f);
                GameObject gren = Instantiate(slowGrenade, transform.position, transform.rotation);
                GrenadeScript gre = gren.GetComponent<GrenadeScript>();
                gre.lastDirection = player_movement.lastDirection;

                yield return new WaitForSeconds(1f);
                anim.SetBool("SlowGrenade", false);
            }
        }
    }

    private IEnumerator BasicAttack()
    {
        if (basicAttackTime <= Time.time)
        {
            if (Input.GetButton(player_movement.controller_num + "X Button"))
            {
                anim.SetBool("isBasicAttacking", true);
                dog.Attack();
                basicAttackTime = Time.time + 1f;
                yield return new WaitForSeconds(1f);
                anim.SetBool("isBasicAttacking", false);
            }
        }
    }

    /*
       if (jumpTime <= Time.time)
        {
            if (Input.GetButton("B Button"))
            {
                Debug.Log("Jump button was pressed");
                rise = true;
                
                jumpTime = Time.time + 1f;

                yield return new WaitForSeconds(1f);
                jumpHeight = -jumpHeight;
                moveSpeed = -moveSpeed;
                yield return new WaitForSeconds(1f);
                jumpHeight = -jumpHeight;
                moveSpeed = -moveSpeed;
                rise = false;
            }
        }*/


    void Start () {
        base.Start();
        anim = GetComponent<Animator>();
        maxHealth = 50f;
        currentHealth = maxHealth;
        player_movement.speed = 15f;
        attackSpeed = 0.15f;
        strength = 5f;
    }

     public override bool isMedic()
    {
        return true;
    }

    public void Rise()
    {
        if (player_movement.lastDirection > 0)
        {
            //This is for right
            Debug.Log("Jumping right");
            transform.position += (Vector3.right * moveSpeed * Time.deltaTime);
            //transform.position += (Vector3.up * jumpHeight * Time.deltaTime);
        }
        else
        {
            //For left 
            Debug.Log("Jumping left");
            transform.position += (Vector3.left * moveSpeed * Time.deltaTime);
            //transform.position += (Vector3.up * jumpHeight * Time.deltaTime);
        }
    }
    void DirectionToDog()
    {
        if (player_movement.lastDirection > 0)
        {
            dog.playerDirection = 1;
        }
        else
        {
            dog.playerDirection = -1;
        }
    }

	void Update () {
        StatsCap();
        StartCoroutine(DogHeal());
        StartCoroutine(Jump());
        StartCoroutine(SlowGrenade());
        StartCoroutine(Ultimate());
        StartCoroutine(BasicAttack());
        DirectionToDog();

        if (rise)
        {
            Rise();
        }
    }
}
