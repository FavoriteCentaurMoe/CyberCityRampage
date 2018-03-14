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

    public bool exploding;

    private void Start()
    {
        base.Start();
        cir = GetComponent<CircleCollider2D>();
        //Debug.Log("Start of the suicide bomber is beginning");
        enemy_controller = GetComponent<EnemyController>();
        enemy_controller.maxHealth = 10f;




    }

    public IEnumerator explosion()
    {
        yield return new WaitForSeconds(timer);
        //Debug.Log("EXPLOSiON??");
        //agro.SetActive(false);
        //yield return new WaitForSeconds(0.2f);
        cir.radius = explosionRadius;
        exploding = true;
        damage = explosionDamage;
        anim.SetBool("Explode", true);
        explosion_sound.Play();
        //Debug.Log("Should be D E A D now");

    }



    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("enter trigger");
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(explosion());
            yield return new WaitForSeconds(timer);
            //if (exploding)
            //{
                //Debug.Log("Explosion!!");

                //if (collision.gameObject.tag == "Player")
                //{
                    if (!collision.gameObject.GetComponent<PlayerController>().hurt)
                    {
                        collision.gameObject.GetComponent<PlayerController>().HurtPlayer(damage);
                        Destroy(gameObject, explodeTime);
                        //DamageTextHandler.makeDamageText(damage.ToString(), collision.transform);
                    }
                //}
            //}
        }


    }


}