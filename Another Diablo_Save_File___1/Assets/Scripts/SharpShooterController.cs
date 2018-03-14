using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The Controller for the SharpShooter character 
public class SharpShooterController : PlayerController {

    public Animator anim;

    public float maxEnergy;
    public float currentEnergy;

    public Aiming aimer;
    public GameObject bullet;
    public GameObject aimedBullet;
    public GameObject ultimateBox;

    public GameObject stunMine;

    public bulletScript bully;
    
    public aimedBulletScript aibully;
    
    public SmokeScreen smoke_screen;

  

    public float multiShotCooldown = 0f; //this will be what gets added to TimeThing every time a skill is used 
    private float multiShotTimeThing = 0f;
    public float mineCooldown = 0f;
    public float invisibleCooldown = 0f;
    public float ultimateCooldown = 0f;
    public AudioSource basic_attack_sound;
    public AudioSource triple_shot_sound;
    public AudioSource smoke_bomb_sound;
    public AudioSource ultimate_laser_sound;
    public AudioSource set_mine_sound;


    // Use this for initialization
    void Start () {
       base.Start();
        anim = GetComponent<Animator>();
        maxHealth = 75f;
        currentHealth = maxHealth;
        maxEnergy = 100f;
        currentEnergy = maxEnergy;
        player_movement.speed = 30f;
        attackSpeed = 0.1f;
        strength = 5f;
    }

    public override void HurtPlayer(float damage)
    {
            GetComponent<SpriteRenderer>().color = Color.magenta;
            DamageTextHandler.makeDamageText(damage.ToString(), transform, 1f, "Player");
            currentHealth -= damage;
            StartCoroutine(HurtTime());
    }

    private void EnergyCap() // increases energy always and caps it 
    {
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

    private IEnumerator Invisible() // for invisibility ability (maybe add speed boost?)
    {
        if (currentEnergy > 15) // cost
        {
            if (invisibleCooldown <= Time.time)
            {
                if (Input.GetButton(player_movement.controller_num + "Y Button"))
                {
                    smoke_bomb_sound.Play();
                    currentEnergy -= 15f; // subtract cost
                    invisibleCooldown = Time.time + 5f;
                    anim.SetBool("Invisible", true);
                    //multiShotCooldown = Time.time + 3f;
                    Debug.Log("INVISIBLE TIME");
                    yield return new WaitForSeconds(0.5f);
                    anim.SetBool("Invisible", false);
                    Instantiate(smoke_screen, gameObject.transform.position, gameObject.transform.rotation);
                    transform.tag = "Invisible";
                    yield return new WaitForSeconds(2f);
                    transform.tag = "Player";
                    Debug.Log("NO MORE INVISIBLE");

                }
            }
        }
    }

    private IEnumerator Ultimate()//shoots a giant laser that creates a collider that expands forward from the player 
    {
        if (currentEnergy > 25)
        {
            if (ultimateCooldown <= Time.time)
            {
                if (Input.GetAxis(player_movement.controller_num + "Left Trigger") == 1)
                {
                    ultimate_laser_sound.Play();
                    currentEnergy -= 25f;
                    anim.SetBool("Laser", true);
                    ultimateCooldown = Time.time + 10f;
                    //Debug.Log("TIME OF ULTIMATEEE");
                    //transform.tag = "Invisible";
                    float change = 5.5f;
                    float sizeChange = 0.8f;
                    if (player_movement.lastDirection < 0)
                    {
                        change = -change;
                    }
                    yield return new WaitForSeconds(0.6f);
                    ultimateBox.SetActive(true);
                    Transform trans = ultimateBox.GetComponent<Transform>();
                    Vector2 savedSize = new Vector2(trans.localScale.x, trans.localScale.y);
                    trans.localScale = new Vector3(trans.localScale.x + sizeChange, trans.localScale.y);
                    trans.position = new Vector2(transform.position.x + change, transform.position.y);
                    yield return new WaitForSeconds(0.2f);
                    trans.localScale = new Vector3(trans.localScale.x + sizeChange, trans.localScale.y);
                    trans.position = new Vector2(transform.position.x + change, transform.position.y);
                    yield return new WaitForSeconds(0.2f);
                    trans.localScale = new Vector3(trans.localScale.x + sizeChange, trans.localScale.y);
                    trans.position = new Vector2(transform.position.x + change, transform.position.y);
                    yield return new WaitForSeconds(0.1f);
                    trans.localScale = new Vector3(trans.localScale.x + sizeChange, trans.localScale.y);
                    trans.position = new Vector2(transform.position.x + change, transform.position.y);
                    yield return new WaitForSeconds(0.1f);
                    trans.localScale = new Vector3(trans.localScale.x + sizeChange, trans.localScale.y);
                    trans.position = new Vector2(transform.position.x + change, transform.position.y);
                    yield return new WaitForSeconds(0.1f);
                    trans.localScale = savedSize;
                    trans.position = new Vector2(transform.position.x, transform.position.y);

                    ultimateBox.SetActive(false);
                    anim.SetBool("Laser", false);
                }
            }
        }
    }

    private IEnumerator MultiShot() //Shoots multipe arrows. At the moment it is 3 arrows ,could be more
    {
        if (currentEnergy > 10)
        {
            if (multiShotCooldown <= Time.time) // if cooldown is 0
            {
                if (Input.GetButton(player_movement.controller_num + "A Button"))
                {
                    triple_shot_sound.Play();
                    currentEnergy -= 10f;
                    anim.SetBool("MultiShot", true);
                    multiShotCooldown = Time.time + 3f; // set the next time that this skill can be used to the current time plus the cooldown time
                    Debug.Log("Multi Shot");
                    yield return new WaitForSeconds(0.2f); // animation time
                    //float height = GetComponent<SpriteRenderer>().bounds.size.y;
                    //shoot(height / 2);
                    shoot();
                    //shoot(-height / 2);
                    yield return new WaitForSeconds(0.2f);
                    shoot();
                    yield return new WaitForSeconds(0.2f);
                    shoot();
                    yield return new WaitForSeconds(0.1f);
                    anim.SetBool("MultiShot", false);

                }
            }
        }
    }

    private IEnumerator Mine() //Place a stun mine on the ground (currently the position looks odd
    {
        if (currentEnergy > 10)
        {
            if (mineCooldown <= Time.time) // if cooldown is 0
            {
                if (Input.GetButton(player_movement.controller_num + "B Button"))
                {
                    set_mine_sound.Play();
                    currentEnergy -= 10f;
                    anim.SetBool("Mine", true);
                    mineCooldown = Time.time + 5f; // set the next time that this skill can be used to the current time plus the cooldown time
                    float height = GetComponent<SpriteRenderer>().sprite.bounds.size.y * transform.localScale.y;
                    Vector2 spot = new Vector2(transform.position.x, transform.position.y - (height / 2));
                    yield return new WaitForSeconds(0.7f); // animation time
                    Instantiate(stunMine, spot, transform.rotation);
                    anim.SetBool("Mine", false);
                }
            }
        }
    }

    

    private IEnumerator BasicAttack() //The normal attack. Shoots something straight ahead 
    {
        if(Input.GetButton(player_movement.controller_num + "X Button"))
        {
            
            if (!isBasicAttacking)
            {
                basic_attack_sound.Play();
                anim.SetBool("isBasicAttacking", true);
                isBasicAttacking = true;
                
                yield return new WaitForSeconds(0.25f); // animation time
                shoot();            
                yield return new WaitForSeconds(attackSpeed); // how long to wait before the next attack can be done
                anim.SetBool("isBasicAttacking", false);
                isBasicAttacking = false;
            }
        }
        //currentRage -= Time.deltaTime;
    }


    void shoot(float yChange = 0f)
    {
        float lastDirection = player_movement.lastDirection;
        Quaternion laserRoation = transform.rotation;
        float width = GetComponent<SpriteRenderer>().bounds.size.x;
        if (lastDirection < 0)
        {
            width = -width;
            float angle = 180;
            laserRoation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        Vector2 spot = new Vector2(transform.position.x + (width / 2), transform.position.y + yChange);
        GameObject thing = Instantiate(bullet, spot, laserRoation);
        bully = thing.GetComponent<bulletScript>();
        bully.damage = strength;
        bully.friendly = true;
    }

    public IEnumerator WhileInvisible() // change alpha value while invisible, this is where we could add the speed boost
    {
        if(gameObject.tag == "Invisible")
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
            player_movement.speed = 35f;
            yield return new WaitForSeconds(2f);
            GetComponent<SpriteRenderer>().color = Color.white;
            player_movement.speed = 30f;
        }
    }



    // Update is called once per frame
    void Update () {
        base.StatsCap();
        EnergyCap();
        StartCoroutine(WhileInvisible());
        StartCoroutine(BasicAttack());
        StartCoroutine(Ultimate());
        StartCoroutine(MultiShot());
        StartCoroutine(Mine());
        StartCoroutine(Invisible());
    }

}
