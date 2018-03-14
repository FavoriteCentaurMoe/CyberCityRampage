using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageText : MonoBehaviour {

    public Text words;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 0.8f);
        words = GetComponent<Text>();
	}

    public void SetText(string text)
    {
        words.text = text;
    }


	
	// Update is called once per frame
	void Update () {
		
	}
}
