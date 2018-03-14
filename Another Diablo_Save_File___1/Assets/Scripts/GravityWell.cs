using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityWell : MonoBehaviour {


	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, 3f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.transform.position = Vector3.MoveTowards(collision.gameObject.transform.position, transform.position, 0.25f);
        }
    }
}
