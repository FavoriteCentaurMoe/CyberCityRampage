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

    public float maxEnergy;
    public float currentEnergy;

    public GameObject slowGrenade;
    public GameObject healSpot;

    public bool facingRight;
    public bool rise;
    public bool jumping;

    public AudioSource basic_att;
    public AudioSource jump;
    public AudioSource throw_ball;
    public AudioSource send_dog_h;
    public AudioSource ult;
    public AudioSource hurt_sound;

    private void EnergyCap() // increases energy always and caps it 
    {
        currentHealth += Time.deltaTime;
        currentEnergy += Time.deltaTime;
        if (currentEnergy > maxEnergy)
        {
            currentEnergy = maxEnergy;
        }
        if (currentEnergy < 0f)
        {
            currentEnergy = 0f;
        }
    }

    private IEnumerator DogHeal()
    {
        if (dogHealTime <= Time.time)
        {
            if (currentEnergy > 10)
            {
                if (Input.GetButton(player_movement.controller_num + "A Button"))
                {
                    dogHealTime = Time.time + 3f;
                    currentEnergy -= 10f;
                    anim.SetBool("Heal", true);
                    send_dog_h.Play();
                    dog.VentureForth();
                    
                    yield return new WaitForSeconds(0.6f);
                    anim.SetBool("Heal", false);
                }
            }
        }
    }

    public override void HurtPlayer(float damage)
    {
        if(!jumping)
        {
            //GetComponent<SpriteRenderer>().color = Color.magenta;
            DamageTextHandler.makeDamageText(damage.ToString(), transform, 1f, "Player");
            hurt_sound.Play();
            currentHealth -= damage;
            StartCoroutine(HurtTime());
        }
    }

    private IEnumerator Ultimate()
    {
        if (ultimateTime <= Time.time)
        {
            if (currentEnergy > 25)
            {
                if (Input.GetAxis(player_movement.controller_num + "Left Trigger") == 1)
                {
                    ultimateTime = Time.time + 10f;
                    currentEnergy -= 25f;
                    anim.SetBool("Ultimate", true);
                    yield return new WaitForSeconds(0.5f);
                    ult.Play();
                    
                    yield return new WaitForSeconds(1.0f);
                    float height = GetComponent<SpriteRenderer>().sprite.bounds.size.y * transform.localScale.y;
                    Vector2 spot = new Vector2(transform.position.x, transform.position.y - (height / 2));
                    Instantiate(healSpot, spot, transform.rotation);
                    //yield return new WaitForSeconds(0.2f);
                    anim.SetBool("Ultimate", false);
                }
            }
        }
    }

    private IEnumerator Jump()
    {
        if (jumpTime <= Time.time)
        {
            if (Input.GetButton(player_movement.controller_num + "B Button"))
            {
                if (currentEnergy > 15)
                {
                    jumpTime = Time.time + 5f;
                    currentEnergy -= 15f;
                    anim.SetBool("Jump", true);
                    jump.Play();
                    Debug.Log("Jump button was pressed");
                    //yield return new WaitForSeconds(0.3f);

                    yield return new WaitForSeconds(0.5f);
                    moveSpeed = player_movement.speed * 1.5f;
                    //jumping = true;
                    rise = true;

                  
                    BoxCollider2D boxx = gameObject.GetComponent<BoxCollider2D>();
                    //yield return new WaitForSeconds(0.1f);
                    //boxx.isTrigger = true;
                    //transform.tag = "Invisible";
                    gameObject.layer = 13;
                    yield return new WaitForSeconds(0.6f);
                    //boxx.isTrigger = false;
                    //transform.tag = "Player";
                    gameObject.layer = 11;
                    yield return new WaitForSeconds(0.4f);
                    //jumpHeight = -jumpHeight;
                    ///moveSpeed = -moveSpeed;
                    rise = false;
                    //jumping = false;
                    anim.SetBool("Jump", false);
                }
            }
        }
    }

    private IEnumerator SlowGrenade()
    {
        if (grenadeTime <= Time.time)
        {
            if (currentEnergy > 15)
            {
                if (Input.GetButton(player_movement.controller_num + "Y Button"))
                {
                    grenadeTime = Time.time + 5f;
                    currentEnergy -= 15f;
                    anim.SetBool("SlowGrenade", true);
                    yield return new WaitForSeconds(0.5f);
                    throw_ball.Play();

                    Debug.Log("Grenade button was pressed");
                    
                    yield return new WaitForSeconds(1.0f);
                    GameObject gren = Instantiate(slowGrenade, transform.position, transform.rotation);
                    GrenadeScript gre = gren.GetComponent<GrenadeScript>();
                    gre.lastDirection = player_movement.lastDirection;

                    yield return new WaitForSeconds(1f);
                    anim.SetBool("SlowGrenade", false);
                }
            }
        }
    }

    private IEnumerator BasicAttack()
    {
        if (basicAttackTime <= Time.time)
        {
            if (Input.GetButton(player_movement.controller_num + "X Button"))
            {
                if (Vector3.Distance(transform.position, dog.transform.position) < 7)
                {
                    basicAttackTime = Time.time + 1f;
                    anim.SetBool("isBasicAttacking", true);
                    basic_att.Play();
                    dog.Attack();

                    yield return new WaitForSeconds(1f);
                    anim.SetBool("isBasicAttacking", false);
                }
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


    void Awake () {
        base.Start();
        anim = GetComponent<Animator>();
        maxHealth = 50f;
        currentHealth = maxHealth;
        maxEnergy = 100f;
        currentEnergy = maxEnergy;
        player_movement.speed = 20f;
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
        base.StatsCap();
        EnergyCap();
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
