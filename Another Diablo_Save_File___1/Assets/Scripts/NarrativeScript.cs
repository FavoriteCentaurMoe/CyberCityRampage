using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NarrativeScript : MonoBehaviour {


    public float textCounter = 0f;

    //public Queue<string> sentences;

    public Text narrativeText;

    [TextArea(3,10)]
    public string[] sentences;
    public int sentenceCounter = 0;
    public int limit;

	// Use this for initialization
	void Start () {
        //sentences = new Queue<string>();
        //narrativeText.text = sentences[setenceCounter++];
        
        limit = sentences.Length;
        changeText();
        //Debug.Log("The nubmer of sentences are : " + limit);
	}
	
	// Update is called once per frame
	void Update () {
        checkForInput();	
	}

    public void checkForInput()
    {
        //if(textCounter <= Time.time)
        //{
            if ((Input.GetButtonDown("Ctr 1 A Button") || Input.GetButtonDown("Ctr 2 A Button") || Input.GetButtonDown("Ctr 3 A Button") || Input.GetButtonDown("Ctr 4 A Button")))
            {

                //textCounter = Time.time + 0.5f;
                //Debug.Log("The A button has been detected");
                changeText();
            }
        //}
    }

    public void changeText()
    {
        if(sentenceCounter + 1 <= limit)
        {
            Time.timeScale = 0;
            narrativeText.text = sentences[sentenceCounter++];
        }
        else
        {
            Time.timeScale = 1;
            //Debug.Log("Looks like we are OUT OF TEXT");
            Destroy(gameObject);
        }
    }

}
