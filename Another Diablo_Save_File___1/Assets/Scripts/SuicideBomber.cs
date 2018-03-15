using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuicideBomber : ChasePlayer
{
    //public Animator anim;
    public float explodeTime = 0.25f;
    public float timer;
    public float explosionRadius;
    public GameObject agro;
    public CircleCollider2D cir;
    public float explosionDamage;
    public EnemyController enemy_controller;
    //public AudioSource hurt_sound;
    public AudioSource explosion_sound;
    public GameObject explosion_thing;
    public bool exploding;
    public bool exploded = false;

    private void Start()
    {

        base.Start();
        cir = GetComponent<CircleCollider2D>();
        //Debug.Log("Start of the suicide bomber is beginning");
        enemy_controller = GetComponent<EnemyController>();
        enemy_controller.maxHealth = 10f;
    }
    private void LateUpdate()
    {
        if (exploding)
        {
            StartCoroutine(explosion());
            exploding = false;
            exploded = true;
        }
    }

    public IEnumerator explosion()
    {

        yield return new WaitForSeconds(timer);
        anim.SetBool("Explode", true);
        yield return new WaitForSeconds(0.5f);
        Instantiate(explosion_thing, this.transform);
        explosion_sound.Play();
        Destroy(gameObject, explodeTime);
        


    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("enter trigger");
        if (collision.gameObject.tag == "Player")
        {
            //if (exploding)
            //{
            if (!exploded)
            {
                exploding = true;
            }

                //DamageTextHandler.makeDamageText(damage.ToString(), collision.transform);
            //}
        }


    }


}