using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTextHandler : MonoBehaviour {

    public DamageText damageText;
    public DamageText damageTextEnemy;

    public static DamageTextHandler dth;



    public static void Initialize()
    {
       
    }

    public static void makeDamageText(string text, Transform location, float time, string type)
    {
        dth.StartCoroutine("textOfDamage", time);
        DamageText tempDamageText = null;
        switch(type)
        {
            case "Enemy":
                Debug.Log("Enemy thing selected");
                tempDamageText = Instantiate(dth.damageTextEnemy);
                break;
            case "Player":
                tempDamageText = Instantiate(dth.damageText);
                break;
        }

        
        GameObject canvas = GameObject.Find("Canvas");
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(location.position);
        tempDamageText.transform.SetParent(canvas.transform, false);
        tempDamageText.SetText(text);
        tempDamageText.transform.position = screenPosition;
    }

    IEnumerator textOfDamage(float time)
    { 
        yield return new WaitForSeconds(time);
       
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
