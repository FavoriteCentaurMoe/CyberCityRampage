using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour {

    public Transform player = null;
    public bool inRange;
    public bool stunned;
    public bool knockBack;
    public float speed = 4f;
    public float damage;
    public float stunTime;
    public Transform defaultPosition;
    public float attackFrom;
    public float knockBackDistance;
    public float leftRight;
    public bool hurt;
    public Animator anim;

	// Use this for initialization
	public void Start () {
        //speed = 4f;
        damage = 5f;
        stunned = false;
        knockBack = false;
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if(hurt)
        {
            StartCoroutine(Hurt());
        }
        if(knockBack)
        {
            StartCoroutine(KnockBack());
        }
        if(stunned) // can be knocked back and stunned
        {
            StartCoroutine(Stunned());
        }
        //else if (!stunned)
        else
        {
            if (inRange && player != null)
            {
                anim.SetBool("Chasing", true);
                Vector3 direction = player.position - transform.position;
                //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 270;
                //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                Vector3 go = (player.position - transform.position).normalized;
                FaceDirection(go);
                transform.position += go * speed * Time.deltaTime;
            }
            else
            {
                anim.SetBool("Chasing", false);
                Vector3 direction = defaultPosition.position - transform.position;
                //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 270;
                //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                Vector3 go = (defaultPosition.position - transform.position).normalized;
                FaceDirection(go);
                transform.position +=  go * speed * Time.deltaTime;
            }
        }
		
	}



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (!collision.gameObject.GetComponent<PlayerController>().hurt)
            {
                collision.gameObject.GetComponent<PlayerController>().HurtPlayer(damage);
                //DamageTextHandler.makeDamageText(damage.ToString(), collision.transform);
            }
        }
        
    }

    private IEnumerator Stunned()
    {

         yield return new WaitForSeconds(stunTime);
         stunned = false;
    }

    public IEnumerator KnockBack()
    {
        //Debug.Log(attackFrom * knockBackDistance);
        transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3 (attackFrom * knockBackDistance,0,0), 0.5f);
        yield return new WaitForSeconds(0.1f);
        knockBack = false;
    }

    public void FaceDirection(Vector3 direction)
    {
        if(direction.x > 0)
        {
            transform.localScale = new Vector3(10, 10, 1);
        }
        else
        {
            transform.localScale = new Vector3(-10, 10, 1);
        }
    }

    public IEnumerator Hurt()
    {
        anim.SetBool("Hurt", true);
        yield return new WaitForSeconds(0.01f);
        anim.SetBool("Hurt", false);
        hurt = false;
    }
}
