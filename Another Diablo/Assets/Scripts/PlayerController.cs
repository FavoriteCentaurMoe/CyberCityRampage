
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This is the class that all other plays will inherit from 
public class PlayerController : MonoBehaviour {

    //Every player will have the following 
    public Animator anim;
    public float maxHealth;
    public float maxRage;
    public float currentHealth;
    public float currentRage;
    public float attackSpeed;
    public bool isBasicAttacking;
    public PlayerMovement player_movement;


//    //player stats
    public float strength;
    public float intelligence;
    public float luck;


    // Use this for initialization
    public void Start () {
        
        anim = GetComponent<Animator>();
        maxHealth = 100f;
        maxRage = 100f;
        currentHealth = maxHealth;
        currentRage = 100f;
        attackSpeed = 0.15f;
        isBasicAttacking = false;
        player_movement.speed = 7f;

        strength = 5f;

    }

    public void HurtPlayer(float damage)
    {
        DamageTextHandler.makeDamageText(damage.ToString(), transform, 1f, "Player");
        currentHealth -= damage;
   }

//    // Update is called once per frame
//    void Update () {
		
//	}
}
