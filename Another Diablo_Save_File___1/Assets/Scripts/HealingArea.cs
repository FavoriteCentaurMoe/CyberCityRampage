using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingArea : MonoBehaviour {

    public float lifetime = 3f;
    public float healAmount = 4f;
    public float healWaitTime = 2f;
    public float healTime = 0.0f;

    
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().HealPlayer(healAmount);
        }
    }
    */
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //collision.gameObject.GetComponent<PlayerController>().HealPlayer(healAmount);
            //StartCoroutine(HealDelay(other.gameObject));
            if(healTime <= Time.time)
            {
                healTime = Time.time + healWaitTime;
                other.GetComponent<PlayerController>().HealPlayer(healAmount);

            }

        }
    }

    private IEnumerator HealDelay(GameObject thing)
    {

        if (healWaitTime <= Time.time)
        {
         healWaitTime = Time.time + healWaitTime;
        }
        yield return new WaitForSeconds(0.1f);
        thing.GetComponent<PlayerController>().HealPlayer(healAmount);
    }


    // Use this for initialization
    void Start () {

        Destroy(gameObject, lifetime);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
