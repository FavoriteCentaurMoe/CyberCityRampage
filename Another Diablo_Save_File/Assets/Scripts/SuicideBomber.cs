using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuicideBomber : ChasePlayer {

    public float explodeTime = 0.5f;
    public float timer;
    public float explosionRadius;
    public GameObject agro;
    public CircleCollider2D cir;
    public float explosionDamage;

    public bool exploding;

    private void Start()
    {
        base.Start();
        cir = GetComponent<CircleCollider2D>();
        //Debug.Log("Start of the suicide bomber is beginning");
        


    }

    public IEnumerator explosion()
    {
        yield return new WaitForSeconds(timer);
        //Debug.Log("EXPLOSiON??");
        agro.SetActive(false);
        //yield return new WaitForSeconds(0.2f);
        cir.radius = explosionRadius;
        exploding = true;
        damage = explosionDamage;
        //Debug.Log("Should be D E A D now");

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine(explosion());
            if (exploding)
            {
                //Debug.Log("Explosion!!");

                if (collision.gameObject.tag == "Player")
                {
                    if (!collision.gameObject.GetComponent<PlayerController>().hurt)
                    {
                        collision.gameObject.GetComponent<PlayerController>().HurtPlayer(damage);
                        Destroy(gameObject, explodeTime);
                        //DamageTextHandler.makeDamageText(damage.ToString(), collision.transform);
                    }
                }
            }
        }


    }
    

}
