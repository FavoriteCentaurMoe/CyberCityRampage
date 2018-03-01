using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The Controller for the SharpShooter character 
public class SharpShooterController : PlayerController {


    public Aiming aimer;
    public GameObject bullet;
    public bulletScript bully;
    public GameObject aimedBullet;
    public aimedBulletScript aibully;

  

    public float multiShotCooldown = 0f; //this will be what gets added to TimeThing every time a skill is used 
    private float multiShotTimeThing = 0f;
    public float megaShotCooldown = 0f;

  // Use this for initialization
    void Start () {
       base.Start();
    }

    private void StatsCap()
    {

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        if (currentHealth < 0f)
        {
            currentHealth = 0f;
            Debug.Log("You DIED");
        }
    }

    private IEnumerator MultiShot() //Shoots multipe arrows. At the moment it is 3 arrows ,could be more
    {
            if (multiShotCooldown<= Time.time) // if cooldown is 0
            {
                if (Input.GetButton("A Button"))
                {
                    multiShotCooldown = Time.time +  3f; // set the next time that this skill can be used to the current time plus the cooldown time
                    Debug.Log("Multi Shot");
                    float height = GetComponent<SpriteRenderer>().bounds.size.y;
                    shoot(height/2);
                    shoot();
                    shoot(-height / 2);
                    yield return new WaitForSeconds(1.3f); // animation time
    
                }
            }
    }

    private IEnumerator MegaShot() //This is going to gi
    {
        if (multiShotCooldown <= Time.time) // if cooldown is 0
        {
            if (Input.GetButton("X Button"))
            {
                multiShotCooldown = Time.time + 3f; // set the next time that this skill can be used to the current time plus the cooldown time
                Debug.Log("M E G A Shot");
                Transform aimHere = aimer.eternalAimerInfo();  //transform;
                //if (aimer)
                //{
                // Debug.Log("Indeed aimer is active yuup");
                //  aimHere = aimer.eternalAimerInfo();
                //    Debug.Log(aimHere.rotation.z);
                //  }
                Debug.Log(aimHere.rotation.z);
                //       float lastDirection = player_movement.lastDirection;
                Quaternion laserRoation = aimHere.rotation;
                float width = GetComponent<SpriteRenderer>().bounds.size.x;
          //      if (lastDirection < 0)
          //      {
          //          width = -width;
           //         float angle = 180;
           //         laserRoation = Quaternion.AngleAxis(angle, Vector3.forward);
           //     }
                //Vector2 spot = new Vector2(transform.position.x + (width / 2), transform.position.y);
                GameObject thing = Instantiate( aimedBullet , aimHere.position, aimHere.rotation);
                aibully = thing.GetComponent<aimedBulletScript>();
                aibully.damage = strength;
                aibully.friendly = true;
                //bully.travel = Vector3.up;
                yield return new WaitForSeconds(1.3f); // animation time

            }
        }
    }

    

    private IEnumerator BasicAttack() //The normal attack. Shoots something straight ahead 
    {
       // if (Input.GetAxis("Left Trigger") == 1 || Input.GetAxis("Right Trigger") == 1)
        if(Input.GetButton("B Button")) // placeholder until i have access to a controller
        {
            
            if (!isBasicAttacking)
            {
                isBasicAttacking = true;
                shoot();
                //float lastDirection = player_movement.lastDirection;
                //Quaternion laserRoation = transform.rotation;
                //float width = GetComponent<SpriteRenderer>().bounds.size.x;
                //if(lastDirection<0)
                //{
                //    width = -width;
                //    float angle = 180;
                //    laserRoation = Quaternion.AngleAxis(angle, Vector3.forward);
                //}
                //Vector2 spot = new Vector2(transform.position.x + (width/2), transform.position.y);
                //GameObject thing = Instantiate(bullet, spot, laserRoation);
                //bully = thing.GetComponent<bulletScript>();
                //bully.damage = strength;
                //bully.friendly = true;
                yield return new WaitForSeconds(0.2f);              
                yield return new WaitForSeconds(0.1f);              
                yield return new WaitForSeconds(attackSpeed); // how long to wait before the next attack can be done
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



    // Update is called once per frame
    void Update () {
        StatsCap();
        StartCoroutine(BasicAttack());
        StartCoroutine(MultiShot());
        StartCoroutine(MegaShot());
    }

}
