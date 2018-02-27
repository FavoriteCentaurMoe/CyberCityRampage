using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTextHandler : MonoBehaviour {

    public DamageText damageText;

    public static DamageTextHandler dth;



    public static void Initialize()
    {
       
    }

    public static void makeDamageText(string text, Transform location)
    {
        DamageText tempDamageText = Instantiate(dth.damageText);
        GameObject canvas = GameObject.Find("Canvas");
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(location.position);
        tempDamageText.transform.SetParent(canvas.transform, false);
        tempDamageText.SetText(text);
        tempDamageText.transform.position = screenPosition;
    }

	// Use this for initialization
	void Start () {

        if (dth == null)
        {
            dth = GameObject.FindGameObjectWithTag("GameController").GetComponent<DamageTextHandler>();
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
