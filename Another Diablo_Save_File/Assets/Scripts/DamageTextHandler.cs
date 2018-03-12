using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTextHandler : MonoBehaviour {

    public DamageText damageText;
    public DamageText damageTextEnemy;
    public DamageText healText;

    public static DamageTextHandler dth;



    public static void Initialize()
    {
       
    }

    public static void makeDamageText(string text, Transform location, float time, string type)  //this is the function that players and enemies can call to create damage text wherever they desire 
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
            case "Heal":
                tempDamageText = Instantiate(dth.healText);
                break;
        }

        
        GameObject canvas = GameObject.Find("Canvas");
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(location.position);
        tempDamageText.transform.SetParent(canvas.transform, false);
        tempDamageText.SetText(text);
        tempDamageText.transform.position = screenPosition;
    }

    IEnumerator textOfDamage(float time) //this isn't working yet 
    { 
        yield return new WaitForSeconds(time);
       
    }

    // Use this for initialization
    void Start () {

        if (dth == null)  //This happens to the script always exists, like it is static 
        {
            dth = GameObject.FindGameObjectWithTag("GameController").GetComponent<DamageTextHandler>();
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
