using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The Controller for the SharpShooter character 
public class SharpShooterController : PlayerController {


    public Aiming aimer;
    public GameObject bullet;
    public bulletScript bully;

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

    private IEnumerator BasicAttack()
    {
       // if (Input.GetAxis("Left Trigger") == 1 || Input.GetAxis("Right Trigger") == 1)
        if(Input.GetButton("B Button")) // placeholder until i have access to a controller
        {
            
            if (!isBasicAttacking)
            {
                isBasicAttacking = true;
                float lastDirection = player_movement.lastDirection;
                Quaternion laserRoation = transform.rotation;
                float width = GetComponent<SpriteRenderer>().bounds.size.x;
                if(lastDirection<0)
                {
                    width = -width;
                    float angle = 180;
                    laserRoation = Quaternion.AngleAxis(angle, Vector3.forward);
                }
                Vector2 spot = new Vector2(transform.position.x + (width/2), transform.position.y);
                GameObject thing = Instantiate(bullet, spot, laserRoation);
                bully = thing.GetComponent<bulletScript>();
                bully.damage = strength;
                bully.friendly = true;
                yield return new WaitForSeconds(0.2f);              
                yield return new WaitForSeconds(0.1f);              
                yield return new WaitForSeconds(attackSpeed); // how long to wait before the next attack can be done
                isBasicAttacking = false;
            }
        }
        //currentRage -= Time.deltaTime;
    }

    // Update is called once per frame
    void Update () {
        StatsCap();
        StartCoroutine(BasicAttack());
	}

}
