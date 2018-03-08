
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This is the class that all other plays will inherit from 
public class PlayerController : MonoBehaviour {
    

    //Every player will have the following 
    //public Animator anim;
    public float maxHealth;
    //public float maxRage;
    public float currentHealth;
    //public float currentRage;
    public float attackSpeed;
    public bool isBasicAttacking;
    public bool hurt;
    public PlayerMovement player_movement;


//    //player stats
    public float strength;
    public float intelligence;
    public float luck;


    // Use this for initialization
    public void Start () {
        
        //anim = GetComponent<Animator>();
        //maxHealth = 100f;
        //maxRage = 100f;
        //currentHealth = maxHealth;
        //currentRage = 100f;
        ///attackSpeed = 0.15f;
        isBasicAttacking = false;
        //player_movement.speed = 7f;

        //strength = 5f;

    }

    public virtual void HurtPlayer(float damage)
    {
        DamageTextHandler.makeDamageText(damage.ToString(), transform, 1f, "Player");
        currentHealth -= damage;
        StartCoroutine(HurtTime());
   }

    public void HealPlayer(float heal)
    {
        DamageTextHandler.makeDamageText(heal.ToString(), transform, 1f, "Heal");
        currentHealth += heal;
    }

    public virtual bool isMedic()
    {
        return false;
    }

    public IEnumerator HurtTime()
    {
        hurt = true;
        GetComponent<SpriteRenderer>().color = Color.magenta;
        yield return new WaitForSeconds(0.25f);
        if (GetComponent<WarriorController>() != null)
        {
            WarriorController warrior_controller;
            warrior_controller = GetComponent<WarriorController>();
            if (warrior_controller.goingBerserk)
            {
                GetComponent<SpriteRenderer>().color = new Color(1f, 0.5f, 0.5f, 1f);
            }
            else
            {
                GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
        hurt = false;
    }

    public void StatsCap()
    {
        //if (currentRage > maxRage)
        //{
        //    currentRage = maxRage;
        //}
        //if (currentRage < 0f)
        //{
        //    currentRage = 0f;
        //}
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        if (currentHealth <= 0f)
        {
            currentHealth = 0f;
            Destroy(this.gameObject);
        }
    }

    //    // Update is called once per frame
    //    void Update () {

    //	}
    
}
