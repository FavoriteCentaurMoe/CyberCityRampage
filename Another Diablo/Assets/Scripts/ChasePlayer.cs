using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour {

    public Transform player = null;
    public bool inRange;
    public bool stunned;
    public float speed;
    public float damage;
    public float stunTime;
    public Transform defaultPosition;

	// Use this for initialization
	void Start () {
        speed = 3f;
        damage = 5f;
        stunned = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(stunned)
        {
            StartCoroutine(Stunned());
        }
        else if (!stunned)
        {
            if (inRange && player != null)
            {

                Vector3 direction = player.position - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 270;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.position += (player.position - transform.position).normalized * speed * Time.deltaTime;
            }
            else
            {
                Vector3 direction = defaultPosition.position - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 270;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.position += (defaultPosition.position - transform.position).normalized * speed * Time.deltaTime;
            }
        }
		
	}



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<WarriorController>().HurtPlayer(damage);
        }
    }

    private IEnumerator Stunned()
    {
         yield return new WaitForSeconds(stunTime);
         stunned = false;
    }
}
